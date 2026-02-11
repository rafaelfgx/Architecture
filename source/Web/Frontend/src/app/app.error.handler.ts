import { HttpErrorResponse } from "@angular/common/http";
import { ErrorHandler, Injectable } from "@angular/core";
import AppModalService from "./services/modal.service";

@Injectable({ providedIn: "root" })
export default class AppErrorHandler implements ErrorHandler {
    constructor(private readonly appModalService: AppModalService) { }

    handleError(error: any) {
        if (error instanceof HttpErrorResponse && error.error) {
            this.appModalService.alert(error.error);
        }
    }
}
