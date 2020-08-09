import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

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
export class CreateDriverService {
  private readonly baseUri: string;

  constructor(private http: HttpClient) {
    this.baseUri = 'https://localhost:5001/api';
  }

  public createNewDriver(newDriver: Driver): Observable<any> {
    return this.http.post(`${this.baseUri}/BusDriver`, newDriver);
  }
}
