import { Value } from './../Models/Value';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
@Component({
  selector: 'app-value',
  templateUrl: './value.component.html',
  styleUrls: ['./value.component.css']
})
export class ValueComponent implements OnInit {

  constructor(private http:HttpClient) { }

  values:Value[]=[];
  ngOnInit() {
    this.getValues().subscribe(data=>this.values=data);
  }

  getValues()
  {
    let url:string = "https://localhost:44340/api/values";
    return this.http.get<Value[]>(url);
  }

}
