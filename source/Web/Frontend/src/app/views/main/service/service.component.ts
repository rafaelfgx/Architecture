import { HttpClient } from "@angular/common/http";
import { Component } from "@angular/core";
import { Cacheable } from "ngx-cacheable";

@Component({ selector: "app-service", templateUrl: "./service.component.html" })
export class AppServiceComponent {
    list: any;

    constructor(private readonly http: HttpClient) {
        this.get().subscribe((response: any) => this.list = response);
    }

    @Cacheable()
    get() {
        return this.http.get("https://jsonplaceholder.typicode.com/users");
    }
}
