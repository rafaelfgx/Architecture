import { Directive, OnInit } from "@angular/core";
import { AppValidationDirective } from "./validation.directive";

@Directive({ selector: "[appIntegerValidation]" })
export class AppIntegerValidationDirective extends AppValidationDirective implements OnInit {
    ngOnInit() {
        this.cleave = new this.Cleave(this.selector, {
            blocks: [20],
            numericOnly: true
        });
    }
}
