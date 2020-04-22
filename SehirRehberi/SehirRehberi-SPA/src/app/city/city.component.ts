import { CityService } from './../services/City.service';
import { City } from './../Models/City';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-city',
  templateUrl: './city.component.html',
  styleUrls: ['./city.component.css']
})
export class CityComponent implements OnInit {

  constructor(private cityService:CityService) { }

  cities:City[];
  ngOnInit() {
    this.cityService.getCities().subscribe(data=>{
      this.cities = data;
    });
  }

}
