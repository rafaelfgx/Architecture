import { CommonModule } from "@angular/common";
import { Component } from "@angular/core";
import { FormsModule } from "@angular/forms";
import AppFile from "src/app/components/file/file";
import AppFileComponent from "src/app/components/file/file.component";

@Component({
    selector: "app-files",
    templateUrl: "./files.component.html",
    imports: [
        CommonModule,
        FormsModule,
        AppFileComponent
    ]
})
export default class AppFilesComponent {
    files = new Array<AppFile>();
}
