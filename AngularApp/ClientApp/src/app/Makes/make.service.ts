import { Component, Inject, OnInit } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';

@Component({})
export class MakeService
{
  CurrentId: number;
  CurrentName: string;
  CurrentAbrv: string;
  public makes: Makes[];


  constructor() {

  }

  GetObject(result)
  {
    this.CurrentId = result['id'];
    this.CurrentName = result['name'];
    this.CurrentAbrv = result['abrv'];
  }
}


interface Makes {
  Id: number;
  Name: string;
  Abrv: string;
}
