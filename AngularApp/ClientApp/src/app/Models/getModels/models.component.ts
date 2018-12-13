import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Subject } from 'rxjs/Subject';
import { ModelService } from '../model.service';

@Component({
  selector: 'app-models',
  templateUrl: './models.component.html',
  providers: [ModelService]
})
export class ModelsComponent implements OnInit {

  public models: Models[];
  dtOptions: DataTables.Settings = {};
  dtTrigger: Subject<any> = new Subject();

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private _modelService: ModelService) {
  }

  ngOnInit() {
    this.dtOptions =
      {
        pagingType: "full_numbers",
        pageLength: 2
      };

    this._modelService.GetModels().subscribe(result => {
      this.models = result;
      this.dtTrigger.next();
    })
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
