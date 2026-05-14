import { CommonModule } from "@angular/common";
import { Component, EventEmitter, Input, Output } from "@angular/core";
import AppOrder from "./order";

@Component({
    selector: "app-order",
    templateUrl: "./order.component.html",
    imports: [
        CommonModule
    ]
})
export default class AppOrderComponent {
    @Output() readonly changed = new EventEmitter();
    @Input() order!: AppOrder;
    @Input() property!: string;
    @Input() text!: string;

    click() {
        this.order = this.order ?? new AppOrder();
        this.order.property = this.property;
        this.order.ascending = !this.order.ascending;
        this.changed.emit();
    }
}
