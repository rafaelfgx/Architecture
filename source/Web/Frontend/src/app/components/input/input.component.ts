import { FormControl } from "@angular/forms";
import AppComponent from "src/app/components/component";

// Import the type from Watt
type WattInputTypes = 'text' | 'password' | 'email' | 'number' | 'tel' | 'url';

export default abstract class AppInputComponent extends AppComponent<any> {
    type!: WattInputTypes;
    formControl: FormControl = new FormControl();

    constructor(type: WattInputTypes) {
        super();
        this.type = type;

        if (this.value) {
            this.formControl.setValue(this.value);
        }
    }

    input($event: any): void {
        this.value = $event.target.value;
    }

    handleInputChange(value: string): void {
        this.value = value;
        this.input({ target: { value } });
    }
}
