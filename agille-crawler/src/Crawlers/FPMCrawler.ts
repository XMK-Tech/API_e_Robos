import { Page } from 'puppeteer';
import { CloseConnection, OpenConnection, /* SelectOption */ SelectorClick, SelectorExists, SetSelectorInput, WaitForNavigation } from './PageUtils';
import { CalculateIntervals } from '../Utilities/IntervalParser';
import { args } from '../..';
import { WriteError } from '../Utilities/FileManager';
import { removerAcentos } from '../Utilities/removerAcentos';

async function SetFilter(page: Page, startingReference: string, endingReference: string) {
  const startDateInputSelector = '#formulario\\:dataInicial';
  await SetSelectorInput(page, startDateInputSelector, startingReference);

  const endDateInputSelector = '#formulario\\:dataFinal';
  await SetSelectorInput(page, endDateInputSelector, endingReference);

  //const optionsSelector = '#formulario\\:comboFundo';
  //await SelectOption(page, optionsSelector, '4');

  await SelectorClick(page, 'input[name="formulario:j_id20"]');
}

async function SetCity(page: Page, city: string) {
  const cityInputSelector = '#formulario\\:txtBenef';
  await SetSelectorInput(page, cityInputSelector, city);

  await SelectorClick(page, 'input[name="formulario:j_id16"]');
}

async function selectOptionByText(page, selectSelector, optionText) {
  await page.waitForSelector(selectSelector);

  const isOptionAlreadySelected = await page.evaluate((selectSelector, optionText) => {
    const selectElement = document.querySelector(selectSelector) as HTMLSelectElement;
    const selectedOption = selectElement.options[selectElement.selectedIndex] as HTMLOptionElement;
    // Verifica se o texto da opção já selecionada é igual ao optionText fornecido
    return selectedOption.innerText.includes(optionText);
  }, selectSelector, optionText);

  // Se a opção desejada já estiver selecionada, retorna sem fazer mais nada
  if (isOptionAlreadySelected) {
    return;
  }

  const optionValue = await page.evaluate((selectSelector, optionText) => {
    const selectElement = document.querySelector(selectSelector) as HTMLSelectElement;
    const options = Array.from(selectElement.options);
    const optionToSelect = options.find(option => (option as HTMLOptionElement).innerText.includes(optionText));
    return optionToSelect ? optionToSelect.value : null;
  }, selectSelector, optionText);

  if (optionValue !== null) {
    await page.select(selectSelector, optionValue);
  }
}

async function FindInteravalData(page: Page, startingReference: string, endingReference: string): Promise<string[][]> {
  const lines = [];

  const tbody = await page.$('#formulario\\:demonstrativoList\\:tb');

  let index = 1;
  const template = '#formulario\\:demonstrativoList\\:{number}\\:j_id29';
  let descriptionSelector = template.replace('{number}', index.toString());

  let description = await tbody.$(descriptionSelector);

  while (description != null) {
    let textContent = await page.evaluate((element) => element.textContent.trim(), description);
    textContent = textContent.replace(/\s+/g, ' ').trim();

    if (textContent == 'TOTAL DOS REPASSES NO PERIODO')
      break;

    const elementsSelector = '[id^="formulario\\:demonstrativoList\\:{number}\\:subTableLancamentos"]'.replace('{number}', index.toString());
    const elements = await page.$$(elementsSelector);

    const values: string[] = [];
    for (const element of elements) {
      if (element != null) {
        const value = await page.evaluate((element) => element.textContent.trim(), element);
        if (value != '')
          values.push(value);
      }
    }

    const dataValuePairs = [];
    const usedReferences: string[] = [];
    let data = null;

    for (let i = 0; i < values.length; i++) {
      const element = values[i];

      if (element.includes('PASEP')) {
        if (data) {
          const nextElement = values[i + 1];
          const valueMatch = nextElement.match(/R\$\s*([\d.,]+)/);
          if (valueMatch) {
            const value = valueMatch[1].replace('.', '').replace(',', '.');
            const dateMatch = data.match(/(\d{2})\.(\d{2})\.(\d{4})/);

            if (dateMatch) {
              const day = dateMatch[1];
              const month = dateMatch[2];
              const year = dateMatch[3];
              const formattedDate = `${year}-${month}-${day}`;

              if (usedReferences.indexOf(formattedDate) == -1) {
                dataValuePairs.push([textContent, formattedDate, value]);
                usedReferences.push(formattedDate);
              }
            }
          }
        }
      }
      else if (element.match(/\d{2}\.\d{2}\.\d{4}/)) {
        data = element;
      }
    }

    lines.push(...dataValuePairs);

    index++;
    descriptionSelector = template.replace('{number}', index.toString());
    description = await tbody.$(descriptionSelector);
  };

  return lines;
}

async function CurrentFilterHasData(page: Page): Promise<boolean> {
  await WaitForNavigation(page);
  return !(await SelectorExists(page, '.alert-danger'));
}

export async function FPMCrawlerLines(url: string, cityName: string, startingReference: string, endingReference: string): Promise<string[][]> {
  let page: Page;
  const lines: string[][] = [];

  try {
    page = await OpenConnection(url, true);

    await SetCity(page, args.sanitizedName.toUpperCase());

    await new Promise(resolve => setTimeout(resolve, 1500));
    await selectOptionByText(page, '#formulario\\:comboBeneficiario', await removerAcentos(args.cityComand));

    const intervals = CalculateIntervals(startingReference, endingReference);
    for (const interval of intervals) {
      await SetFilter(page, interval.startingReference, interval.endingReference);
      const hasData = await CurrentFilterHasData(page);
      if (hasData) {
        const intervalLines = await FindInteravalData(page, interval.startingReference, interval.endingReference);
        lines.push(...intervalLines);

        await SelectorClick(page, 'input[name="formulario:botaoVoltar"]');
      }
    }
  }
  catch (error) {
    await WriteError(error);
  }
  finally {
    await CloseConnection(page);
  }

  return lines;
}