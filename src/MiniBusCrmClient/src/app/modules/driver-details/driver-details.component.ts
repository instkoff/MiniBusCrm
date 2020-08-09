import { Component, OnInit } from '@angular/core';
import {Driver, DriverDetailsService} from './driver-details.service';
import {map} from 'rxjs/operators';
import {Observable, of} from 'rxjs';

@Component({
  selector: 'app-driver-details',
  templateUrl: './driver-details.component.html',
  styleUrls: ['./driver-details.component.scss']
})
export class DriverDetailsComponent implements OnInit {
public driver: Driver = {
  name: '',
  surname: '',
  patronymic: '',
  documentSerialNumber: '',
  documentNumber: '',
  phoneNumber: '',
};

  constructor(private driverDetailsService: DriverDetailsService) { }

  ngOnInit(): void {
    this.driverDetailsService.GetDriverInfo('ac4a3da4-5039-4bcf-a66e-7019b58d7276').subscribe(res => this.driver = res);
  }
}
