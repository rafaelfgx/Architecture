import { Directive, input, model, output } from "@angular/core";
import { FormValueControl } from "@angular/forms/signals";

@Directive()
export default abstract class AppInputComponent implements FormValueControl<string | null> {
    readonly autofocus = input(false);
    readonly cssClass = input("", { alias: "class" });
    readonly disabled = input(false);
    readonly id = input.required<string>();
    readonly text = input.required<string>();
    readonly touch = output<void>();
    abstract readonly type: string;
    readonly value = model<string | null>(null);

    input(event: Event): void {
        this.value.set((event.target as HTMLInputElement | null)?.value ?? null);
    }

    blur(): void {
        this.touch.emit();
    }
}
