import { args } from "../../index";
import { IPMCrawlerLines } from "../Crawlers/IPMCrawler";
import { availableConfigs } from "../EntityConfiguration/typesMap";
import { ConvertCSVLinesToObjects } from "../Utilities/FileManager";
import { removeDuplicates } from "../Utilities/removeDuplicates";

async function FindExpenses() {
    const expensesConfiguration = availableConfigs['despesas'];
    const expensesUrl = args.baseIPMUrl + expensesConfiguration.url;
    const expenseLines = await IPMCrawlerLines(expensesUrl, expensesConfiguration, args.credor);
    const expenses = ConvertCSVLinesToObjects(expensesConfiguration, expenseLines);

    return expenses;
}

async function FindExtraRevenues() {
    const extraConfiguration = availableConfigs['extra-despesa-pagamentos'];

    const extraUrl = args.baseIPMUrl + extraConfiguration.url;
    const extraLines = await IPMCrawlerLines(extraUrl, extraConfiguration);
    const extras = ConvertCSVLinesToObjects(extraConfiguration, extraLines);

    return extras;
}

export async function FindExpenseContent(): Promise<string> {
    const expensesInteiro = await FindExpenses();
    const expenses = removeDuplicates(expensesInteiro)

    const extrasInteiro = await FindExtraRevenues();
    const extras = removeDuplicates(extrasInteiro)

    const objectsInteiro = expenses.concat(extras);
    const objects = removeDuplicates(objectsInteiro)

    return JSON.stringify(removeDuplicates(objects));
}
