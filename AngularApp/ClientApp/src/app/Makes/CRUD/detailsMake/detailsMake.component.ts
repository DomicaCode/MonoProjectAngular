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
  CurrentId: number;
  CurrentName: string;
  CurrentAbrv: string;

  constructor(@Inject('BASE_URL') private baseUrl: string, private activatedRoute: ActivatedRoute, private _makeService: MakeService) {

  }

  ngOnInit() {
    this.activatedRoute.paramMap.subscribe(paramMap => {
      const id = parseInt(paramMap.get('id'), 10) || -1;

      this._makeService.GetMakesById(id).subscribe(result =>
      {
        this.makes = result;

        this.CurrentId = result['id'];
        this.CurrentName = result['name'];
        this.CurrentAbrv = result['abrv'];
      })
    });
  }

}

interface Makes {
  Id: number;
  Name: string;
  Abrv: string;
}
