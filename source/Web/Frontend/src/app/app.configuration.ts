import { ApplicationConfig, ErrorHandler, inject, provideAppInitializer, provideZonelessChangeDetection } from "@angular/core";
import { provideHttpClient, withInterceptors } from "@angular/common/http";
import { provideSignalFormsConfig } from "@angular/forms/signals";
import { NG_STATUS_CLASSES } from "@angular/forms/signals/compat";
import { PreloadAllModules, provideRouter, withComponentInputBinding, withInMemoryScrolling, withPreloading, withViewTransitions } from "@angular/router";
import { appHttpInterceptor } from "./app.http.interceptor";
import { routes } from "./app.routes";
import AppErrorHandler from "./app.error.handler";
import AppConfigurationService from "./configuration/configuration.service";

export const appConfiguration: ApplicationConfig = {
    providers: [
        provideZonelessChangeDetection(),
        { provide: ErrorHandler, useClass: AppErrorHandler },
        provideAppInitializer(() => inject(AppConfigurationService).load()),
        provideSignalFormsConfig({ classes: NG_STATUS_CLASSES! }),
        provideRouter(
            routes,
            withComponentInputBinding(),
            withViewTransitions(),
            withInMemoryScrolling({ anchorScrolling: "enabled", scrollPositionRestoration: "top" }),
            withPreloading(PreloadAllModules)
        ),
        provideHttpClient(withInterceptors([appHttpInterceptor]))
    ]
};
