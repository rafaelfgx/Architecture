import { Component, input } from "@angular/core";

@Component({
    selector: "app-button",
    templateUrl: "./button.component.html"
})
export default class AppButtonComponent {
    readonly disabled = input(false);
    readonly id = input.required<string>();
    readonly text = input.required<string>();
    readonly type = input<"button" | "submit" | "reset">("button");
}
