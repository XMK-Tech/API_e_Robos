import { args } from "../../index";
import { CrawlerConfig } from "../Types/CrawlerConfig";
import { IPMCrawlerLines } from "../Crawlers/IPMCrawler";
import { availableConfigs } from "../EntityConfiguration/typesMap";
import { ConvertCSVLinesToObjects } from "../Utilities/FileManager";
import { IPMCrawlerLinesCollection } from "../Crawlers/IPMCrawlerCollection";
import { removeDuplicates } from "../Utilities/removeDuplicates";

function ConvertEffortInAMap(config: CrawlerConfig, lines: string[][]) {
    var objects = ConvertCSVLinesToObjects(config, lines);

    const map = {};

    for (const obj of objects) {
        map[obj.Effort] = obj.Reference;
    }

    return map;
}

async function FindEfforts() {
    const effortConfiguration = availableConfigs['busca-do-empenho'];

    const effortUrl = args.baseIPMUrl + effortConfiguration.url;
    const effortLines = await IPMCrawlerLines(effortUrl, effortConfiguration);
    const effortMap = ConvertEffortInAMap(effortConfiguration, effortLines);

    return effortMap;
}

async function FindCollections() {
    const collectionConfiguration = availableConfigs['pagamentos'];

    const collectionUrl = args.baseIPMUrl + collectionConfiguration.url;
    const collectionLines = await IPMCrawlerLinesCollection(collectionUrl, collectionConfiguration);
    const collectionObjects = ConvertCSVLinesToObjects(collectionConfiguration, collectionLines);

    return collectionObjects;
}

export async function FindCollectionContent(): Promise<string> {
    const effortMap = await FindEfforts();
    const collectionObjects = await FindCollections();

    const objects = [];

    for (const collection of collectionObjects) {
        if (collection.Effort in effortMap) {
            collection.Reference = effortMap[collection.Effort].Reference;
            objects.push(collection);
        }
    }

    return JSON.stringify(removeDuplicates(objects));
}