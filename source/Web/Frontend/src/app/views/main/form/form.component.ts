import { Component } from "@angular/core";
import { FormBuilder } from "@angular/forms";

@Component({ selector: "app-form", templateUrl: "./form.component.html" })
export class AppFormComponent {
    city = "";
    country = "";
    state = "";
    disabled = false;

    form = this.formBuilder.group({
        child: this.formBuilder.group({ string: [] }),
        number: [],
        string: []
    });

    model = {
        child: { string: "" },
        number: 0,
        string: ""
    };

    constructor(private readonly formBuilder: FormBuilder) { }

    set() {
        this.country = "1";
        this.state = "1";
        this.city = "1";
    }

    submit() {
        alert("submit");
    }
}
