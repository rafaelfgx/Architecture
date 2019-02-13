import { Component } from "@angular/core";
import { NG_VALUE_ACCESSOR } from "@angular/forms";
import { Observable, of } from "rxjs";
import { OptionModel } from "../select/option.model";
import { AppSelectComponent } from "../select/select.component";

@Component({
    selector: "app-select-state",
    templateUrl: "../select/select.component.html",
    providers: [{ provide: NG_VALUE_ACCESSOR, useExisting: AppSelectStateComponent, multi: true }],
})
export class AppSelectStateComponent extends AppSelectComponent {
    getOptions(filter: string): Observable<OptionModel[]> {
        let options = new Array<OptionModel>();

        options.push(new OptionModel("State 1", "1"));
        options.push(new OptionModel("State 2", "2"));
        options.push(new OptionModel("State 3", "3"));

        options = options.filter((option) => option.value === filter);

        return of(options);
    }
}
