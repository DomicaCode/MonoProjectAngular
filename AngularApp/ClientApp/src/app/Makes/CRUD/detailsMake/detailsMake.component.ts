import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { MakeService } from '../../make.service';

@Component({
  selector: 'app-detailsMake',
  templateUrl: './detailsMake.component.html',
  providers: [MakeService]
})
export class DetailsMakeComponent implements OnInit {

  public makes: Makes[];

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private activatedRoute: ActivatedRoute, public _makeService: MakeService) {

  }

  ngOnInit() {
    this.activatedRoute.paramMap.subscribe(paramMap => {
      const id = parseInt(paramMap.get('id'), 10) || -1;
      this.GetObjectById(id);
    });

  }

  GetObjectById(id) {
    this.http.get<Makes[]>(this.baseUrl + "api/SampleData/GetMake/" + id).subscribe(result => {
      this.makes = result;

      this._makeService.GetObject(result);

    }, error => console.error(error));
  }


}

interface Makes {
  Id: number;
  Name: string;
  Abrv: string;
}
