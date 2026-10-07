import { HttpErrorResponse } from "@angular/common/http";
import { ErrorHandler, Service, inject } from "@angular/core";
import AppModalService from "./services/modal.service";

@Service()
export default class AppErrorHandler implements ErrorHandler {
    private readonly appModalService = inject(AppModalService);

    handleError(error: unknown): void {
        if (error instanceof HttpErrorResponse) {
            this.appModalService.alert(error.error);
            return;
        }

        console.error(error);
    }
}
