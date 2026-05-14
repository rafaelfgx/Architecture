import { CommonModule } from "@angular/common";
import { HttpClient } from "@angular/common/http";
import { Component, Input } from "@angular/core";
import { FormsModule, ReactiveFormsModule, NG_VALUE_ACCESSOR } from "@angular/forms";
import { Observable, of } from "rxjs";
import { map, mergeMap, toArray } from "rxjs/operators";
import AppSelectComponent from "./select.component";
import AppOption from "./option";

@Component({
    selector: "app-select-post",
    templateUrl: "./select.component.html",
    providers: [{ provide: NG_VALUE_ACCESSOR, useExisting: AppSelectPostComponent, multi: true }],
    imports: [CommonModule, FormsModule, ReactiveFormsModule]
})
export default class AppSelectPostComponent extends AppSelectComponent {
    @Input() autofocus = false;
    @Input() child!: AppSelectComponent;
    @Input() class!: string;
    @Input() disabled = false;
    @Input() formControlName!: string;
    @Input() text!: string;

    constructor(private readonly http: HttpClient) { super(); this.load(); }

    get(userId: number): Observable<AppOption[]> {
        if (!userId) return of();

        return this.http
            .get(`https://jsonplaceholder.cypress.io/posts?userId=${userId}`)
            .pipe(mergeMap((option: any) => option), map((option: any) => new AppOption(option.id, option.title)), toArray());
    }
}
