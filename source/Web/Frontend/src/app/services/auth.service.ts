import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { AppStorageService } from "src/app/core/services/storage.service";
import { SignInModel } from "src/app/models/signIn.model";
import { TokenModel } from "src/app/models/token.model";

@Injectable({ providedIn: "root" })
export class AppAuthService {
    constructor(
        private readonly http: HttpClient,
        private readonly router: Router,
        private readonly appStorageService: AppStorageService) { }

    signin(model: SignInModel): void {
        this.http
            .post<TokenModel>("auths", model)
            .subscribe((result) => {
                if (!result || !result.token) { return; }
                this.appStorageService.set("token", result.token);
                this.router.navigate(["/main/home"]);
            });
    }

    signout() {
        this.appStorageService.clear();
        this.router.navigate(["/login"]);
    }
}
