import { Component } from "@angular/core";
import { AppFileService } from "src/app/services/file.service";

@Component({ selector: "app-upload", templateUrl: "./upload.component.html" })
export class AppUploadComponent {
    progress = 0;

    constructor(private readonly appFileService: AppFileService) { }

    upload(files: FileList) {
        this.appFileService.upload(files).subscribe((progress: number) => {
            this.progress = progress;
        });
    }
}
