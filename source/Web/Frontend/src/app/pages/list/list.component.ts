import { Component } from "@angular/core";
import { AppListGridComponent } from "./grid/grid.component";

@Component({
    selector: "app-list",
    templateUrl: "./list.component.html",
    standalone: true,
    imports: [
        AppListGridComponent
    ]
})
export class AppListComponent { }
