import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreatePlaneComponent } from './create-plane.component';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    component: CreatePlaneComponent
  }
];

@NgModule({
  declarations: [CreatePlaneComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ]
})

export class CreatePlaneModule { }
