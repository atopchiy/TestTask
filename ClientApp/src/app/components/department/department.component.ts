import { Component, OnInit } from '@angular/core';
import { DepartmentService } from '../../services/department.service';
import { Department } from '../../department';
import { DepartmentsPaging } from 'src/app/departments.paging';




@Component({
    selector: 'app-department',
    templateUrl: './department.component.html',
    styleUrls: ['./department.component.css'],
    providers: [DepartmentService]
})
export class DepartmentComponent implements OnInit {
    paging:DepartmentsPaging = new DepartmentsPaging(1);
    department: Department = new Department();   // изменяемый товар
    tableMode: boolean = true;          // табличный режим
    showError: boolean = false;

    constructor(private dataService: DepartmentService) { }

    ngOnInit() {
        this.loadDepartments();
    }
    goToNextStep()
    {
        this.paging.PageNumber += 1;
        this.loadDepartments();
    }
    goToPreviousStep(){
        this.paging.PageNumber -= 1;
        this.loadDepartments();
    }
    // получаем данные через сервис
    loadDepartments() {
         this.dataService.getDepartments(this.paging)
            .subscribe((data: DepartmentsPaging) => {this.paging = data});
        
    }
    showDepartmentError()
    {
       this.showError = true;
    }
   
    // сохранение данных
    save() {
        if (this.department.Id == null) {
            this.dataService.addDepartment(this.department)
            
            .subscribe((data: boolean) => {
                if(!data){this.showDepartmentError();
                    this.loadDepartments();
                    
                }
                else
                this.loadDepartments();
            });
            
        } else {
            this.dataService.updateDepartment(this.department)
            .subscribe((data: boolean)=>{
                if(!data)
                {
                    this.showDepartmentError();
                    this.loadDepartments();
                }  
                else
                this.loadDepartments();
            });
        }
        this.cancel();
    }
    editDepartment(p: Department) {
        this.tableMode = false;
        this.showError = false;
        this.department = p;
    }
    cancel() {
        this.department = new Department();
        this.tableMode = true;
        this.showError = false;
    }
    delete(p: Department) {
        this.dataService.deleteDepartment(p.Id)
        .subscribe((data: boolean)=>{
            if(!data)
            {
                this.showDepartmentError();
                this.loadDepartments();
            }  
            else
            this.loadDepartments();
        });
    }
    add() {
        this.cancel();
        this.tableMode = false;
        
    }
   
}
