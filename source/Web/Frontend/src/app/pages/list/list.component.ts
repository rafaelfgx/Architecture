import { Component } from "@angular/core";
import AppListGridComponent from "./grid/grid.component";

@Component({
    selector: "app-list",
    templateUrl: "./list.component.html",
    imports: [
        AppListGridComponent
    ]
})
export default class AppListComponent { }
