"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.removeDuplicateArrays = void 0;
function removeDuplicateArrays(arrays) {
    const uniqueStringArrays = new Set(arrays.map(array => JSON.stringify(array)));
    return Array.from(uniqueStringArrays).map(stringArray => JSON.parse(stringArray));
}
exports.removeDuplicateArrays = removeDuplicateArrays;
//# sourceMappingURL=removeDuplicateArrays.js.map