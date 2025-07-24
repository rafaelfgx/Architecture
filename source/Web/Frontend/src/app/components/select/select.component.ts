import { Observable } from "rxjs";
import AppComponent from "src/app/components/component";
import AppOption from "src/app/components/select/option";

export default abstract class AppSelectComponent extends AppComponent<any> {
    abstract child: AppSelectComponent;

    options = new Array<AppOption>();

    clear = () => this.options = new Array<AppOption>();

    abstract get(parameter?: any): Observable<AppOption[]>;

    load = (parameter?: any) => this.get(parameter).subscribe((options: AppOption[]) => this.options = options);

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
