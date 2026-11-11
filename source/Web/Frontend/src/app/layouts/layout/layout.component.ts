import { Component } from "@angular/core";
import { RouterOutlet } from "@angular/router";
import AppFooterComponent from "@layouts/footer/footer.component";
import AppHeaderComponent from "@layouts/header/header.component";

@Component({
    selector: "app-layout",
    templateUrl: "./layout.component.html",
    imports: [
        RouterOutlet,
        AppFooterComponent,
        AppHeaderComponent
    ]
})
export default class AppLayoutComponent { }
