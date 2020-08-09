import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateBusComponent } from './create-bus.component';
import {RouterModule, Routes} from '@angular/router';

const routes: Routes = [
  {
    path: '',
    component: CreateBusComponent
  }
];

@NgModule({
  declarations: [CreateBusComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ]
})
export class CreateBusModule { }
