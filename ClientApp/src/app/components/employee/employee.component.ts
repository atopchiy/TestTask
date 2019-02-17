import { Component, OnInit } from '@angular/core';
import{EmployeeService} from '../../services/employee.service';
import { Employee } from '../../employee';
import{ActivatedRoute} from '@angular/router'
import {EmployeesPaging} from 'src/app/employees.paging';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css'],
  providers: [EmployeeService]
})
export class EmployeeComponent implements OnInit {
    paging:EmployeesPaging = new EmployeesPaging(1);
  depId:number;
  employee: Employee = new Employee();   // изменяемый товар
  employees: Employee[];                // массив товаров
  tableMode: boolean = true;
  showError: boolean = false;          // табличный режим
  constructor(private dataService: EmployeeService, private route: ActivatedRoute) {
    this.route.params.subscribe(params => this.depId = params['id']);
   }

  ngOnInit() {
    this.loadEmployees();
  }
  loadEmployees() {

    this.dataService.getEmployees(+this.depId, this.paging)
        .subscribe((data: EmployeesPaging) => this.paging = data);
}
// сохранение данных
showEmployeeError()
{
this.showError = true;
}

save() {
    if (this.employee.Id == null) {
        this.employee.DepartmentId = this.depId;
        this.dataService.addEmployee(this.employee)
            .subscribe((data: boolean) => {
                if(!data){this.showEmployeeError();
                    this.loadEmployees();
                    
                }
                else
                this.loadEmployees();
            });
    } else {
        this.dataService.updateEmployee(this.employee)
            .subscribe((data: boolean)=>{
                if(!data)
                {
                    this.showEmployeeError();
                    this.loadEmployees();
                }  
                else
                this.loadEmployees();
            });
    }
    this.cancel();
}
    goToNextStep()
    {
        this.paging.PageNumber += 1;
        this.loadEmployees();
    }
    goToPreviousStep(){
        this.paging.PageNumber -= 1;
        this.loadEmployees();
    }
editEmployee(p: Employee) {
    this.tableMode = false;
    this.showError = false;
    this.employee = p;
}
cancel() {
    this.employee = new Employee();
    this.tableMode = true;
    this.showError = false;
}
delete(p: Employee) {
    this.dataService.deleteEmployee(p.Id)
        .subscribe(data => this.loadEmployees());
}
add() {
    this.cancel();
    this.tableMode = false;
}
}
