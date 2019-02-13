import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AppCoreModule } from "src/app/core/core.module";
import { AppHomeComponent } from "./home.component";

const routes: Routes = [
    { path: "", component: AppHomeComponent }
];

@NgModule({
    declarations: [AppHomeComponent],
    imports: [
        RouterModule.forChild(routes),
        AppCoreModule
    ]
})
export class AppHomeModule { }
