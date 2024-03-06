import { AuthModel } from "./auth.model";

export class UserModel {
    id!: number;
    name!: string;
    email!: string;
    auth!: AuthModel;
}
