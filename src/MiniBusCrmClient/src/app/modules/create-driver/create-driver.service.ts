import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Driver {
  name: string;
  surName: string;
  patronymic: string;
  documentSerialNumber: string;
  documentNumber: string;
}

@Injectable({
  providedIn: 'root'
})
export class CreateDriverService {
  private baseUri: string;

  constructor(private http: HttpClient) {
    this.baseUri = 'http://localhost/api';
  }

  public createNewDriver(newDriver: Driver): Observable<any> {
    return this.http.post(`${this.baseUri}/driver`, newDriver);
  }
}
