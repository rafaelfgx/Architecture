import { Component } from "@angular/core";
import { AppAuthenticationService } from "src/app/services/authentication.service";

@Component({ selector: "app-nav", templateUrl: "./nav.component.html" })
export class AppNavComponent {
    constructor(private readonly appAuthenticationService: AppAuthenticationService) { }

    signOut() {
        this.appAuthenticationService.signOut();
    }
}
