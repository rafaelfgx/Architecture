import { Component } from "@angular/core";
import { Meta } from "@angular/platform-browser";
import { environment } from "../environments/environment";

@Component({ selector: "app-root", templateUrl: "./app.component.html" })
export class AppComponent {
    constructor(private readonly meta: Meta) {
        this.meta.addTag({ name: "environment", content: environment.name });
    }
}
