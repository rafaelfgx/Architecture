import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { AppFooterComponent } from "./footer/footer.component";
import { AppHeaderComponent } from "./header/header.component";
import { AppLayoutMainComponent } from "./layout-main.component";
import { AppLayoutComponent } from "./layout.component";
import { AppMainComponent } from "./main/main.component";
import { AppNavComponent } from "./nav/nav.component";

@NgModule({
    declarations: [
        AppFooterComponent,
        AppHeaderComponent,
        AppLayoutComponent,
        AppLayoutMainComponent,
        AppMainComponent,
        AppNavComponent
    ],
    imports: [RouterModule]
})
export class AppLayoutsModule { }
