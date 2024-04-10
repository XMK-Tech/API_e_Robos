"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.FindFPMContent = void 0;
const GenericContentFinder_1 = require("./GenericContentFinder");
const typesMap_1 = require("../EntityConfiguration/typesMap");
async function FindFPMContent() {
    return await (0, GenericContentFinder_1.FindContent)('FPM', typesMap_1.availableConfigs["banco-do-brasil-fpm"]);
}
exports.FindFPMContent = FindFPMContent;
//# sourceMappingURL=FPMServices.js.map