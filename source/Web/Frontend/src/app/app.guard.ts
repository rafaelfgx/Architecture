import { Injectable } from "@angular/core";
import { AppAuthService } from "./services/auth.service";

@Injectable({ providedIn: "root" })
export class AppGuard {
    constructor(private readonly appAuthService: AppAuthService) { }

    canActivate() {
        if (this.appAuthService.authenticated()) { return true; }
        this.appAuthService.signin();
        return false;
    }
}
