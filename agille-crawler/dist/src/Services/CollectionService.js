"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.FindCollectionContent = void 0;
const index_1 = require("../../index");
const IPMCrawler_1 = require("../Crawlers/IPMCrawler");
const typesMap_1 = require("../EntityConfiguration/typesMap");
const FileManager_1 = require("../Utilities/FileManager");
const IPMCrawlerCollection_1 = require("../Crawlers/IPMCrawlerCollection");
const removeDuplicates_1 = require("../Utilities/removeDuplicates");
function ConvertEffortInAMap(config, lines) {
    var objects = (0, FileManager_1.ConvertCSVLinesToObjects)(config, lines);
    const map = {};
    for (const obj of objects) {
        map[obj.Effort] = obj.Reference;
    }
    return map;
}
async function FindEfforts() {
    const effortConfiguration = typesMap_1.availableConfigs['busca-do-empenho'];
    const effortUrl = index_1.args.baseIPMUrl + effortConfiguration.url;
    const effortLines = await (0, IPMCrawler_1.IPMCrawlerLines)(effortUrl, effortConfiguration);
    const effortMap = ConvertEffortInAMap(effortConfiguration, effortLines);
    return effortMap;
}
async function FindCollections() {
    const collectionConfiguration = typesMap_1.availableConfigs['pagamentos'];
    const collectionUrl = index_1.args.baseIPMUrl + collectionConfiguration.url;
    const collectionLines = await (0, IPMCrawlerCollection_1.IPMCrawlerLinesCollection)(collectionUrl, collectionConfiguration);
    const collectionObjects = (0, FileManager_1.ConvertCSVLinesToObjects)(collectionConfiguration, collectionLines);
    return collectionObjects;
}
async function FindCollectionContent() {
    const effortMap = await FindEfforts();
    const collectionObjects = await FindCollections();
    const objects = [];
    for (const collection of collectionObjects) {
        if (collection.Effort in effortMap) {
            collection.Reference = effortMap[collection.Effort].Reference;
            objects.push(collection);
        }
    }
    return JSON.stringify((0, removeDuplicates_1.removeDuplicates)(objects));
}
exports.FindCollectionContent = FindCollectionContent;
//# sourceMappingURL=CollectionService.js.map