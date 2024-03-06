import { CommonModule } from "@angular/common";
import { Component, inject } from "@angular/core";
import { FormBuilder, ReactiveFormsModule, Validators } from "@angular/forms";
import { AppAuthService } from "src/app/services/auth.service";
import { AppButtonComponent } from "src/app/components/button/button.component";
import { AppInputPasswordComponent } from "src/app/components/input/password.input.component";
import { AppInputTextComponent } from "src/app/components/input/text.input.component";
import { AppLabelComponent } from "src/app/components/label/label.component";
import { AuthModel } from "src/app/models/auth.model";

@Component({
    selector: "app-auth",
    templateUrl: "./auth.component.html",
    standalone: true,
    imports: [
        CommonModule,
        ReactiveFormsModule,
        AppButtonComponent,
        AppInputPasswordComponent,
        AppInputTextComponent,
        AppLabelComponent
    ]
})
export class AppAuthComponent {
    form = inject(FormBuilder).group({
        login: ["admin", Validators.required],
        password: ["admin", Validators.required]
    });

    constructor(private readonly appAuthService: AppAuthService) { }

    auth() {
        this.appAuthService.auth(this.form.value as AuthModel);
    }
}
