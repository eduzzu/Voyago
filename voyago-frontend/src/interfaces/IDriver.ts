import type { IUser } from "./IUser";

export interface IDriver extends IUser {
   car?: Car,
   companyId: string,
   company: Company
}