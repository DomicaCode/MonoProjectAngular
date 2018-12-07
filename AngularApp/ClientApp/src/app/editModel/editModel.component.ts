import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-editModel',
  templateUrl: './editModel.component.html'
})
export class EditModelComponent implements OnInit
{

  public models: Models[];
  CurrentId: number;
  CurrentMakeId: number;
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
    const data = this.http.get< Models[]>(this.baseUrl + "api/SampleData/EditModel/" + id).subscribe(result => {
      this.models = result;
      console.log(result);
      this.CurrentId = result['id'];
      this.CurrentMakeId = result['makeId'];
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
    return this.http.put(this.baseUrl + 'api/SampleData/EditModel/' + this.CurrentId, { Id: this.CurrentId, Name: this.CurrentName, Abrv: this.CurrentAbrv }).subscribe();
  }

}

interface Models {
  Id: number;
  MakeId: number;
  Name: string;
  Abrv: string;
}

