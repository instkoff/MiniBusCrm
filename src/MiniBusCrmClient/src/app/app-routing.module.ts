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
  },
  {
    path: 'create-bus',
    loadChildren: () => import('./modules/create-bus/create-bus.module').then(m => m.CreateBusModule)
  },
  {
    path: 'driver-details',
    loadChildren: () => import('./modules/driver-details/driver-details.module').then(m => m.DriverDetailsModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
