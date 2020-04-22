import { AlertService } from './../services/Alert.service';
import { City } from "./../Models/City";
import { CityService } from "./../services/City.service";
import { Component, OnInit } from "@angular/core";
import {
  FormBuilder,
  FormGroup,
  Validators,
  FormControl,
} from "@angular/forms";

@Component({
  selector: "app-city-add",
  templateUrl: "./city-add.component.html",
  styleUrls: ["./city-add.component.css"],
  providers: [CityService],
})
export class CityAddComponent implements OnInit {
  constructor(
    private cityService: CityService,
    private formBuilder: FormBuilder,
    private alertService: AlertService
  ) {}

  city: City;
  cityAddForm: FormGroup;

  createCityForm() {
    this.cityAddForm = this.formBuilder.group({
      name: ["", Validators.required],
      description: ["", Validators.required],
    });
  }
  ngOnInit() {
    this.createCityForm();
  }

  add() {
    this.city = Object.assign({}, this.cityAddForm.value);

    // Todo
    //this.city.id = 1;
    this.cityService.addCity(this.city);
    this.alertService.success("şehir kaydedildi.");
  }
}
