import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-detailsMake',
  templateUrl: './detailsMake.component.html'
})
export class DetailsMakeComponent implements OnInit
{

  public makes: Makes[];
  CurrentId: number;
  CurrentName: string;
  CurrentAbrv: string;


  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private activatedRoute: ActivatedRoute)
  {

  }

  ngOnInit()
  {
    console.log(this.CurrentId);

    this.activatedRoute.paramMap.subscribe(paramMap => {
      const id = parseInt(paramMap.get('id'), 10) || -1;
      console.log(id);
      this.GetInfo(id);
    });

  }

  GetInfo(id)
  {
    const data = this.http.get<Makes[]>(this.baseUrl + "api/SampleData/DetailsMake/" + id).subscribe(result => {
      this.makes = result;
      console.log(result);
      this.CurrentId = result['id'];
      this.CurrentName = result['name'];
      this.CurrentAbrv = result['abrv'];
      /*
      this.CurrentId = result[0].id;
      this.CurrentName = result[0].name;
      this.CurrentAbrv = result[0].abrv;

      console.log(this.CurrentId);
      */
    }, error => console.error(error));
  }
  /*
  MakeSelected(make: Makes)
  {
    this.CurrentId = make.Id;
    this.CurrentName = make.Name;
    this.CurrentAbrv = make.Abrv;
  }
  */

  save()
  {
    return this.http.put(this.baseUrl + 'api/SampleData/EditMake/' + this.CurrentId, { Id: this.CurrentId, Name: this.CurrentName, Abrv: this.CurrentAbrv }).subscribe();
  }

}

interface Makes {
  Id: number;
  Name: string;
  Abrv: string;
}

