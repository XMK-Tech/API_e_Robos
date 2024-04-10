"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.IPMCrawlerLinesCollection = void 0;
const PageUtils_1 = require("./PageUtils");
const FileManager_1 = require("../Utilities/FileManager");
async function IPMCrawlerLinesCollection(url, configuration, credor) {
    let page;
    let LinesCreate = [];
    try {
        page = await (0, PageUtils_1.OpenConnection)(url);
        await new Promise(resolve => setTimeout(resolve, 3000));
        await (0, FileManager_1.LoadCookies)(page);
        await new Promise(resolve => setTimeout(resolve, 1000));
        await IgnoreCaptchaCheck(page);
        await new Promise(resolve => setTimeout(resolve, 1000));
        await configuration.ApplyFilter(page);
        await new Promise(resolve => setTimeout(resolve, 1000));
        LinesCreate = await IPMCrawlerLinesCreate(page, LinesCreate);
    }
    catch (error) {
        await (0, FileManager_1.WriteError)(error);
    }
    finally {
        await (0, FileManager_1.SaveCookies)(page);
        await (0, PageUtils_1.CloseConnection)(page);
    }
    return LinesCreate;
}
exports.IPMCrawlerLinesCollection = IPMCrawlerLinesCollection;
async function IgnoreCaptchaCheck(page) {
    await page.waitForSelector('.btn-cookie.btn-aceitar-cookies');
    await page.click('.btn-cookie.btn-aceitar-cookies');
    await new Promise(resolve => setTimeout(resolve, 1500));
    let captchaWindow = await page.$('div[title="Verificação de acesso"]');
    if (captchaWindow == null)
        return;
    console.log("Captcha detectado.");
    await new Promise(resolve => setTimeout(resolve, 2000));
    await page.$$eval('button[name="fechar"]', (buttons) => {
        buttons.forEach((button) => {
            const htmlButton = button;
            const ariaLabel = htmlButton.getAttribute('aria-label');
            if (ariaLabel !== "Fechar Janela")
                htmlButton.click();
        });
    });
}
function formatBrazilianDecimalString(input) {
    let result = input.replace(/\./g, '');
    result = result.replace(',', '.');
    return result;
}
async function IPMCrawlerLinesCreate(page, LinesCreate) {
    await page.waitForSelector('iframe');
    const frameHandle = await page.$('iframe');
    const frame = await frameHandle.contentFrame();
    const trElements = await frame.$$('table[aria-label="Dados da Consulta"] > tbody > tr');
    for (const trElement of trElements) {
        const tds = await trElement.$$eval('td[role="gridcell"]', tds => tds.map(td => td.textContent.trim()));
        if (tds.length >= 5) {
            const entidade = tds[0];
            if (entidade) {
                const Empenho = tds[4];
                const Data = tds[5];
                const Credor = tds[1];
                const Valor = formatBrazilianDecimalString(tds[6]);
                const dataRow = [Empenho, Data, Valor, entidade, Credor];
                LinesCreate.push(dataRow);
            }
        }
    }
    const nextButton = await frame.$('span[name="proxima_pagina"]');
    const isDisabled = await frame.evaluate(el => el.getAttribute('aria-description') === 'desativado', nextButton);
    if (nextButton && !isDisabled) {
        await nextButton.click();
        await new Promise(resolve => setTimeout(resolve, 1500));
        await frame.waitForSelector('table[aria-label="Dados da Consulta"]');
        return IPMCrawlerLinesCreate(page, LinesCreate);
    }
    return LinesCreate;
}
//# sourceMappingURL=IPMCrawlerCollection.js.map