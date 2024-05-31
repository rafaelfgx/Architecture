import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import AppAuth from "src/app/models/auth";

@Injectable({ providedIn: "root" })
export default class AppAuthService {
    constructor(
        private readonly http: HttpClient,
        private readonly router: Router) { }

    authenticated = () => !!this.token();

    auth(auth: AppAuth): void {
        this.http
            .post("api/auths", auth)
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
