import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AppCoreModule } from "src/app/core/core.module";
import { AppServiceComponent } from "./service.component";

const routes: Routes = [
    { path: "", component: AppServiceComponent }
];

@NgModule({
    declarations: [AppServiceComponent],
    imports: [
        RouterModule.forChild(routes),
        AppCoreModule
    ]
})
export class AppServiceModule { }
