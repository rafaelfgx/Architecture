import { Component, Input } from "@angular/core";

@Component({
    selector: "app-label",
    templateUrl: "./label.component.html",
    standalone: true
})
export class AppLabelComponent {
    @Input() for!: string;
    @Input() text!: string;
}
