import { Component } from "@angular/core";
import AppInputComponent from "./input.component";

@Component({
    selector: "app-input-password",
    templateUrl: "./input.component.html"
})
export default class AppInputPasswordComponent extends AppInputComponent {
    override readonly type = "password";
}
