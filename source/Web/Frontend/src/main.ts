import { enableProdMode } from "@angular/core";
import { platformBrowserDynamic } from "@angular/platform-browser-dynamic";
import { AppModule } from "./app/app.module";
import { environment } from "./environments/environment";

if (environment.enableProdMode) { enableProdMode(); }
platformBrowserDynamic().bootstrapModule(AppModule).catch((error: any) => console.error(error));
