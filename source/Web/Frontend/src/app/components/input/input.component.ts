import { AppComponent } from "src/app/components/component";

export abstract class AppInputComponent extends AppComponent<any> {
    type!: string;

    constructor(type: string) {
        super();
        this.type = type;
    }

    input($event: any): void {
        this.value = $event.target.value;
    }
}
