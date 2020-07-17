import { Component } from "@angular/core";
import { FormBuilder, Validators } from "@angular/forms";

@Component({
    selector: "app-form",
    templateUrl: "./form.component.html"
})
export class AppFormComponent {
    disabled = false;

    form = this.formBuilder.group({
        user: ["", Validators.required],
        post: ["", Validators.required],
        comment: ["", Validators.required]
    });

    constructor(private readonly formBuilder: FormBuilder) { }

    set() {
        this.form.patchValue({ user: "10", post: "100", comment: "500" });
    }
}
