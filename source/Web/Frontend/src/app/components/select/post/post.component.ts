import { HttpClient } from "@angular/common/http";
import { Component, Input } from "@angular/core";
import { NG_VALUE_ACCESSOR } from "@angular/forms";
import { Observable, of } from "rxjs";
import { map, mergeMap, toArray } from "rxjs/operators";
import { OptionModel } from "../option.model";
import { AppSelectComponent } from "../select.component";

@Component({
    providers: [{ provide: NG_VALUE_ACCESSOR, useExisting: AppSelectPostComponent, multi: true }],
    selector: "app-select-post",
    templateUrl: "../select.component.html"
})
export class AppSelectPostComponent extends AppSelectComponent {
    @Input() autofocus = false;
    @Input() child!: AppSelectComponent;
    @Input() class!: string;
    @Input() disabled = false;
    @Input() formControlName!: string;
    @Input() text!: string;

    constructor(private readonly http: HttpClient) {
        super();
        this.load();
    }

    getOptions(userId: number): Observable<OptionModel[]> {
        if (!userId) { return of(); }

        return this.http
            .get(`https://jsonplaceholder.cypress.io/posts?userId=${userId}`)
            .pipe(mergeMap((x: any) => x), map((x: any) => new OptionModel(x.id, x.title)), toArray());
    }
}
