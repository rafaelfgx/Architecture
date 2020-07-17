import { GridParametersModel } from "./grid-parameters.model";

export class GridModel<Model> {
    count = 0;
    list = new Array<Model>();
    parameters = new GridParametersModel();
}
