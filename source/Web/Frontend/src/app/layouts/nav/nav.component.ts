import { Component } from "@angular/core";
import { RouterModule } from "@angular/router";
import AppAuthService from "src/app/services/auth.service";

@Component({
    selector: "app-nav",
    templateUrl: "./nav.component.html",
    imports: [
        RouterModule
    ]
})
export default class AppNavComponent {
    constructor(private readonly appAuthService: AppAuthService) { }

    signout = () => this.appAuthService.signout();
}
