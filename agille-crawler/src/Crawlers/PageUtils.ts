import puppeteer, { ElementHandle, Page } from "puppeteer";
const puppeteerExtra = require('puppeteer-extra');
const Stealth = require('puppeteer-extra-plugin-stealth');
/* const randomUseragent = require('random-useragent');
const USER_AGENT = 'Mozilla/5.0 (Macintosh; Intel Mac OS X 10_14_1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/73.0.3683.75 Safari/537.36'; */

import { Parameter } from "../Types/FilterParam";
import { args } from "../..";

puppeteerExtra.use(Stealth());

export async function OpenConnection(url: string, headless: boolean = true) {
  const browser = await puppeteer.launch(
    {
      headless: headless,
      args: ['--no-sandbox', '--disable-setuid-sandbox'],
    });

  const page = await browser.newPage();

  const userAgent = 'Chrome/89.0.4389.82 Safari/537.36';

  //Randomize viewport size
  await page.setViewport({
    width: 1920 + Math.floor(Math.random() * 100),
    height: 3000 + Math.floor(Math.random() * 100),
    deviceScaleFactor: 1,
    hasTouch: false,
    isLandscape: false,
    isMobile: false,
  });

  await page.setUserAgent(userAgent);
  await page.setJavaScriptEnabled(true);

  await page.setDefaultNavigationTimeout(30000)

  await page.setDefaultNavigationTimeout(0);

  //Skip images/styles/fonts loading for performance
  /* await page.setRequestInterception(true); */
  /* page.on('request', (req) => {
      if(req.resourceType() == 'stylesheet' || req.resourceType() == 'font' || req.resourceType() == 'image'){
          req.abort();
      } else {
          req.continue();
      }
  });  */

  await page.evaluateOnNewDocument(() => {
    // Pass webdriver check
    Object.defineProperty(navigator, 'webdriver', {
      get: () => false,
    });
  });

  await page.evaluateOnNewDocument(() => {
    Object.defineProperty(navigator, 'plugins', {
      get: () => [1, 2, 3, 4, 5],
    });
    Object.defineProperty(navigator, 'languages', {
      get: () => ['en-US', 'en'],
    });
  });

  await page.goto(url,
    { waitUntil: 'networkidle2' }
  );

  puppeteerExtra.use(Stealth());

  return page;
}

export async function CloseConnection(page: Page) {
  await page.browser().close();
}

export async function SetSelectorInput(
  page: Page,
  selector: string,
  value: string
) {
  await page.waitForSelector(selector);
  await page.$eval(
    selector,
    (el: HTMLInputElement, value: string) => {
      el.value = value;
    },
    value
  );
}

export async function SelectorClick(page: Page, selector: string) {
  try {
    await page.waitForSelector(selector);
    await page.click(selector);
  } catch
  {
    await EventSelectorClick(page, selector);
  }
}

export async function EventSelectorClick(page: Page, selector: string) {
  await page.waitForSelector(selector);
  await page.evaluate((selector) => {
    const element = document.querySelector(selector) as HTMLElement;
    element?.click();
  }, selector);
}

export async function SelectOption(
  page: Page,
  selector: string,
  optionValue: string
) {
  await page.waitForSelector(selector);
  await page.select(selector, optionValue);
}

export async function ClickSpanInsideIframe(page, iframeSelector, spanSelector) {
  await page.waitForSelector(iframeSelector);
  const frameHandle = await page.$(iframeSelector);
  const frame = await frameHandle.contentFrame();

  await frame.waitForSelector(spanSelector, { visible: true });
  await frame.click(spanSelector);
}

export async function AddPageFilterLines(page, count) {

  await page.waitForSelector('iframe');
  const frameHandle = await page.$('iframe');
  const frame = await frameHandle.contentFrame();

  for (let i = 0; i < count; i++) {
    await frame.waitForSelector('span[title="Outras opções"]');
    await frame.evaluate(() => {
      let element: HTMLElement = document.querySelector('span[title="Outras opções"]');
      element.click()
    });

    await frame.waitForSelector('span[title="Adiciona um novo filtro à consulta"]');
    await frame.evaluate(() => {
      let element: HTMLElement = document.querySelector('span[title="Adiciona um novo filtro à consulta"]');
      element.click()
    });
  }
}

