import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AppCoreModule } from "src/app/core/core.module";
import { AppValidationModule } from "src/app/directives/validation/validation.module";
import { AppValidateComponent } from "./validate.component";

const routes: Routes = [
    { path: "", component: AppValidateComponent }
];

@NgModule({
    declarations: [AppValidateComponent],
    imports: [
        RouterModule.forChild(routes),
        AppCoreModule,
        AppValidationModule
    ]
})
export class AppValidateModule { }
