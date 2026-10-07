import { Service } from "@angular/core";
import AppConfiguration from "./configuration";

@Service()
export default class AppConfigurationService {
    configuration!: AppConfiguration;

    async load(): Promise<void> {
        this.configuration = await (await fetch("/assets/configuration.json")).json();
    }
}
