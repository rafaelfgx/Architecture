import { SignInModel } from "./signIn.model";

export class UserModel {
    email!: string;
    id!: number;
    name!: string;
    signIn!: SignInModel;
    surname!: string;
}
