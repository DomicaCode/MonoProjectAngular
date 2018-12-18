import { Component, Inject, OnInit } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import 'rxjs/add/operator/map';

@Component({})
export class MakeService {


  public makes: Makes[];


  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {

  }

  GetMakes() {
    return this.http.get<Makes[]>(this.baseUrl + 'api/Make/Makes');
  }

  GetMakesById(id)
  {
    return this.http.get<Makes[]>(this.baseUrl + "api/Make/GetMake/" + id);
  }
}


interface Makes {
  Id: number;
  Name: string;
  Abrv: string;
}
