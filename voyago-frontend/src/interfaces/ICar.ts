import type { IDriver } from "./IDriver";

export interface ICar {
    carId: string,
    carName: string,
    carPlate: string,
    carDescription: string,
    driverId: string,
    driver?: IDriver
}