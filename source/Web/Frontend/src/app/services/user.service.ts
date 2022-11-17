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

    add = (user: UserModel) => this.http.post<number>("users", user);

    delete = (id: number) => this.http.delete(`users/${id}`);

    get = (id: number) => this.http.get<UserModel>(`users/${id}`);

    grid = (parameters: GridParametersModel) => this.gridService.get<UserModel>(`users/grid`, parameters);

    inactivate = (id: number) => this.http.patch(`users/${id}/inactivate`, {});

    list = () => this.http.get<UserModel[]>("users");

    update = (user: UserModel) => this.http.put(`users/${user.id}`, user);
}
