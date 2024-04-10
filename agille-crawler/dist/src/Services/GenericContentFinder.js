"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.FindContent = void 0;
const index_1 = require("../../index");
const FPMCrawler_1 = require("../Crawlers/FPMCrawler");
const IPMCrawler_1 = require("../Crawlers/IPMCrawler");
const FileManager_1 = require("../Utilities/FileManager");
async function FindContent(command, config) {
    let task;
    if (command == "FPM") {
        const url = await index_1.args.baseFPMUrl + config.url;
        task = await (0, FPMCrawler_1.FPMCrawlerLines)(url, index_1.args.cityName, index_1.args.startDate, index_1.args.endDate);
    }
    else {
        const url = await index_1.args.baseIPMUrl + config.url;
        task = await (0, IPMCrawler_1.IPMCrawlerLines)(url, config);
    }
    const lines = await task;
    const objects = await (0, FileManager_1.ConvertCSVLinesToObjects)(config, lines);
    return JSON.stringify(objects);
}
exports.FindContent = FindContent;
//# sourceMappingURL=GenericContentFinder.js.map