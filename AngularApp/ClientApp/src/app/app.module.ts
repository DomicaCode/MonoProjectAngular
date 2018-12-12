import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { CreateMakeComponent } from './Makes/CRUD/createMake/createMake.component';
import { EditMakeComponent } from './Makes/CRUD/editMake/editMake.component';
import { DetailsMakeComponent } from './Makes/CRUD/detailsMake/detailsMake.component';
import { FetchDataComponent } from './Makes/getMakes/fetch-data.component';
import { ModelsComponent } from './Models/getModels/models.component';
import { CreateModelComponent } from './Models/CRUD/createModel/createModel.component';
import { EditModelComponent } from './Models/CRUD/editModel/editModel.component';
import { DetailsModelComponent } from './Models/CRUD/detailsModel/detailsModel.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    EditMakeComponent,
    CreateMakeComponent,
    EditMakeComponent,
    DetailsMakeComponent,
    FetchDataComponent,
    ModelsComponent,
    CreateModelComponent,
    EditModelComponent,
    DetailsModelComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'createMake', component: CreateMakeComponent },
      { path: 'editMake/:id', component: EditMakeComponent },
      { path: 'detailsMake/:id', component: DetailsMakeComponent },
      { path: 'models', component: ModelsComponent },
      { path: 'createModel', component: CreateModelComponent },
      { path: 'editModel/:id', component: EditModelComponent },
      { path: 'detailsModel/:id', component: DetailsModelComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
