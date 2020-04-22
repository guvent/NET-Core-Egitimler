import { Photo } from './../Models/Photo';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { City } from '../Models/City';

@Injectable({
  providedIn: 'root'
})
export class CityService {

constructor(private http:HttpClient) { }
  path:string = "https://localhost:44340/api/";

  getCities():Observable<City[]>{
    return this.http.get<City[]>(this.path+"cities");
  }

  getCityById(cityId):Observable<City> {
    return this.http.get<City>(this.path+"cities/detail/?id="+cityId)
  }

  getPhotosByCity(cityId):Observable<Photo[]>{
    return this.http.get<Photo[]>(this.path+"cities/photos/?id="+cityId)
  }
  addCity(city) {
    this.http.post(this.path+"cities/add",city).subscribe();
  }
}
