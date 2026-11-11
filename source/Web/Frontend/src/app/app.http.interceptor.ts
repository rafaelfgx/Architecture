import { ErrorHandler, inject } from "@angular/core";
import { HttpInterceptorFn } from "@angular/common/http";
import { tap } from "rxjs";
import AppAuthService from "./services/auth.service";

export const appHttpInterceptor: HttpInterceptorFn = (request, next) => {
    if (!/^\/?api\//.test(request.url)) return next(request);

    request = request.clone({ setHeaders: { Authorization: `Bearer ${inject(AppAuthService).token()}` } });

    const errorHandler = inject(ErrorHandler);
    return next(request).pipe(tap({ error: (error) => errorHandler.handleError(error) }));
};
