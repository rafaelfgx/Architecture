import { Component, inject } from "@angular/core";
import { RouterLink, RouterLinkActive } from "@angular/router";
import AppAuthService from "@services/auth.service";

@Component({
    selector: "app-nav",
    templateUrl: "./nav.component.html",
    imports: [
        RouterLink,
        RouterLinkActive
    ]
})
export default class AppNavComponent {
    private readonly appAuthService = inject(AppAuthService);

    signout(event: Event): void {
        event.preventDefault();
        this.appAuthService.signout();
    }
}
