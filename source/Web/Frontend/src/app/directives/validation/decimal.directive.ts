import { Directive, HostListener, OnInit } from "@angular/core";
import { AppValidationDirective } from "./validation.directive";

@Directive({ selector: "[appDecimalValidation]" })
export class AppDecimalValidationDirective extends AppValidationDirective implements OnInit {
    ngOnInit() {
        this.cleave = new this.Cleave(this.selector, {
            delimiter: ".",
            numeral: true,
            numeralDecimalMark: ",",
            numeralDecimalScale: 2,
            numeralIntegerScale: 20,
        });
    }

    @HostListener("blur") onBlur() { this.setRawValue(); }
}
