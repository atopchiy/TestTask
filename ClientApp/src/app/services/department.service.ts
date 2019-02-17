import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Department } from '../department';
import{DepartmentsPaging} from 'src/app/departments.paging';

@Injectable()
export class DepartmentService {

    private url = "http://localhost:58250/api/department";

    constructor(private http: HttpClient) {
    }

    getDepartments(paging: DepartmentsPaging) {
        return this.http.post(this.url, paging);
    }
    
    addDepartment(department: Department) {
        return this.http.post(this.url + "/add", department);
    }
    updateDepartment(department: Department) {

        return this.http.put(this.url, department);
    }
    deleteDepartment(id: number) {
        return this.http.delete(this.url + '/' + id);
    }
}