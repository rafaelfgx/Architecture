import { FiltersModel } from "./filter/filters.model";
import { OrderModel } from "./order/order.model";
import { PageModel } from "./page/page.model";

export class GridParametersModel {
    filters = new FiltersModel();
    order = new OrderModel();
    page = new PageModel();
}
