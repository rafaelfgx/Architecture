import { inject } from "@angular/core";
import { CanActivateFn, Router } from "@angular/router";
import AppAuthService from "./services/auth.service";

export const appCanActivate: CanActivateFn = () => inject(AppAuthService).authenticated() || inject(Router).createUrlTree(["/"]);
