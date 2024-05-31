import { Injectable } from "@angular/core";

declare let UIkit: any;

@Injectable({ providedIn: "root" })
export default class AppModalService {
    alert = (message: string) => UIkit.modal.alert(message);
}
