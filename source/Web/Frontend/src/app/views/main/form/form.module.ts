import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AppSelectCityModule } from "src/app/components/select-city/select-city.module";
import { AppSelectCountryModule } from "src/app/components/select-country/select-country.module";
import { AppSelectStateModule } from "src/app/components/select-state/select-state.module";
import { AppCoreModule } from "src/app/core/core.module";
import { AppFormComponent } from "./form.component";

const routes: Routes = [
    { path: "", component: AppFormComponent }
];

@NgModule({
    declarations: [AppFormComponent],
    imports: [
        RouterModule.forChild(routes),
        AppCoreModule,
        AppSelectCountryModule,
        AppSelectStateModule,
        AppSelectCityModule
    ]
})
export class AppFormModule { }
