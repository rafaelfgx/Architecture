import { CommonModule } from "@angular/common";
import { Component, inject } from "@angular/core";
import { FormBuilder, FormControl, ReactiveFormsModule } from "@angular/forms";
import { debounceTime } from "rxjs/operators";
import { AppButtonComponent } from "src/app/components/button/button.component";
import { AppInputTextComponent } from "src/app/components/input/text.input.component";
import { AppOrderComponent } from "src/app/components/grid/order/order.component";
import { AppPageComponent } from "src/app/components/grid/page/page.component";
import { AppUserService } from "src/app/services/user.service";
import { GridModel } from "src/app/components/grid/grid.model";
import { GridParametersModel } from "src/app/components/grid/grid-parameters.model";
import { UserModel } from "src/app/models/user.model";

@Component({
    selector: "app-list-grid",
    templateUrl: "./grid.component.html",
    standalone: true,
    imports: [
        CommonModule,
        ReactiveFormsModule,
        AppOrderComponent,
        AppPageComponent,
        AppButtonComponent,
        AppInputTextComponent
    ]
})
export class AppListGridComponent {
    filters = inject(FormBuilder).group({
        Id: new FormControl(),
        FirstName: new FormControl(),
        Email: new FormControl()
    });

    grid = new GridModel<UserModel>();

    constructor(private readonly appUserService: AppUserService) {
        this.init();
    }

    load() {
        this.appUserService.grid(this.grid.parameters).subscribe((grid) => this.grid = grid);
    }

    private filter() {
        this.grid.parameters = new GridParametersModel();
        this.grid.parameters.filters.addFromFormGroup(this.filters);
        this.load();
    }

    private init() {
        this.grid.parameters.order.property = "Id";
        this.filters.valueChanges.pipe(debounceTime(0)).subscribe(() => this.filter());
        this.load();
    }
}
