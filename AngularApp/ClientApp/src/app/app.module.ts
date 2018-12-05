import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { MakeComponent } from './make/make.component';
import { CreateMakeComponent } from './createMake/createMake.component';
import { EditMakeComponent } from './editMake/editMake.component';
import { DetailsMakeComponent } from './detailsMake/detailsMake.component';
import { ModelsComponent } from './models/models.component';
import { CreateModelComponent } from './createModel/createModel.component';
import { EditModelComponent } from './editModel/editModel.component';
import { DetailsModelComponent } from './detailsModel/detailsModel.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    MakeComponent,
    CreateMakeComponent,
    EditMakeComponent,
    DetailsMakeComponent,
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
      { path: 'make', component: MakeComponent },
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
