import { CommonModule } from "@angular/common";
import { Component, Input } from "@angular/core";
import { FormsModule, ReactiveFormsModule, NG_VALUE_ACCESSOR } from "@angular/forms";
import AppComponent from "../component";
import AppFileService from "./file.service";
import AppFile from "./file";

@Component({
    selector: "app-file",
    templateUrl: "./file.component.html",
    providers: [{ provide: NG_VALUE_ACCESSOR, useExisting: AppFileComponent, multi: true }],
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule
    ]
})
export default class AppFileComponent extends AppComponent<AppFile[]> {
    @Input() class!: string;
    @Input() disabled = false;
    @Input() formControlName!: string;
    @Input() text!: string;

    files = new Array<AppFile>();

    constructor(private readonly appFileService: AppFileService) {
        super();
    }

    change(files: FileList | null) {
        if (!files) { return; }

        for (let index = 0; index < files.length; index++) {
            const file = files.item(index) as File;
            const upload = { id: "", name: file.name, progress: 0 };
            this.files.push(upload);

            this.appFileService.upload(file).subscribe((result: AppFile) => {
                upload.progress = result.progress;

                if (result.id) {
                    this.value.push({ id: result.id, name: file.name, progress: upload.progress });
                    this.files = this.files.filter((x) => x.progress < 100);
                }
            });
        }
    }
}
