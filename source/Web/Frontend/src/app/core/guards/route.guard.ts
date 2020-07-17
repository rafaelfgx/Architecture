import { Injectable } from "@angular/core";
import { CanActivate, Router } from "@angular/router";
import { AppStorageService } from "src/app/core/services/storage.service";

@Injectable({ providedIn: "root" })
export class AppRouteGuard implements CanActivate {
    constructor(
        private readonly router: Router,
        private readonly appStorageService: AppStorageService) { }

    canActivate() {
        if (this.appStorageService.any("token")) { return true; }
        this.router.navigate(["/login"]);
        return false;
    }
}
