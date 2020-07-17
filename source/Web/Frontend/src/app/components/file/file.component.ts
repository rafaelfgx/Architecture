import { Component, Input } from "@angular/core";
import { NG_VALUE_ACCESSOR } from "@angular/forms";
import { AppBaseComponent } from "src/app/components/base/base.component";
import { FileModel } from "./file.model";
import { AppFileService } from "./file.service";
import { UploadModel } from "./upload.model";

@Component({
    providers: [{ provide: NG_VALUE_ACCESSOR, useExisting: AppFileComponent, multi: true }],
    selector: "app-file",
    templateUrl: "./file.component.html"
})
export class AppFileComponent extends AppBaseComponent<FileModel[]> {
    @Input() class!: string;
    @Input() disabled = false;
    @Input() formControlName!: string;
    @Input() text!: string;

    uploads = new Array<UploadModel>();

    constructor(private readonly appFileService: AppFileService) {
        super();
    }

    change(files: FileList | null) {
        if (!files) { return; }

        for (let index = 0; index < files.length; index++) {
            const file = files.item(index) as File;
            const upload = new UploadModel(file.name, 0);
            this.uploads.push(upload);

            this.appFileService.upload(file).subscribe((result: UploadModel) => {
                upload.progress = result.progress;

                if (result.id) {
                    this.value.push(new FileModel(result.id, file.name));
                    this.uploads = this.uploads.filter((x) => x.progress < 100);
                }
            });
        }
    }
}
