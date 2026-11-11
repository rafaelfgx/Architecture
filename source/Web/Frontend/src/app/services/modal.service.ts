import { Service } from "@angular/core";

declare let UIkit: any;

@Service()
export default class AppModalService {
    alert = (message: string) => UIkit.modal.alert(message);
}
