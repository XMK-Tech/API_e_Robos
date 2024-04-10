"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.removeDuplicates = void 0;
function removeDuplicates(array) {
    const uniqueSet = new Set();
    const uniqueObjects = [];
    for (const item of array) {
        const signature = JSON.stringify(item);
        if (!uniqueSet.has(signature)) {
            uniqueSet.add(signature);
            uniqueObjects.push(item);
        }
    }
    return uniqueObjects;
}
exports.removeDuplicates = removeDuplicates;
//# sourceMappingURL=removeDuplicates.js.map