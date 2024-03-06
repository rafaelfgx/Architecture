import { Observable } from "rxjs";
import { AppComponent } from "src/app/components/component";
import { OptionModel } from "src/app/components/select/option.model";

export abstract class AppSelectComponent extends AppComponent<any> {
    abstract child: AppSelectComponent;

    options = new Array<OptionModel>();

    clear = () => this.options = new Array<OptionModel>();

    abstract get(parameter?: any): Observable<OptionModel[]>;

    load = (parameter?: any) => this.get(parameter).subscribe((options: OptionModel[]) => this.options = options);

    override writeValue(value: any) { this.value = value; this.change(); }

    change() {
        if (!this.child) return;

        let child = this.child;

        while (child) {
            child.value = undefined;
            child.clear();
            child = child.child;
        }

        this.child.load(this.value);
    }
}
