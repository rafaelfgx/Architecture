import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { AppSelectCountryComponent } from "./select-country.component";

@NgModule({
    declarations: [
        AppSelectCountryComponent
    ],
    exports: [
        AppSelectCountryComponent
    ],
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule
    ]
})
export class AppSelectCountryModule { }
