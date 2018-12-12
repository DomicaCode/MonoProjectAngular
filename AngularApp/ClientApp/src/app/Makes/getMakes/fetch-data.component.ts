import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import 'rxjs/add/operator/map';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public makes: Makes[];

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    http.get<Makes[]>(baseUrl + 'api/SampleData/Makes').subscribe(result => {
      this.makes = result;
    }, error => console.error(error));
  }


  deleteMake(id) {
    if (confirm("Jeste li sigurni da zelite obrisati?")) {
      return this.http.delete(this.baseUrl + "api/SampleData/DeleteMake/" + id)
        .subscribe();
    }
  }


}

interface Makes {
  Id: number;
  Name: string;
  Abrv: string;
}
