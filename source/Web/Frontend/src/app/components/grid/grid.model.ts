import { GridParametersModel } from "./grid-parameters.model";

export class GridModel<T> {
    count = 0;
    list = new Array<T>();
    parameters = new GridParametersModel();
}
