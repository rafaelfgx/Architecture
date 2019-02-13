import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { AppTokenService } from "../core/services/token.service";
import { SignInModel } from "../models/signIn.model";

@Injectable({ providedIn: "root" })
export class AppAuthenticationService {
    constructor(
        private readonly http: HttpClient,
        private readonly router: Router,
        private readonly appTokenService: AppTokenService) { }

    signIn(signInModel: SignInModel): void {
        this.http
            .post(`Authentication/SignIn`, signInModel, { responseType: "text" })
            .subscribe((token: string) => {
                this.appTokenService.set(token);
                this.router.navigate(["/main/home"]);
            });
    }

    signOut() {
        if (this.appTokenService.any()) {
            this.http.post(`Authentication/SignOutAsync`, {}).subscribe();
        }

        this.appTokenService.clear();
        this.router.navigate(["/login"]);
    }
}
