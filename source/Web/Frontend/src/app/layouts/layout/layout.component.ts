import { Component } from "@angular/core";
import { RouterModule } from "@angular/router";
import AppFooterComponent from "@layouts/footer/footer.component";
import AppHeaderComponent from "@layouts/header/header.component";

@Component({
    selector: "app-layout",
    templateUrl: "./layout.component.html",
    imports: [
        RouterModule,
        AppFooterComponent,
        AppHeaderComponent
    ]
})
export default class AppLayoutComponent { }
