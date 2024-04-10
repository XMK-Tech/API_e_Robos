import { args } from "../../index";
import { FPMCrawlerLines } from "../Crawlers/FPMCrawler";
import { IPMCrawlerLines } from "../Crawlers/IPMCrawler";
import { CrawlerConfig } from "../Types/CrawlerConfig";
import { ConvertCSVLinesToObjects } from "../Utilities/FileManager";

export async function FindContent(command: string, config: CrawlerConfig): Promise<string> {
  let task: string[][];
  if (command == "FPM") {
    const url = await args.baseFPMUrl + config.url;
    task = await FPMCrawlerLines(url, args.cityName, args.startDate, args.endDate);
  }
  else {
    const url = await args.baseIPMUrl + config.url;
    task = await IPMCrawlerLines(url, config);
  }

  const lines = await task;
  const objects = await ConvertCSVLinesToObjects(config, lines);

  return JSON.stringify(objects);
}