import { Directive, OnInit } from "@angular/core";
import { AppValidationDirective } from "./validation.directive";

@Directive({ selector: "[appDateValidation]" })
export class AppDateValidationDirective extends AppValidationDirective implements OnInit {
    ngOnInit() {
        this.cleave = new this.Cleave(this.selector, {
            date: true,
            datePattern: ["d", "m", "Y"]
        });
    }
}
