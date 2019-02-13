import { Component } from "@angular/core";
import { SignInModel } from "src/app/models/signIn.model";
import { AppAuthenticationService } from "src/app/services/authentication.service";

@Component({ selector: "app-login", templateUrl: "./login.component.html" })
export class AppLoginComponent {
    signInModel = new SignInModel();

    constructor(private readonly appAuthenticationService: AppAuthenticationService) {
        this.signInModel.login = "admin";
        this.signInModel.password = "admin";
    }

    ngSubmit() {
        this.appAuthenticationService.signIn(this.signInModel);
    }
}
