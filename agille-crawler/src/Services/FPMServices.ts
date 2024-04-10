import { FindContent } from "./GenericContentFinder";
import { availableConfigs } from "../EntityConfiguration/typesMap";

export async function FindFPMContent(): Promise<string> {
    return await FindContent('FPM', availableConfigs["banco-do-brasil-fpm"]);
}