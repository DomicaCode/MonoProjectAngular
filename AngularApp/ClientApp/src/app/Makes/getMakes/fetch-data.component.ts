import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Subject } from 'rxjs/Subject';
import { MakeService } from '../make.service';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html',
  providers: [MakeService]
})
export class FetchDataComponent implements OnInit {

  public makes: Makes[];
  dtOptions: DataTables.Settings = {};
  dtTrigger: Subject<any> = new Subject();

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private _makeService: MakeService) {
  }


  ngOnInit() {
    this.dtOptions =
      {
        pagingType: "full_numbers",
        pageLength: 2
      };

    this._makeService.GetMakes().subscribe(result => {
      this.makes = result;
      this.dtTrigger.next();
    })
  }

  deleteMake(id) {
    if (confirm("Jeste li sigurni da zelite obrisati?")) {
      return this.http.delete(this.baseUrl + "api/Make/DeleteMake/" + id)
        .subscribe();
    }
  }


}

interface Makes {
  Id: number;
  Name: string;
  Abrv: string;
}
