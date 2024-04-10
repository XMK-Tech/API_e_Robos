"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.args = void 0;
const date_fns_1 = require("date-fns");
const ExpenseService_1 = require("./src/Services/ExpenseService");
const RevenueService_1 = require("./src/Services/RevenueService");
const CollectionService_1 = require("./src/Services/CollectionService");
const FPMServices_1 = require("./src/Services/FPMServices");
const fs = require('fs');
const path = require('path');
exports.args = {
    baseIPMUrl: 'https://cascavel.atende.net/transparencia/item/',
    baseFPMUrl: 'https://www42.bb.com.br/portalbb/daf/beneficiario,802,4647,4652,0,1.bbx',
    cityName: "Cascavel",
    sanitizedName: "cascavel",
    cityComand: 'Cascavel - PR',
    Documents: '81.269.169/0001-43',
    reference: '01/01/2019',
    Document: '00.394.460/0001-41',
    Creditor: 'MINISTÉRIO DA ECONOMIA',
    ExpenseDescription: 'Contribuição para o PIS/PASEP',
    action: 'revenue'
};
const reference = exports.args.reference;
const data = (0, date_fns_1.parse)(reference, 'dd/MM/yyyy', new Date());
exports.args.startDate = (0, date_fns_1.format)((0, date_fns_1.startOfMonth)(data), 'dd/MM/yyyy');
exports.args.endDate = (0, date_fns_1.format)((0, date_fns_1.endOfMonth)(data), 'dd/MM/yyyy');
exports.args.yarnEndDate = (0, date_fns_1.format)(new Date(data), 'yyyy');
function formatDate(dateString) {
    return dateString.split('/').join('');
}
exports.args.nameTxt = formatDate(exports.args.reference);
function DefineActionToPerform() {
    switch (exports.args.action) {
        case 'fpm':
            return FPMServices_1.FindFPMContent;
        case 'expense':
            return ExpenseService_1.FindExpenseContent;
        case 'collection':
            return CollectionService_1.FindCollectionContent;
        case 'revenue':
            return RevenueService_1.FindRevenueContent;
        default:
            return undefined;
    }
}
async function FindAllContent() {
    const action = DefineActionToPerform();
    if (action === undefined)
        return undefined;
    return await action();
}
FindAllContent()
    .then((data) => {
    console.log(data);
    const dirPath = path.join(`importacao/${exports.args.action}/${exports.args.yarnEndDate}`);
    const filePath = path.join(dirPath, `${exports.args.nameTxt}-${exports.args.action}.txt`);
    fs.mkdir(dirPath, { recursive: true }, (err) => {
        if (err) {
            console.error('Erro ao criar o diretório:', err);
            return;
        }
        fs.writeFile(filePath, data, (err) => {
            if (err) {
                console.error('Erro ao salvar o arquivo:', err);
                return -1;
            }
            console.log('Dados salvos com sucesso em dados.txt');
            return 0;
        });
    });
}).catch((error) => {
    console.error('Erro durante a execução:', error);
    return -1;
});
//# sourceMappingURL=index.js.map