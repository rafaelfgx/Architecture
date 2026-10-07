import { HttpClient } from "@angular/common/http";
import { Service, inject } from "@angular/core";
import { Router } from "@angular/router";
import { firstValueFrom } from "rxjs";
import AppAuthRequest from "@app/dtos/auth.request";
import AppAuthResponse from "@app/dtos/auth.response";

@Service()
export default class AppAuthService {
    private readonly http = inject(HttpClient);
    private readonly router = inject(Router);

    async signin(request: AppAuthRequest): Promise<void> {
        const response = await firstValueFrom(this.http.post<AppAuthResponse>("/api/auth", request));
        localStorage.setItem("token", response.token);
        await this.router.navigateByUrl("/main/home");
    }

    signout(): void {
        localStorage.clear();
        this.router.navigateByUrl("/");
    }

    token = () => localStorage.getItem("token");

    authenticated = () => Boolean(this.token());
}
