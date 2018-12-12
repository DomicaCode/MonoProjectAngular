import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ModelService } from '../../model.service';

@Component({
  selector: 'app-detailsModel',
  templateUrl: './detailsModel.component.html',
  providers: [ModelService]
})
export class DetailsModelComponent implements OnInit {

  public models: Models[];

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private activatedRoute: ActivatedRoute, public _modelService: ModelService) {

  }

  ngOnInit() {
    this.activatedRoute.paramMap.subscribe(paramMap => {
      const id = parseInt(paramMap.get('id'), 10) || -1;
      this.GetInfo(id);
    });

  }

  GetInfo(id) {
    this.http.get<Models[]>(this.baseUrl + "api/SampleData/GetModel/" + id).subscribe(result => {
      this.models = result;

      this._modelService.GetObject(result);
    }, error => console.error(error));
  }
}


interface Models {
  Id: number;
  MakeId: number;
  Name: string;
  Abrv: string;
}

