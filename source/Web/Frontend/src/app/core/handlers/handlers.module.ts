import { ErrorHandler, NgModule } from "@angular/core";
import { AppErrorHandler } from "./error.handler";

@NgModule({
    providers: [
        { provide: ErrorHandler, useClass: AppErrorHandler }
    ]
})
export class AppHandlersModule { }
