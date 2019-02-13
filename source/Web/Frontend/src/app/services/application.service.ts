import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Cacheable } from "ngx-cacheable";

@Injectable({ providedIn: "root" })
export class AppApplicationService {
    constructor(private readonly http: HttpClient) { }

    @Cacheable()
    get() {
        return this.http.get("Application");
    }
}
