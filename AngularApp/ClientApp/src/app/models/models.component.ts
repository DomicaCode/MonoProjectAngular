import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import 'rxjs/add/operator/map';

@Component({
  selector: 'app-models',
  templateUrl: './models.component.html'
})
export class ModelsComponent {
  public models: Models[];
  CurrentId: number;
  CurrentName: string;
  CurrentAbrv: string;

  isEdit = false;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    http.get<Models[]>(baseUrl + 'api/SampleData/Models').subscribe(result => {
      this.models = result;
      console.log(result);
    }, error => console.error(error));
  }


  deleteModel(id) {
    if (confirm("Jeste li sigurni da zelite obrisati?")) {
      return this.http.delete(this.baseUrl + "api/SampleData/DeleteModel/" + id)
        .subscribe();
    }
  }


}

interface Models {
  Id: number;
  MakeId: number;
  Name: string;
  Abrv: string;
}
