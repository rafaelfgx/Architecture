import { Injectable } from "@angular/core";

@Injectable({ providedIn: "root" })
export class AppTokenService {
    private token = "token";

    clear(): void {
        sessionStorage.removeItem(this.token);
    }

    any(): boolean {
        return this.get() !== null;
    }

    get(): string {
        return sessionStorage.getItem(this.token);
    }

    set(token: string): void {
        sessionStorage.setItem(this.token, token);
    }
}
