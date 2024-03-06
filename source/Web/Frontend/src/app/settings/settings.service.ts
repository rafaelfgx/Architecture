import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { SettingsModel } from "./settings.model";

@Injectable({ providedIn: "root" })
export class AppSettingsService {
    settings!: SettingsModel;

    constructor(private http: HttpClient) {
        this.http.get<SettingsModel>("./assets/settings.json").subscribe((settings) => this.settings = settings);
    }
}
