"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.FindExpenseContent = void 0;
const index_1 = require("../../index");
const IPMCrawler_1 = require("../Crawlers/IPMCrawler");
const typesMap_1 = require("../EntityConfiguration/typesMap");
const FileManager_1 = require("../Utilities/FileManager");
const removeDuplicates_1 = require("../Utilities/removeDuplicates");
async function FindExpenses() {
    const expensesConfiguration = typesMap_1.availableConfigs['despesas'];
    const expensesUrl = index_1.args.baseIPMUrl + expensesConfiguration.url;
    const expenseLines = await (0, IPMCrawler_1.IPMCrawlerLines)(expensesUrl, expensesConfiguration, index_1.args.credor);
    const expenses = (0, FileManager_1.ConvertCSVLinesToObjects)(expensesConfiguration, expenseLines);
    return expenses;
}
async function FindExtraRevenues() {
    const extraConfiguration = typesMap_1.availableConfigs['extra-despesa-pagamentos'];
    const extraUrl = index_1.args.baseIPMUrl + extraConfiguration.url;
    const extraLines = await (0, IPMCrawler_1.IPMCrawlerLines)(extraUrl, extraConfiguration);
    const extras = (0, FileManager_1.ConvertCSVLinesToObjects)(extraConfiguration, extraLines);
    return extras;
}
async function FindExpenseContent() {
    const expensesInteiro = await FindExpenses();
    const expenses = (0, removeDuplicates_1.removeDuplicates)(expensesInteiro);
    const extrasInteiro = await FindExtraRevenues();
    const extras = (0, removeDuplicates_1.removeDuplicates)(extrasInteiro);
    const objectsInteiro = expenses.concat(extras);
    const objects = (0, removeDuplicates_1.removeDuplicates)(objectsInteiro);
    return JSON.stringify((0, removeDuplicates_1.removeDuplicates)(objects));
}
exports.FindExpenseContent = FindExpenseContent;
//# sourceMappingURL=ExpenseService.js.map