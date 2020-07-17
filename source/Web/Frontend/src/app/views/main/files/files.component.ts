import { Component } from "@angular/core";
import { FileModel } from "src/app/components/file/file.model";

@Component({
    selector: "app-files",
    templateUrl: "./files.component.html"
})
export class AppFilesComponent {
    files = new Array<FileModel>();
}
