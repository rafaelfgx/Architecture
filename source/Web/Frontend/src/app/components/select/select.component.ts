import { Input, OnInit } from "@angular/core";
import { Observable } from "rxjs";
import { AppBaseComponent } from "../base/base.component";
import { OptionModel } from "./option.model";

export abstract class AppSelectComponent extends AppBaseComponent implements OnInit {
    @Input() lazy = false;

    options = new Array<OptionModel>();

    abstract getOptions(filter: string): Observable<OptionModel[]>;

    ngOnInit(): void {
        if (!this.lazy) {
            this.load();
        }
    }

    change() {
        this.changed.emit(this.ngModel);
    }

    reset() {
        this.options = new Array<OptionModel>();
        this.ngModel = null;
        this.change();
    }

    load(filter?: string) {
        this.reset();

        if (this.lazy && !filter) {
            return;
        }

        this.getOptions(filter).subscribe((options: OptionModel[]) => {
            this.options = options;
        });
    }
}
