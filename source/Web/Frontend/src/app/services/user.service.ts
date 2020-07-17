import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { GridParametersModel } from "src/app/components/grid/grid-parameters.model";
import { GridService } from "src/app/components/grid/grid.service";
import { UserModel } from "src/app/models/user.model";

@Injectable({ providedIn: "root" })
export class AppUserService {
    constructor(
        private readonly http: HttpClient,
        private readonly gridService: GridService) { }

    add(model: UserModel) {
        return this.http.post<number>("users", model);
    }

    delete(id: number) {
        return this.http.delete(`users/${id}`);
    }

    get(id: number) {
        return this.http.get<UserModel>(`users/${id}`);
    }

    grid(parameters: GridParametersModel) {
        return this.gridService.get<UserModel>("users/grid", parameters);
    }

    list() {
        return this.http.get<UserModel[]>("users");
    }

    update(model: UserModel) {
        return this.http.put(`users/${model.id}`, model);
    }
}
