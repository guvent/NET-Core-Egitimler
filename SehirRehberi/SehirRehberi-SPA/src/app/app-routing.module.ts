import { CityAddComponent } from './city-add/city-add.component';
import { CityDetailComponent } from './city-detail/city-detail.component';
import { ValueComponent } from './value/value.component';
import { CityComponent } from './city/city.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  {path:"city", component:CityComponent},
  {path:"cityDetail/:cityId", component:CityDetailComponent},
  {path:"cityAdd", component:CityAddComponent},
  {path:"value", component:ValueComponent},
  {path:"**", redirectTo:"city", pathMatch:"full"}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
