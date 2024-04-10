"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.IPMCrawlerLines = void 0;
const PageUtils_1 = require("./PageUtils");
const FileManager_1 = require("../Utilities/FileManager");
async function IPMCrawlerLines(url, configuration, credor) {
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
        const lastPartOfPath = url.substring(url.lastIndexOf('/') + 1);
        switch (lastPartOfPath) {
            case 'pagamentos':
                LinesCreate = await IPMCrawlerLinesCreatePagamento(page, LinesCreate);
                break;
            case 'notas-de-despesa-extra-pagas':
                LinesCreate = await IPMCrawlerCreateReceita(page, LinesCreate);
                break;
            case 'empenho-emitido':
                LinesCreate = await IPMCrawlerLinesCreateEmpenho(page, LinesCreate);
                break;
            case 'receitas-orcamentarias':
                LinesCreate = await IPMCrawlerLinesCreateDespesa(page, LinesCreate);
                break;
            default:
                break;
        }
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
exports.IPMCrawlerLines = IPMCrawlerLines;
async function IgnoreCaptchaCheck(page) {
    await page.waitForSelector('.btn-cookie.btn-aceitar-cookies');
    await page.click('.btn-cookie.btn-aceitar-cookies');
    await new Promise(resolve => setTimeout(resolve, 1500));
    let captchaWindow = await page.$('div[title="Verificação de acesso"]');
    if (captchaWindow == null)
        return;
    await new Promise(resolve => setTimeout(resolve, 1500));
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
async function IPMCrawlerLinesCreatePagamento(page, LinesCreate) {
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
                const Pessoa = tds[2];
                const dataRow = [Empenho, Data, Valor, Pessoa, Credor];
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
        return IPMCrawlerLinesCreatePagamento(page, LinesCreate);
    }
    return LinesCreate;
}
async function IPMCrawlerCreateReceita(page, LinesCreate) {
    await page.waitForSelector('iframe');
    const frameHandle = await page.$('iframe');
    const frame = await frameHandle.contentFrame();
    const trElements = await frame.$$('table[aria-label="Dados da Consulta"] > tbody > tr');
    for (const trElement of trElements) {
        const tds = await trElement.$$eval('td[role="gridcell"]', tds => tds.map(td => td.textContent.trim()));
        if (tds.length >= 5) {
            const extra = tds[0];
            if (extra) {
                const ordem = tds[1];
                const Liquidação = tds[2];
                const Data = tds[3];
                const Conta = tds[4];
                const Descricao = tds[5];
                const Reduzido = tds[6];
                const tipo = tds[7];
                const documento = tds[8];
                const credor = tds[9];
                const valor = formatBrazilianDecimalString(tds[10]);
                const dataRow = [extra, ordem, Liquidação, Data, Conta, Descricao, Reduzido, tipo, documento, credor, valor];
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
        return IPMCrawlerCreateReceita(page, LinesCreate);
    }
    return LinesCreate;
}
async function IPMCrawlerLinesCreateEmpenho(page, LinesCreate) {
    await page.waitForSelector('iframe');
    const frameHandle = await page.$('iframe');
    const frame = await frameHandle.contentFrame();
    const trElements = await frame.$$('table[aria-label="Dados da Consulta"] > tbody > tr');
    for (const trElement of trElements) {
        const tds = await trElement.$$eval('td[role="gridcell"]', tds => tds.map(td => td.textContent.trim()));
        if (tds.length >= 5) {
            const entidade = tds[0];
            if (entidade) {
                const credor = tds[1];
                const empenho = tds[2];
                const especie = tds[3];
                const emissao = tds[4];
                const descricao = tds[5];
                const valor = formatBrazilianDecimalString(tds[6]);
                const dataRow = [entidade, empenho, credor, emissao, especie, valor, descricao];
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
        return IPMCrawlerLinesCreateEmpenho(page, LinesCreate);
    }
    return LinesCreate;
}
async function IPMCrawlerLinesCreateDespesa(page, LinesCreate) {
    await page.waitForSelector('iframe');
    const frameHandle = await page.$('iframe');
    const frame = await frameHandle.contentFrame();
    const trElements = await frame.$$('table[aria-label="Dados da Consulta"] > tbody > tr');
    for (const trElement of trElements) {
        const tds = await trElement.$$eval('td[role="gridcell"]', tds => tds.map(td => td.textContent.trim()));
        if (tds.length >= 5) {
            const entidade = tds[0];
            if (entidade) {
                const conta = tds[1];
                const descricaoConta = tds[2];
                const vinculo = tds[3];
                const descricaoVeiculo = tds[4];
                const orcado = formatBrazilianDecimalString(tds[5]);
                const valor = formatBrazilianDecimalString(tds[6]);
                const dataRow = [entidade, conta, descricaoConta, vinculo, descricaoVeiculo, orcado, valor];
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
        return IPMCrawlerLinesCreateDespesa(page, LinesCreate);
    }
    return LinesCreate;
}
//# sourceMappingURL=IPMCrawler.js.map