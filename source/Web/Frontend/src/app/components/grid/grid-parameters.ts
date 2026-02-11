import AppFilters from "./filter/filters";
import AppOrder from "./order/order";
import AppPage from "./page/page";

export default class AppGridParameters {
    filters = new AppFilters();
    order = new AppOrder();
    page = new AppPage();
}
