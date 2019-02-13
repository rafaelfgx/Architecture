import { Component, Input } from "@angular/core";
import { NG_VALUE_ACCESSOR } from "@angular/forms";
import { AppBaseComponent } from "../base/base.component";

@Component({
    providers: [{ provide: NG_VALUE_ACCESSOR, useExisting: AppInputComponent, multi: true }],
    selector: "app-input",
    templateUrl: "./input.component.html"
})
export class AppInputComponent extends AppBaseComponent {
    @Input() type: string;
}
