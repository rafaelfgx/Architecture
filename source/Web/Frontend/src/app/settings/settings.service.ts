import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import AppSettings from "./settings";

@Injectable({ providedIn: "root" })
export default class AppSettingsService {
    settings!: AppSettings;

    constructor(private http: HttpClient) {
        this.http.get<AppSettings>("./assets/settings.json").subscribe((settings) => this.settings = settings);
    }
}
