import { Component } from "@angular/core";
import { RouterModule } from "@angular/router";
import { AppFooterComponent } from "src/app/layouts/footer/footer.component";
import { AppHeaderComponent } from "src/app/layouts/header/header.component";
import { AppNavComponent } from "src/app/layouts/nav/nav.component";

@Component({
    selector: "app-layout-nav",
    templateUrl: "./layout-nav.component.html",
    standalone: true,
    imports: [
        RouterModule,
        AppFooterComponent,
        AppHeaderComponent,
        AppNavComponent
    ]
})
export class AppLayoutNavComponent { }
