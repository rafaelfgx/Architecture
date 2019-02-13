import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { AppInputComponent } from "./input.component";

@NgModule({
    declarations: [
        AppInputComponent
    ],
    exports: [
        AppInputComponent
    ],
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule
    ]
})
export class AppInputModule { }
