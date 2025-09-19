import { inject } from "@angular/core";
import { CanActivateFn } from "@angular/router";
import AppAuthService from "./services/auth.service";

export const appCanActivate: CanActivateFn = () => {
    const appAuthService = inject(AppAuthService);
    if (appAuthService.authenticated()) { return true; }
    appAuthService.signin();
    return false;
};
