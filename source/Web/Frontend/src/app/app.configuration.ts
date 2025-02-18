import { APP_INITIALIZER, ApplicationConfig, ErrorHandler, provideZoneChangeDetection } from '@angular/core';
import { provideHttpClient, withInterceptors } from "@angular/common/http";
import { provideRouter } from '@angular/router';
import { appHttpInterceptor } from "./app.http.interceptor";
import { routes } from "./app.routes";
import AppErrorHandler from "./app.error.handler";
import AppSettingsService from "./settings/settings.service";

export const appConfiguration: ApplicationConfig = {
    providers: [
        provideZoneChangeDetection({ eventCoalescing: true }),
        { provide: ErrorHandler, useClass: AppErrorHandler },
        { provide: APP_INITIALIZER, deps: [AppSettingsService], useFactory: () => () => { }, multi: true },
        provideRouter(routes),
        provideHttpClient(withInterceptors([appHttpInterceptor]))
    ]
};
