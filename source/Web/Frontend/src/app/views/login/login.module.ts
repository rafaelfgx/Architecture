import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AppCoreModule } from "src/app/core/core.module";
import { AppLoginComponent } from "./login.component";

const routes: Routes = [
    { path: "", component: AppLoginComponent }
];

@NgModule({
    declarations: [AppLoginComponent],
    imports: [
        RouterModule.forChild(routes),
        AppCoreModule
    ]
})
export class AppLoginModule { }
