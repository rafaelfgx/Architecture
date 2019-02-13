import { ErrorHandler, Injectable, Injector } from "@angular/core";
import { Router } from "@angular/router";
import { AppModalService } from "../services/modal.service";

@Injectable()
export class AppErrorHandler implements ErrorHandler {
    constructor(private readonly injector: Injector) { }

    handleError(error: any) {
        if (!error.status) { return; }

        const appModalService = this.injector.get(AppModalService);
        const router = this.injector.get(Router);

        switch (error.status) {
            case 401: {
                router.navigate(["/login"]);
                break;
            }
            case 422: {
                appModalService.alert(error.error);
                break;
            }
            default: {
                console.error(error);
                break;
            }
        }
    }
}
