import { Component } from "@angular/core";
import { RouterOutlet } from "@angular/router";

@Component({
    selector: "app",
    imports: [RouterOutlet],
    template: "<router-outlet />"
})
export default class AppComponent { }
