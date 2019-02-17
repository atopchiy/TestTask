import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Employee } from '../employee';
import {EmployeesPaging} from 'src/app/employees.paging';

@Injectable()
export class EmployeeService {

    private url = "http://localhost:58250/api/employee";

    constructor(private http: HttpClient) {
    }

    getEmployees(id: number, paging: EmployeesPaging) {
        return this.http.post(this.url + "/" + id, paging);
    }

    addEmployee(employee: Employee) {
        return this.http.post(this.url + "/add", employee);
    }
    updateEmployee(employee: Employee) {

        return this.http.put(this.url, employee);
    }
    deleteEmployee(id: number) {
        return this.http.delete(this.url + '/' + id);
    }
}