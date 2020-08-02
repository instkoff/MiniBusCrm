import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path: 'create-plane',
    loadChildren: () => import('./modules/create-plane/create-plane.module').then(m => m.CreatePlaneModule)
  },
  {
    path: 'create-driver',
    loadChildren: () => import('./modules/create-driver/create-driver.module').then(m => m.CreateDriverModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
