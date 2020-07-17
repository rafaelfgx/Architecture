import { Observable } from "rxjs";
import { AppBaseComponent } from "../base/base.component";
import { OptionModel } from "./option.model";

export abstract class AppSelectComponent extends AppBaseComponent<any> {
    abstract child: AppSelectComponent;

    options = new Array<OptionModel>();

    change($event: any) {
        this.value = $event.target.value;
        this.changeChildren(true);
    }

    clearOptions() {
        this.options = new Array<OptionModel>();
    }

    abstract getOptions(parameter?: any): Observable<OptionModel[]>;

    load(parameter?: any) {
        this.getOptions(parameter).subscribe((options: OptionModel[]) => { this.options = options; });
    }

    writeValue(value: any) {
        this.value = value;
        this.changeChildren();
    }

    private changeChildren(clearValue: boolean = false) {
        if (!this.child) { return; }

        let child = this.child;

        while (child) {
            child.clearOptions();
            if (clearValue) { child.value = undefined; }
            child = child.child;
        }

        this.child.load(this.value);
    }
}
