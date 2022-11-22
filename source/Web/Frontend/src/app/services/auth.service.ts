import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { AuthModel } from "src/app/models/auth.model";

@Injectable({ providedIn: "root" })
export class AppAuthService {
    constructor(
        private readonly http: HttpClient,
        private readonly router: Router) { }

    authenticated = () => !!this.token();

    auth(auth: AuthModel): void {
        this.http
            .post("auths", auth)
            .subscribe((result: any) => {
                if (!result || !result.token) return;
                localStorage.setItem("token", result.token);
                this.router.navigate(["/main/home"]);
            });
    }

    signin = () => this.router.navigate(["/auth"]);

    signout() {
        localStorage.clear();
        this.signin();
    }

    token = () => localStorage.getItem("token");
}
