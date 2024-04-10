"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.removerAcentos = void 0;
async function removerAcentos(str) {
    return str.normalize('NFD').replace(/[\u0300-\u036f]/g, '').replace(/đ/g, 'd').replace(/Đ/g, 'D');
}
exports.removerAcentos = removerAcentos;
//# sourceMappingURL=removerAcentos.js.map