import { Component, Inject, OnInit } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';

@Component({})
export class ModelService {
  CurrentId: number;
  CurrentMakeId: number;
  CurrentName: string;
  CurrentAbrv: string;
  public makes: Models[];


  constructor() {

  }

  GetObject(result) {
    this.CurrentId = result['id'];
    this.CurrentMakeId = result['makeId'];
    this.CurrentName = result['name'];
    this.CurrentAbrv = result['abrv'];
  }
}


interface Models {
  Id: number;
  MakeId: number;
  Name: string;
  Abrv: string;
}
