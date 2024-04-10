import * as fs from 'fs';
import { args } from "../../index";
import { CrawlerConfig } from '../Types/CrawlerConfig';
import path = require('path');
import { Page } from 'puppeteer';



export function TakeFileFromDowloadFolder() {
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

    console.log(csvData)

    DeleteFile(path);

    return csvData;
}

function DeleteFile(path: string) {
    fs.unlink(path, () => { });
}

function sanitizeField(field: string) {
    return field
        .replace(/"/g, '')
        .replace(/\s+/g, ' ')
        .replace(/\n{1,}/g, '');
}

export function SaveFile(name: string, content: string) {
    const formattedReference: string = args.startDate.replace(/\//g, '-');
    const directory = process.cwd() + "\\documents\\" + formattedReference;
    const filePath = directory + "\\" + name + ".json";

    if (!fs.existsSync(directory))
        fs.mkdirSync(directory, { recursive: true });

    fs.writeFileSync(filePath, content)
}

export function ConvertCSVLinesToObjects(config: CrawlerConfig, lines: string[][]) {
    const objects = [];

    for (let i = 0; i < lines.length; i++) {
        const line = lines[i];
        const object = config.ConvertToObject(args.cityName, ...line);

        if (object != null) objects.push(object);
    }

    return objects;
}

export function WriteError(str: string) {
    console.error("Um erro foi salvo em log.txt");
    
    const errorFile = path.join(__dirname, '../../../log.txt');

    return new Promise<void>((resolve, reject) => {
        fs.appendFile(errorFile, `[Erro] ${new Date().toLocaleString()}: ${str}\n`, err => {
            resolve();
            if (err) {
                console.error('Erro ao escrever no arquivo:', err);
            }
        });
    });
}

export async function SaveCookies(page: Page) {
    const cookies = await page.cookies();
    const cookieFile = path.join(__dirname, '../../../cookies.json');
    fs.writeFileSync(cookieFile, JSON.stringify(cookies));
}

export async function LoadCookies(page: Page) {
    const cookieFile = path.join(__dirname, '../../../cookies.json');

    if (!fs.existsSync(cookieFile))
        return;

    const cookiesString = fs.readFileSync(cookieFile, 'utf-8');
    const cookies = JSON.parse(cookiesString);

    await page.setCookie(...cookies);
}