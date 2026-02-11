import { CommonModule } from "@angular/common";
import { Component, EventEmitter, Input, Output } from "@angular/core";
import AppPage from "./page";

@Component({
    selector: "app-page",
    templateUrl: "./page.component.html",
    imports: [
        CommonModule
    ]
})
export default class AppPageComponent {
    get count(): number {
        return this._count;
    }

    @Input("count")
    set count(count: number) {
        this._count = count;
        this.setPages();
    }

    get page(): AppPage {
        return this._page;
    }

    @Input("page")
    set page(page: AppPage) {
        this._page = page;
        this.setPages();
    }

    @Output() readonly changed = new EventEmitter();

    pages = 0;
    private _count = 0;
    private _page = new AppPage();

    change(index: number) {
        this.page.index = index;
        this.changed.emit();
    }

    setPages() {
        this.pages = Math.ceil(this.count / this.page.size);
    }
}
