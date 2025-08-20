import type { IOwner } from "./IOwner";

export interface ICompany {
    companyId: string,
    companyName: string,
    ownerId: string,
    owner?: IOwner
}