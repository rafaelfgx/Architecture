import { Component, input } from "@angular/core";

@Component({
    selector: "app-label",
    templateUrl: "./label.component.html"
})
export default class AppLabelComponent {
    readonly for = input.required<string>();
    readonly text = input.required<string>();
}
