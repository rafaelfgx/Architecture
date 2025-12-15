import { ControlValueAccessor } from "@angular/forms";

export default abstract class AppComponent<Value> implements ControlValueAccessor {
    abstract class: string;
    abstract disabled: boolean;
    abstract formControlName: string;
    abstract text: string;
    private _value!: Value;

    get value(): Value { return this._value; }

    set value(value: Value) {
        if (this.value === value) return;
        this._value = value;
        if (this.onChange) this.onChange(value);
    }

    registerOnChange(onChange: any) { this.onChange = onChange; }

    registerOnTouched(_: () => void) { /* Empty */ }

    writeValue(value: Value) { this.value = value; }

    private onChange!: (value: Value) => void;
}
