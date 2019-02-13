import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AppCoreModule } from "src/app/core/core.module";
import { AppUploadComponent } from "./upload.component";

const routes: Routes = [
    { path: "", component: AppUploadComponent }
];

@NgModule({
    declarations: [AppUploadComponent],
    imports: [
        RouterModule.forChild(routes),
        AppCoreModule
    ]
})
export class AppUploadModule { }
