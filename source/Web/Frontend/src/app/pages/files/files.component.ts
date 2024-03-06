import { CommonModule } from "@angular/common";
import { Component } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { AppFileComponent } from "src/app/components/file/file.component";
import { FileModel } from "src/app/components/file/file.model";

@Component({
    selector: "app-files",
    templateUrl: "./files.component.html",
    standalone: true,
    imports: [
        CommonModule,
        FormsModule,
        AppFileComponent
    ]
})
export class AppFilesComponent {
    files = new Array<FileModel>();
}
