"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.FindRevenueContent = void 0;
const GenericContentFinder_1 = require("./GenericContentFinder");
const typesMap_1 = require("../EntityConfiguration/typesMap");
async function FindRevenueContent() {
    return await (0, GenericContentFinder_1.FindContent)('IPM', typesMap_1.availableConfigs["receitas-orcamentarias"]);
}
exports.FindRevenueContent = FindRevenueContent;
//# sourceMappingURL=RevenueService.js.map