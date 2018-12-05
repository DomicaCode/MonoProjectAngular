import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import 'rxjs/add/operator/map';

@Component({
  selector: 'app-make',
  templateUrl: './make.component.html'
})
export class MakeComponent {
  public makes: IMake[];
  myAppUrl: string = "";  

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
      this.myAppUrl = baseUrl;
  }

  Make() {
    return this.http.get(this.myAppUrl + 'api/Vehicle/Make')
      .map((response: Response) => response.json());
  }  
  }

interface IMake {
  Id: number;
  Name: string;
  Abrv: string;
}
