"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.FPMCrawlerLines = void 0;
const PageUtils_1 = require("./PageUtils");
const IntervalParser_1 = require("../Utilities/IntervalParser");
const __1 = require("../..");
const FileManager_1 = require("../Utilities/FileManager");
const removerAcentos_1 = require("../Utilities/removerAcentos");
async function SetFilter(page, startingReference, endingReference) {
    const startDateInputSelector = '#formulario\\:dataInicial';
    await (0, PageUtils_1.SetSelectorInput)(page, startDateInputSelector, startingReference);
    const endDateInputSelector = '#formulario\\:dataFinal';
    await (0, PageUtils_1.SetSelectorInput)(page, endDateInputSelector, endingReference);
    await (0, PageUtils_1.SelectorClick)(page, 'input[name="formulario:j_id20"]');
}
async function SetCity(page, city) {
    const cityInputSelector = '#formulario\\:txtBenef';
    await (0, PageUtils_1.SetSelectorInput)(page, cityInputSelector, city);
    await (0, PageUtils_1.SelectorClick)(page, 'input[name="formulario:j_id16"]');
}
async function selectOptionByText(page, selectSelector, optionText) {
    await page.waitForSelector(selectSelector);
    const isOptionAlreadySelected = await page.evaluate((selectSelector, optionText) => {
        const selectElement = document.querySelector(selectSelector);
        const selectedOption = selectElement.options[selectElement.selectedIndex];
        return selectedOption.innerText.includes(optionText);
    }, selectSelector, optionText);
    if (isOptionAlreadySelected) {
        return;
    }
    const optionValue = await page.evaluate((selectSelector, optionText) => {
        const selectElement = document.querySelector(selectSelector);
        const options = Array.from(selectElement.options);
        const optionToSelect = options.find(option => option.innerText.includes(optionText));
        return optionToSelect ? optionToSelect.value : null;
    }, selectSelector, optionText);
    if (optionValue !== null) {
        await page.select(selectSelector, optionValue);
    }
}
async function FindInteravalData(page, startingReference, endingReference) {
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
        const values = [];
        for (const element of elements) {
            if (element != null) {
                const value = await page.evaluate((element) => element.textContent.trim(), element);
                if (value != '')
                    values.push(value);
            }
        }
        const dataValuePairs = [];
        const usedReferences = [];
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
    }
    ;
    return lines;
}
async function CurrentFilterHasData(page) {
    await (0, PageUtils_1.WaitForNavigation)(page);
    return !(await (0, PageUtils_1.SelectorExists)(page, '.alert-danger'));
}
async function FPMCrawlerLines(url, cityName, startingReference, endingReference) {
    let page;
    const lines = [];
    try {
        page = await (0, PageUtils_1.OpenConnection)(url, true);
        await SetCity(page, __1.args.sanitizedName.toUpperCase());
        await new Promise(resolve => setTimeout(resolve, 1500));
        await selectOptionByText(page, '#formulario\\:comboBeneficiario', await (0, removerAcentos_1.removerAcentos)(__1.args.cityComand));
        const intervals = (0, IntervalParser_1.CalculateIntervals)(startingReference, endingReference);
        for (const interval of intervals) {
            await SetFilter(page, interval.startingReference, interval.endingReference);
            const hasData = await CurrentFilterHasData(page);
            if (hasData) {
                const intervalLines = await FindInteravalData(page, interval.startingReference, interval.endingReference);
                lines.push(...intervalLines);
                await (0, PageUtils_1.SelectorClick)(page, 'input[name="formulario:botaoVoltar"]');
            }
        }
    }
    catch (error) {
        await (0, FileManager_1.WriteError)(error);
    }
    finally {
        await (0, PageUtils_1.CloseConnection)(page);
    }
    return lines;
}
exports.FPMCrawlerLines = FPMCrawlerLines;
//# sourceMappingURL=FPMCrawler.js.map