var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
var EmployeeService = /** @class */ (function () {
    function EmployeeService(http) {
        this.http = http;
        this.url = "/api/employee";
    }
    EmployeeService.prototype.getEmployees = function () {
        return this.http.get(this.url);
    };
    EmployeeService.prototype.addEmployee = function (employee) {
        return this.http.post(this.url, employee);
    };
    EmployeeService.prototype.updateEmployee = function (employee) {
        return this.http.put(this.url, employee);
    };
    EmployeeService.prototype.deleteEmployee = function (id) {
        return this.http.delete(this.url + '/' + id);
    };
    EmployeeService = __decorate([
        Injectable(),
        __metadata("design:paramtypes", [HttpClient])
    ], EmployeeService);
    return EmployeeService;
}());
export { EmployeeService };
//# sourceMappingURL=employee.service.js.map