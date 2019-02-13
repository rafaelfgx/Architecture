import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { AppCurrencyValidationDirective } from "./currency.directive";
import { AppDateValidationDirective } from "./date.directive";
import { AppDecimalValidationDirective } from "./decimal.directive";
import { AppIntegerValidationDirective } from "./integer.directive";

@NgModule({
    declarations: [
        AppCurrencyValidationDirective,
        AppDateValidationDirective,
        AppDecimalValidationDirective,
        AppIntegerValidationDirective
    ],
    exports: [
        AppCurrencyValidationDirective,
        AppDateValidationDirective,
        AppDecimalValidationDirective,
        AppIntegerValidationDirective
    ],
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule
    ]
})
export class AppValidationModule { }
