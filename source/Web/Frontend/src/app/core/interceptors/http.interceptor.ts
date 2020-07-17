import { HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { AppStorageService } from "src/app/core/services/storage.service";

@Injectable({ providedIn: "root" })
export class AppHttpInterceptor implements HttpInterceptor {
    constructor(private readonly appStorageService: AppStorageService) { }

    intercept(request: HttpRequest<any>, next: HttpHandler) {
        const token = this.appStorageService.get("token");

        request = request.clone({
            setHeaders: { Authorization: `Bearer ${token}` }
        });

        return next.handle(request);
    }
}
