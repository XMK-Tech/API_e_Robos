"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.LoadCookies = exports.SaveCookies = exports.WriteError = exports.ConvertCSVLinesToObjects = exports.SaveFile = exports.TakeFileFromDowloadFolder = void 0;
const fs = require("fs");
const index_1 = require("../../index");
const path = require("path");
function TakeFileFromDowloadFolder() {
    const path = './downloads/Relatório.csv';
    if (!fs.existsSync(path)) {
        return [];
    }
    const fileContent = fs.readFileSync(path, 'latin1');
    const lines = fileContent.split('\n');
    const csvData = [];
    for (const line of lines) {
        const values = line.split(';');
        const sanitizedLine = values.map((field) => sanitizeField(field));
        csvData.push(sanitizedLine);
    }
    console.log(csvData);
    DeleteFile(path);
    return csvData;
}
exports.TakeFileFromDowloadFolder = TakeFileFromDowloadFolder;
function DeleteFile(path) {
    fs.unlink(path, () => { });
}
function sanitizeField(field) {
    return field
        .replace(/"/g, '')
        .replace(/\s+/g, ' ')
        .replace(/\n{1,}/g, '');
}
function SaveFile(name, content) {
    const formattedReference = index_1.args.startDate.replace(/\//g, '-');
    const directory = process.cwd() + "\\documents\\" + formattedReference;
    const filePath = directory + "\\" + name + ".json";
    if (!fs.existsSync(directory))
        fs.mkdirSync(directory, { recursive: true });
    fs.writeFileSync(filePath, content);
}
exports.SaveFile = SaveFile;
function ConvertCSVLinesToObjects(config, lines) {
    const objects = [];
    for (let i = 0; i < lines.length; i++) {
        const line = lines[i];
        const object = config.ConvertToObject(index_1.args.cityName, ...line);
        if (object != null)
            objects.push(object);
    }
    return objects;
}
exports.ConvertCSVLinesToObjects = ConvertCSVLinesToObjects;
function WriteError(str) {
    console.error("Um erro foi salvo em log.txt");
    const errorFile = path.join(__dirname, '../../../log.txt');
    return new Promise((resolve, reject) => {
        fs.appendFile(errorFile, `[Erro] ${new Date().toLocaleString()}: ${str}\n`, err => {
            resolve();
            if (err) {
                console.error('Erro ao escrever no arquivo:', err);
            }
        });
    });
}
exports.WriteError = WriteError;
async function SaveCookies(page) {
    const cookies = await page.cookies();
    const cookieFile = path.join(__dirname, '../../../cookies.json');
    fs.writeFileSync(cookieFile, JSON.stringify(cookies));
}
exports.SaveCookies = SaveCookies;
async function LoadCookies(page) {
    const cookieFile = path.join(__dirname, '../../../cookies.json');
    if (!fs.existsSync(cookieFile))
        return;
    const cookiesString = fs.readFileSync(cookieFile, 'utf-8');
    const cookies = JSON.parse(cookiesString);
    await page.setCookie(...cookies);
}
exports.LoadCookies = LoadCookies;
//# sourceMappingURL=FileManager.js.map