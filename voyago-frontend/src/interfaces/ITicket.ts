import type { ITrip } from "./ITrip";
import type { IUser } from "./IUser";

export interface ITicket {
    ticketId: string,
    ticketTrip: ITrip,
    buyDate: Date,
    userId: string,
    user?: IUser
}