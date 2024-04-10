import { CrawlerConfig } from "../Types/CrawlerConfig";
import { args } from "../../index";
import { ApplyFilter, SelectEntity } from "../Crawlers/PageUtils";

export const availableConfigs: { [key: string]: CrawlerConfig } = {};

// REVENUES
availableConfigs["receitas-orcamentarias"] =
{
  url: "receitas-orcamentarias",

  ConvertToObject(
    entidadeEsperada,
    entidade,
    conta,
    descricao,
    _descricaoVinculo,
    _vinculo,
    _orcado,
    valor
  ): object {
    const converted =
    {
      EntityName: entidade,
      Entity: entidade,
      Account: conta,
      Description: descricao,
      EffectedValue: parseFloat(valor),
      Reference: args.startDate,
    };

    return converted;
  },

  async ApplyFilter(page) {
    await SelectEntity(page);

    const startingSelector = 'input[name="dataInicial"]';
    const endingSelector = 'input[name="dataFinal"]';

    await page.waitForSelector('iframe');
    const frameHandle = await page.$('iframe');
    const frame = await frameHandle.contentFrame();

    await frame.waitForSelector(startingSelector);
    await frame.evaluate((selector, val) => {
      const inputElement = document.querySelector(selector) as HTMLInputElement;
      if (inputElement) {
        inputElement.value = val;
        inputElement.dispatchEvent(new Event('input', { bubbles: true }));
        inputElement.dispatchEvent(new Event('change', { bubbles: true }));
      }
    }, startingSelector, args.startDate);

    await frame.waitForSelector(endingSelector);
    await frame.evaluate((selector, val) => {
      const inputElement = document.querySelector(selector) as HTMLInputElement;
      if (inputElement) {
        inputElement.value = val;
        inputElement.dispatchEvent(new Event('input', { bubbles: true }));
        inputElement.dispatchEvent(new Event('change', { bubbles: true }));
      }
    }, endingSelector, args.endDate);

    await frame.waitForSelector('span[aria-label="Entidade"]');
    await frame.evaluate(() => {
      let element: HTMLElement = document.querySelector('span[aria-label="Entidade"]');
      element.click()
    });

    await frame.waitForSelector('span[class="label_botao_acao"]');
    await frame.click('span[class="label_botao_acao"]');
    await new Promise(resolve => setTimeout(resolve, 1500));
  },
};

// COLLECTIONS
availableConfigs["busca-do-empenho"] =
{
  url: "empenho-emitido",

  ConvertToObject(
    entidadeEsperada,
    entidade,
    empenho,
    _credor,
    emissao,
    _especie,
    _valor,
    _descricao
  ) {
    if (emissao == null)
      return null;

    const parts = emissao.split("/");
    const formattedDate = `${parts[2]}-${parts[1]}-${parts[0]}`;

    const converted =
    {
      EntityName: entidade,
      Reference: formattedDate,
      Effort: empenho.replace(/\s/g, ""),
    };

    return converted;
  },

  async ApplyFilter(page) {
    const params =
      [
        {
          Param: "unicpfcnpj",
          Value: args.Document,
        },
        {
          Param: "uninomerazao",
          Value: args.Creditor,
        },
        {
          Param: "plndescricao",
          Value: args.ExpenseDescription,
        },
        {
          Param: 'empdataemissao',
          Value: args.startDate,
          Operator: '>='
        },
        {
          Param: 'empdataemissao',
          Value: args.endDate,
          Operator: '<='
        }
      ];

    await SelectEntity(page);
    await ApplyFilter(page, params);
  }
};

availableConfigs["pagamentos"] =
{
  url: "pagamentos",

  ConvertToObject(_entidadeEsperada, empenho, data, valor, entidade, credor) {
    if (data == null)
      return null;

    const parts = data.split("/");
    const formattedDate = `${parts[2]}-${parts[1]}-${parts[0]}`;

    const converted =
    {
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
        Value: args.startDate,
        Operator: '>='
      },
      {
        Param: 'pagdata',
        Value: args.endDate,
        Operator: '<='
      }
    ];

    await SelectEntity(page);
    await ApplyFilter(page, params);
  },
};

// EXPENSES
availableConfigs["despesas"] =
{
  url: "pagamentos",

  ConvertToObject(entidadeEsperada, empenho, data, valor, entidade, credor) {
    if (data == null)
      return null;

    const parts = data.split("/");
    const formattedDate = `${parts[2]}-${parts[1]}-${parts[0]}`;

    const converted =
    {
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
    const documents: string[] = args.Documents.split(';');

    const params = [];
    for (let i = 0, j = 1; i < documents.length; i++, j++) {
      params.push({
        Param: "unicpfcnpj",
        Value: documents[i],
      });
    }

    params.push(
      {
        Param: "pagdata",
        Value: args.startDate,
        Operator: ">="
      });

    params.push(
      {
        Param: "pagdata",
        Value: args.endDate,
        Operator: "<="
      });

    await SelectEntity(page);
    await ApplyFilter(page, params);
  },
};

availableConfigs["extra-despesa-pagamentos"] =
{
  url: "notas-de-despesa-extra-pagas",
  ConvertToObject(
    _entidadeEsperada,
    _extra,
    _ordem,
    liquidacao,
    data,
    _conta,
    _descricao,
    _reduzido,
    _tipo,
    _documento,
    credor,
    valor
  ) {

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

    params.push(
      {
        Param: 'data',
        Value: args.startDate,
        SecondValue: args.endDate,
        Operator: 'E'
      });

    const documents: string[] = args.Documents.split(';');

    for (let i = 0; i < documents.length; i++) {
      params.push({
        Param: "cpfcnpj",
        Value: documents[i],
      });
    }

    await SelectEntity(page);
    await ApplyFilter(page, params);
  }
};

// FPM LAUNCH
availableConfigs["banco-do-brasil-fpm"] =
{
  url: "",

  ConvertToObject(_entidadeEsperada, description, reference, value): object {
    const converted =
    {
      Description: description,
      Collected: value,
      Competence: reference,
      Reference: reference,
    };

    return converted;
  },

  async ApplyFilter(page) { },
};
