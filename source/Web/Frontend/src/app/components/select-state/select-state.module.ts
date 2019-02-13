import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { AppSelectStateComponent } from "./select-state.component";

@NgModule({
    declarations: [
        AppSelectStateComponent
    ],
    exports: [
        AppSelectStateComponent
    ],
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule
    ]
})
export class AppSelectStateModule { }
