import { CrawlerConfig } from '../Types/CrawlerConfig';
import { Page } from 'puppeteer';
export declare function TakeFileFromDowloadFolder(): any[];
export declare function SaveFile(name: string, content: string): void;
export declare function ConvertCSVLinesToObjects(config: CrawlerConfig, lines: string[][]): any[];
export declare function WriteError(str: string): Promise<void>;
export declare function SaveCookies(page: Page): Promise<void>;
export declare function LoadCookies(page: Page): Promise<void>;
