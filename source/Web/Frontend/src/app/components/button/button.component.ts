import { Component, Input } from '@angular/core';
import { WattButtonComponent } from '@energinet/watt/button';

@Component({
    selector: 'app-button',
    templateUrl: './button.component.html',
    standalone: true,
    imports: [WattButtonComponent],
})
export class AppButtonComponent {
    @Input() disabled = false;
    @Input() text!: string;
}
