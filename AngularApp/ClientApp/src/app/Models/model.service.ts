import { Component, Inject, OnInit } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';

@Component({})
export class ModelService {



  public makes: Models[];


  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {

  }

  GetModels() {
    return this.http.get<Models[]>(this.baseUrl + 'api/SampleData/Models');
  }

  GetModelsById(id) {
    return this.http.get<Models[]>(this.baseUrl + "api/SampleData/GetModel/" + id);
  }
}


interface Models {
  Id: number;
  MakeId: number;
  Name: string;
  Abrv: string;
}
