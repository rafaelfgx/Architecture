import { CommonModule } from "@angular/common";
import { Component, inject } from "@angular/core";
import { FormBuilder, ReactiveFormsModule, Validators } from "@angular/forms";
import AppAuthService from "@services/auth.service";
import AppButtonComponent from "@components/button/button.component";
import AppInputPasswordComponent from "@components/input/password.input.component";
import AppInputTextComponent from "@components/input/text.input.component";
import AppLabelComponent from "@components/label/label.component";
import AppAuth from "@models/auth";

@Component({
    selector: "app-auth",
    templateUrl: "./auth.component.html",
    imports: [
        CommonModule,
        ReactiveFormsModule,
        AppButtonComponent,
        AppInputPasswordComponent,
        AppInputTextComponent,
        AppLabelComponent
    ]
})
export default class AppAuthComponent {
    form = inject(FormBuilder).group({
        login: ["admin", Validators.required],
        password: ["admin", Validators.required]
    });

    constructor(private readonly appAuthService: AppAuthService) { }

    auth() {
        this.appAuthService.auth(this.form.value as AppAuth);
    }
}
