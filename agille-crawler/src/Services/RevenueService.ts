import { FindContent } from "./GenericContentFinder";
import { availableConfigs } from "../EntityConfiguration/typesMap";

export async function FindRevenueContent(): Promise<string> {
    return await FindContent('IPM', availableConfigs["receitas-orcamentarias"]);
}