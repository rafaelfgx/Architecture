import { CommonModule } from "@angular/common";
import { HttpClientModule } from "@angular/common/http";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { AppGuardsModule } from "./guards/guards.module";
import { AppHandlersModule } from "./handlers/handlers.module";
import { AppInterceptorsModule } from "./interceptors/interceptors.module";

@NgModule({
    exports: [
        CommonModule,
        FormsModule,
        HttpClientModule,
        ReactiveFormsModule,
        AppGuardsModule,
        AppHandlersModule,
        AppInterceptorsModule
    ],
    imports: [
        CommonModule,
        FormsModule,
        HttpClientModule,
        ReactiveFormsModule,
        AppGuardsModule,
        AppHandlersModule,
        AppInterceptorsModule
    ]
})
export class AppCoreModule { }
