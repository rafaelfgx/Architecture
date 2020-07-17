import { Injectable } from "@angular/core";

@Injectable({ providedIn: "root" })
export class AppStorageService {
    any(key: string): boolean {
        return this.get(key) !== null;
    }

    clear(): void {
        sessionStorage.clear();
    }

    get(key: string): string | null {
        return sessionStorage.getItem(key);
    }

    set(key: string, value: string): void {
        sessionStorage.setItem(key, value);
    }
}
