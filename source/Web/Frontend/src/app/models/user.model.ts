import { AuthModel } from "./auth.model";

export class UserModel {
    email!: string;
    firstName!: string;
    id!: number;
    lastName!: string;
    auth!: AuthModel;
}
