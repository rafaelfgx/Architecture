import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import AppFilters from "./filter/filters";
import AppGrid from "./grid";
import AppGridParameters from "./grid-parameters";
import AppOrder from "./order/order";
import AppPage from "./page/page";

@Injectable({ providedIn: "root" })
export default class GridService {
    constructor(private readonly http: HttpClient) { }

    get<T>(url: string, parameters: AppGridParameters) {
        return this.http.get<AppGrid<T>>(url + this.queryString(parameters));
    }

    private queryString(parameters: AppGridParameters): string {
        let url = "?";

        parameters.page = parameters.page ?? new AppPage();
        url += `page.index=${parameters.page.index}&`;
        url += `page.size=${parameters.page.size}&`;

        parameters.order = parameters.order ?? new AppOrder();
        url += `order.property=${parameters.order.property ?? ""}&`;
        url += `order.ascending=${parameters.order.ascending}&`;

        parameters.filters = parameters.filters ?? new AppFilters();
        parameters.filters.forEach((filter, index) => {
            url += `filters[${index}].property=${filter.property}&`;
            url += `filters[${index}].comparison=${filter.comparison ?? ""}&`;
            url += `filters[${index}].value=${filter.value}&`;
        });

        url = url.slice(0, url.length - 1);

        return url;
    }
}
