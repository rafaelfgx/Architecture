import { CommonModule } from "@angular/common";
import { Component, inject } from "@angular/core";
import { FormBuilder, FormControl, ReactiveFormsModule } from "@angular/forms";
import { debounceTime } from "rxjs/operators";
import AppGrid from "@components/grid/grid";
import AppGridParameters from "@components/grid/grid-parameters";
import AppInputTextComponent from "@components/input/text.input.component";
import AppOrderComponent from "@components/grid/order/order.component";
import AppPageComponent from "@components/grid/page/page.component";
import AppUser from "@models/user";
import AppUserService from "@services/user.service";

@Component({
    selector: "app-list-grid",
    templateUrl: "./grid.component.html",
    imports: [
        CommonModule,
        ReactiveFormsModule,
        AppOrderComponent,
        AppPageComponent,
        AppInputTextComponent
    ]
})
export default class AppListGridComponent {
    filters = inject(FormBuilder).group({
        Id: new FormControl(),
        Name: new FormControl(),
        Email: new FormControl()
    });

    grid = new AppGrid<AppUser>();

    constructor(private readonly appUserService: AppUserService) {
        this.init();
    }

    load() {
        this.appUserService.grid(this.grid.parameters).subscribe((grid) => this.grid = grid);
    }

    private filter() {
        this.reset();
        this.grid.parameters.filters.addFromFormGroup(this.filters);
        this.load();
    }

    private init() {
        this.reset();
        this.grid.parameters.order.property = "Id";
        this.filters.valueChanges.pipe(debounceTime(0)).subscribe(() => this.filter());
        this.load();
    }

    private reset() {
        this.grid = new AppGrid<AppUser>();
        this.grid.parameters = new AppGridParameters();
    }
}
