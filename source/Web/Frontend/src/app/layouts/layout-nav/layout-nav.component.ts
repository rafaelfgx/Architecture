import { Component } from "@angular/core";
import { RouterModule } from "@angular/router";
import AppFooterComponent from "@layouts/footer/footer.component";
import AppHeaderComponent from "@layouts/header/header.component";
import AppNavComponent from "@layouts/nav/nav.component";

@Component({
    selector: "app-layout-nav",
    templateUrl: "./layout-nav.component.html",
    imports: [
        RouterModule,
        AppFooterComponent,
        AppHeaderComponent,
        AppNavComponent
    ]
})
export default class AppLayoutNavComponent { }
