"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.availableConfigs = void 0;
const index_1 = require("../../index");
const PageUtils_1 = require("../Crawlers/PageUtils");
exports.availableConfigs = {};
exports.availableConfigs["receitas-orcamentarias"] =
    {
        url: "receitas-orcamentarias",
        ConvertToObject(entidadeEsperada, entidade, conta, descricao, _descricaoVinculo, _vinculo, _orcado, valor) {
            const converted = {
                EntityName: entidade,
                Entity: entidade,
                Account: conta,
                Description: descricao,
                EffectedValue: parseFloat(valor),
                Reference: index_1.args.startDate,
            };
            return converted;
        },
        async ApplyFilter(page) {
            await (0, PageUtils_1.SelectEntity)(page);
            const startingSelector = 'input[name="dataInicial"]';
            const endingSelector = 'input[name="dataFinal"]';
            await page.waitForSelector('iframe');
            const frameHandle = await page.$('iframe');
            const frame = await frameHandle.contentFrame();
            await frame.waitForSelector(startingSelector);
            await frame.evaluate((selector, val) => {
                const inputElement = document.querySelector(selector);
                if (inputElement) {
                    inputElement.value = val;
                    inputElement.dispatchEvent(new Event('input', { bubbles: true }));
                    inputElement.dispatchEvent(new Event('change', { bubbles: true }));
                }
            }, startingSelector, index_1.args.startDate);
            await frame.waitForSelector(endingSelector);
            await frame.evaluate((selector, val) => {
                const inputElement = document.querySelector(selector);
                if (inputElement) {
                    inputElement.value = val;
                    inputElement.dispatchEvent(new Event('input', { bubbles: true }));
                    inputElement.dispatchEvent(new Event('change', { bubbles: true }));
                }
            }, endingSelector, index_1.args.endDate);
            await frame.waitForSelector('span[aria-label="Entidade"]');
            await frame.evaluate(() => {
                let element = document.querySelector('span[aria-label="Entidade"]');
                element.click();
            });
            await frame.waitForSelector('span[class="label_botao_acao"]');
            await frame.click('span[class="label_botao_acao"]');
            await new Promise(resolve => setTimeout(resolve, 1500));
        },
    };
exports.availableConfigs["busca-do-empenho"] =
    {
        url: "empenho-emitido",
        ConvertToObject(entidadeEsperada, entidade, empenho, _credor, emissao, _especie, _valor, _descricao) {
            if (emissao == null)
                return null;
            const parts = emissao.split("/");
            const formattedDate = `${parts[2]}-${parts[1]}-${parts[0]}`;
            const converted = {
                EntityName: entidade,
                Reference: formattedDate,
                Effort: empenho.replace(/\s/g, ""),
            };
            return converted;
        },
        async ApplyFilter(page) {
            const params = [
                {
                    Param: "unicpfcnpj",
                    Value: index_1.args.Document,
                },
                {
                    Param: "uninomerazao",
                    Value: index_1.args.Creditor,
                },
                {
                    Param: "plndescricao",
                    Value: index_1.args.ExpenseDescription,
                },
                {
                    Param: 'empdataemissao',
                    Value: index_1.args.startDate,
                    Operator: '>='
                },
                {
                    Param: 'empdataemissao',
                    Value: index_1.args.endDate,
                    Operator: '<='
                }
            ];
            await (0, PageUtils_1.SelectEntity)(page);
            await (0, PageUtils_1.ApplyFilter)(page, params);
        }
    };
exports.availableConfigs["pagamentos"] =
    {
        url: "pagamentos",
        ConvertToObject(_entidadeEsperada, empenho, data, valor, entidade, credor) {
            if (data == null)
                return null;
            const parts = data.split("/");
            const formattedDate = `${parts[2]}-${parts[1]}-${parts[0]}`;
            const converted = {
                EntityName: entidade,
                Effort: empenho,
                Reference: formattedDate,
                PayDay: formattedDate,
                PasepValue: parseFloat(valor),
            };
            return converted;
        },
        async ApplyFilter(page) {
            const params = [
                {
                    Param: 'pagdata',
                    Value: index_1.args.startDate,
                    Operator: '>='
                },
                {
                    Param: 'pagdata',
                    Value: index_1.args.endDate,
                    Operator: '<='
                }
            ];
            await (0, PageUtils_1.SelectEntity)(page);
            await (0, PageUtils_1.ApplyFilter)(page, params);
        },
    };
exports.availableConfigs["despesas"] =
    {
        url: "pagamentos",
        ConvertToObject(entidadeEsperada, empenho, data, valor, entidade, credor) {
            if (data == null)
                return null;
            const parts = data.split("/");
            const formattedDate = `${parts[2]}-${parts[1]}-${parts[0]}`;
            const converted = {
                EntityName: entidade,
                Type: 0,
                Description: credor,
                PASEP: empenho,
                Reference: formattedDate,
                Value: parseFloat(valor),
            };
            return converted;
        },
        async ApplyFilter(page) {
            const documents = index_1.args.Documents.split(';');
            const params = [];
            for (let i = 0, j = 1; i < documents.length; i++, j++) {
                params.push({
                    Param: "unicpfcnpj",
                    Value: documents[i],
                });
            }
            params.push({
                Param: "pagdata",
                Value: index_1.args.startDate,
                Operator: ">="
            });
            params.push({
                Param: "pagdata",
                Value: index_1.args.endDate,
                Operator: "<="
            });
            await (0, PageUtils_1.SelectEntity)(page);
            await (0, PageUtils_1.ApplyFilter)(page, params);
        },
    };
exports.availableConfigs["extra-despesa-pagamentos"] =
    {
        url: "notas-de-despesa-extra-pagas",
        ConvertToObject(_entidadeEsperada, _extra, _ordem, liquidacao, data, _conta, _descricao, _reduzido, _tipo, _documento, credor, valor) {
            if (data == null)
                return null;
            const parts = data.split("/");
            const formattedDate = `${parts[2]}-${parts[1]}-${parts[0]}`;
            const converted = {
                Type: 1,
                Description: credor,
                PASEP: liquidacao,
                Reference: formattedDate,
                Value: parseFloat(valor),
            };
            return converted;
        },
        async ApplyFilter(page) {
            let params = [];
            params.push({
                Param: 'data',
                Value: index_1.args.startDate,
                SecondValue: index_1.args.endDate,
                Operator: 'E'
            });
            const documents = index_1.args.Documents.split(';');
            for (let i = 0; i < documents.length; i++) {
                params.push({
                    Param: "cpfcnpj",
                    Value: documents[i],
                });
            }
            await (0, PageUtils_1.SelectEntity)(page);
            await (0, PageUtils_1.ApplyFilter)(page, params);
        }
    };
exports.availableConfigs["banco-do-brasil-fpm"] =
    {
        url: "",
        ConvertToObject(_entidadeEsperada, description, reference, value) {
            const converted = {
                Description: description,
                Collected: value,
                Competence: reference,
                Reference: reference,
            };
            return converted;
        },
        async ApplyFilter(page) { },
    };
//# sourceMappingURL=typesMap.js.map