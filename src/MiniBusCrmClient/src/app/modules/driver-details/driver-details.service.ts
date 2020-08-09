import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {map} from 'rxjs/operators';

export interface Driver {
  name: string;
  surname: string;
  patronymic: string;
  documentSerialNumber: string;
  documentNumber: string;
  phoneNumber: string;
}

@Injectable({
  providedIn: 'root'
})
export class DriverDetailsService {
  private readonly baseUri: string;

  constructor(private httpClient: HttpClient) {
    this.baseUri = 'https://localhost:5001/api';
  }

  public GetDriverInfo(driverId: string): Observable<Driver> {
    const url = `${this.baseUri}/BusDriver/id?id=${driverId}`;
    return this.httpClient.get<Driver>(url);
  }
}
