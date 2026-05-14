import AppGridParameters from "./grid-parameters";

export default class AppGrid<T> {
    count = 0;
    list = new Array<T>();
    parameters = new AppGridParameters();
}
