import { City } from './../Models/City';
import { CityService } from './../services/City.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-city-detail',
  templateUrl: './city-detail.component.html',
  styleUrls: ['./city-detail.component.css']
})
export class CityDetailComponent implements OnInit {

  constructor(private activatedRoute:ActivatedRoute, private cityService:CityService) { }
  city:City;

  ngOnInit() {
    this.activatedRoute.params.subscribe(params=>{
      this.getCityById(params["cityId"])
    })
  }

  getCityById(cityId) {
    this.cityService.getCityById(cityId).subscribe(data=>{
      this.city = data;
    });
  }

}
