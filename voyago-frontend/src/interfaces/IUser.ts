import type { IDriver } from "./IDriver";
import type { IOwner } from "./IOwner";
import type { ITicket } from "./ITicket";
import type { ITrip } from "./ITrip";

export interface IUser {
    userId: string,
    firstName: string,
    lastName: string,
    email: string,
    hashedPassword: string,
    dateOfBirth: Date,
    phoneNumber: string,
    profilePicture: string,
    driver?: IDriver | null,
    owner?: IOwner | null,
    tickets?: ITicket[] | [],
    userTrips?: ITrip[] | [],
    refreshToken?: string,
    refreshTokenExpiryTime?: Date,
    resetPasswordToken?: string,
    resetPasswordTokenExpires?: string
}