export async function ApplyFilter(page: Page, params: Parameter[]) {
  await AddPageFilterLines(page, params.length - 1);

  await page.waitForSelector('iframe');
  const frameHandle = await page.$('iframe');
  const frame = await frameHandle.contentFrame();

  await frame.waitForSelector('tbody[name="grd_filtros_consulta"]')
  const rowFilters = await frame.$$('tbody[name="grd_filtros_consulta"] tr')

  for (let i = 0, j = 1; i < params.length; i++, j++) {
    const row = rowFilters[j];
    const param = params[i];

    await frame.waitForSelector('select[aria-label="Campo de Filtro"]')
    const selectElement = await row.$('select[aria-label="Campo de Filtro"]');

    if (param.Operator != 'E')
      await selectElement.select(param.Param);

    if (param.Operator != undefined)
      await SetRowOperator(row, frame, param.Operator)

    await new Promise(resolve => setTimeout(resolve, 1000));
    const inputElement = await row.$$('td > input[aria-label*="valor para o filtro sobre"]');
    await SetFieldValueFrame(frame, inputElement[0], param.Value);

    if (param.SecondValue != null && inputElement.length > 1)
      await SetFieldValueFrame(frame, inputElement[1], param.SecondValue);
  }

  await frame.waitForSelector('span[class="label_botao_acao"]');
  await frame.click('span[class="label_botao_acao"]');
  await new Promise(resolve => setTimeout(resolve, 1500));
}

async function SetFieldValueFrame(frame, inputElement: ElementHandle<Element>, value: string) {
  await frame.evaluate((input, val) => {
    (input as HTMLInputElement).value = val;
  }, inputElement, value);
}

async function SetRowOperator(row, frame, operatorStr: string) {
  const operator = await row.$('select[aria-label="Operador Aplicado"]');
  await frame.evaluate((input: HTMLSelectElement, value) => {
    input.value = value;
  },
    operator,
    operatorStr
  );
}

function removerAcentos(s: string): string {
  return s.normalize("NFD").replace(/[\u0300-\u036f]/g, "");
}

export async function SelectEntity(page: Page) {

  let cityName: string = removerAcentos(args.cityName.toUpperCase());

  await page.waitForSelector('iframe');
  const frameHandle = await page.$('iframe');
  const frame = await frameHandle.contentFrame();

  await frame.waitForSelector('span[aria-label="Entidade"]');
  await frame.evaluate(() => {
    let element: HTMLElement = document.querySelector('span[aria-label="Entidade"]');
    element.click()
  });

  await frame.waitForSelector(`label[title="MUNICÍPIO DE ${cityName}"]`);
  await frame.evaluate(cityName => {
    const element: HTMLElement = document.querySelector(`label[title="MUNICÍPIO DE ${cityName}"]`)
    element.click()
  }, cityName)

  const selector = 'select[aria-label="Ano"]';
  const selectExists = await frame.waitForSelector(selector, { visible: true, timeout: 5000 }).then(() => true).catch(() => false);

  if (selectExists) {
    const anoSelect: string = args.yarnEndDate;
    await frame.evaluate(async (ano) => {
      await new Promise(resolve => setTimeout(resolve, 1500));
      const selectElement = document.querySelector('select[aria-label="Ano"]');
      await new Promise(resolve => setTimeout(resolve, 1500));
      if (selectElement) {
        if (!(selectElement instanceof HTMLSelectElement)) {
          console.error('Select element is not a HTMLSelectElement');
          return;
        }
        await new Promise(resolve => setTimeout(resolve, 1500));
        const optionToSelect = Array.from(selectElement.options).find(option => option.value === ano);
        if (optionToSelect) {
          await new Promise(resolve => setTimeout(resolve, 1000));
          selectElement.value = optionToSelect.value;
          await new Promise(resolve => setTimeout(resolve, 1000));
          selectElement.dispatchEvent(new Event('change', { bubbles: true }));
        }
      }
    }, anoSelect);
  }
  await new Promise(resolve => setTimeout(resolve, 1000));
  await frame.waitForNavigation({
    waitUntil: 'networkidle0',
    timeout: 3000
  }).catch(e => console.log('No navigation after setting value', e));
}

export async function SelectorExists(page: Page, selector: string) {
  return await page.evaluate((selector) => {
    const select = document.querySelector(selector);
    return select !== null;
  }, selector);
}

export async function WaitForNavigation(page: Page) {
  await page.waitForNavigation({ waitUntil: 'networkidle0', timeout: 2000 }).catch((_error) => { });
}