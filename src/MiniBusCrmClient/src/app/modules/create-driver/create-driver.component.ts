import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CreateDriverService } from './create-driver.service';

@Component({
  selector: 'app-create-driver',
  templateUrl: './create-driver.component.html',
  styleUrls: ['./create-driver.component.scss']
})
export class CreateDriverComponent implements OnInit {
  public createDriverForm: FormGroup;

  constructor(private fb: FormBuilder,
              private createDriverService: CreateDriverService) {
  }

  ngOnInit(): void {
    this.createDriverForm = this.fb.group({
        name: [null, [Validators.required]],
        surname: [null, [Validators.required]],
        patronymic: [null, [Validators.required]],
        documentSerialNumber: [null, [Validators.required]],
        documentNumber: [null, [Validators.required]],
        phoneNumber: [null, [Validators.required]]
      }
    );
  }

  public onSubmit(): void {
    console.log('значение формы', this.createDriverForm.value);
    this.createDriverService.createNewDriver(this.createDriverForm.value)
      .subscribe(response => {
        console.log(response);
      });
  }
}
