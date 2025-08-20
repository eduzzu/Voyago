import type { IUser } from "./IUser";

export interface ITrip {
    tripId: string,
    start: string,
    finish: string,
    price: number,
    tripDate: Date,
    tripDescription?: string,
    userTrips?: IUser[]
}