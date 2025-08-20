import type { ICompany } from "./ICompany";
import type { IUser } from "./IUser";

export interface IOwner extends IUser {
    companies: ICompany[]
}