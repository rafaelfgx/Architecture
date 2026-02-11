import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import AppGridParameters from "@components/grid/grid-parameters";
import GridService from "@components/grid/grid.service";
import AppUser from "@models/user";

@Injectable({ providedIn: "root" })
export default class AppUserService {
    constructor(
        private readonly http: HttpClient,
        private readonly gridService: GridService) { }

    add = (user: AppUser) => this.http.post<number>("api/users", user);

    delete = (id: number) => this.http.delete(`api/users/${id}`);

    get = (id: number) => this.http.get<AppUser>(`api/users/${id}`);

    grid = (parameters: AppGridParameters) => this.gridService.get<AppUser>(`api/users/grid`, parameters);

    inactivate = (id: number) => this.http.patch(`api/users/${id}/inactivate`, {});

    list = () => this.http.get<AppUser[]>("api/users");

    update = (user: AppUser) => this.http.put(`api/users/${user.id}`, user);
}
