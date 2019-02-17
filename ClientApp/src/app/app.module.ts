import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { DepartmentComponent } from './components/department/department.component';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { FlexLayoutModule} from "@angular/flex-layout";
import { EmployeeComponent } from './components/employee/employee.component';
import { RouterModule, Routes } from '@angular/router';
import { TextInputAutocompleteModule } from 'angular-text-input-autocomplete';


const appRoutes: Routes =[
  { path: 'employee/:id', component: EmployeeComponent},
  { path: '', component: DepartmentComponent}
  
];

@NgModule({
  imports: [BrowserModule, FormsModule, HttpClientModule, FlexLayoutModule, RouterModule.forRoot(appRoutes), TextInputAutocompleteModule],
  declarations: [AppComponent, DepartmentComponent, EmployeeComponent],
  bootstrap: [AppComponent]
})
export class AppModule { }
