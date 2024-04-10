import { Page } from "puppeteer";
export type CrawlerConfig = {
    url: string;
    ConvertToObject: (...args: string[]) => object;
    ApplyFilter: (page: Page) => Promise<void>;
};
