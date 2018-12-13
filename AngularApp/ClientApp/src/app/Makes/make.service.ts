import { Component, Inject, OnInit } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import 'rxjs/add/operator/map';

@Component({})
export class MakeService {
  CurrentId: number;
  CurrentName: string;
  CurrentAbrv: string;
  public makes: Makes[];


  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {

  }

  GetMakes() {
    return this.http.get<Makes[]>(this.baseUrl + 'api/SampleData/Makes');
  }

  GetObject(result) {
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
