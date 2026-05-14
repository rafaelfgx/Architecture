import { bootstrapApplication } from "@angular/platform-browser";
import AppComponent from "@app/app.component"
import { appConfiguration } from "@app/app.configuration"

bootstrapApplication(AppComponent, appConfiguration).catch((error) => console.error(error));
