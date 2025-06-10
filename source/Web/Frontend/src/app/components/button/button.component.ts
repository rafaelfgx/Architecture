import { Component, Input } from "@angular/core";

@Component({
    selector: "app-button",
    templateUrl: "./button.component.html"
})
export default class AppButtonComponent {
    @Input() disabled = false;
    @Input() text!: string;
}
