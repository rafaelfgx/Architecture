import { CommonModule } from "@angular/common";
import { Component, Input } from "@angular/core";
import { FormsModule, ReactiveFormsModule, NG_VALUE_ACCESSOR } from "@angular/forms";
import { WattTextFieldComponent } from "@energinet/watt/text-field";
import AppInputComponent from "./input.component";

@Component({
    selector: "app-input-text",
    templateUrl: "./input.component.html",
    providers: [{ provide: NG_VALUE_ACCESSOR, useExisting: AppInputTextComponent, multi: true }],
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        WattTextFieldComponent
    ],
    standalone: true
})
export default class AppInputTextComponent extends AppInputComponent {
    @Input() autofocus = false;
    @Input() class!: string;
    @Input() disabled = false;
    @Input() formControlName!: string;
    @Input() text!: string;

    constructor() {
        super("text");
    }
}
