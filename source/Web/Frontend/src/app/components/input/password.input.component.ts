import { CommonModule } from "@angular/common";
import { Component, Input } from "@angular/core";
import { FormsModule, ReactiveFormsModule, NG_VALUE_ACCESSOR } from "@angular/forms";
import { AppInputComponent } from "./input.component";

@Component({
    selector: "app-input-password",
    templateUrl: "./input.component.html",
    standalone: true,
    providers: [{ provide: NG_VALUE_ACCESSOR, useExisting: AppInputPasswordComponent, multi: true }],
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule
    ]
})
export class AppInputPasswordComponent extends AppInputComponent {
    @Input() autofocus = false;
    @Input() class!: string;
    @Input() disabled = false;
    @Input() formControlName!: string;
    @Input() text!: string;

    constructor() {
        super("password");
    }
}
