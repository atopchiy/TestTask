var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component } from '@angular/core';
import { DepartmentService } from '../../services/department.service';
import { Department } from '../../department';
var DepartmentComponent = /** @class */ (function () {
    function DepartmentComponent(dataService) {
        this.dataService = dataService;
        this.department = new Department(); // изменяемый товар
        this.tableMode = true; // табличный режим
    }
    DepartmentComponent.prototype.ngOnInit = function () {
        this.loadDepartments(); // загрузка данных при старте компонента  
    };
    // получаем данные через сервис
    DepartmentComponent.prototype.loadDepartments = function () {
        var _this = this;
        this.dataService.getDepartments()
            .subscribe(function (data) { return _this.departments = data; });
    };
    // сохранение данных
    DepartmentComponent.prototype.save = function () {
        var _this = this;
        debugger;
        if (this.department.Id == null) {
            this.dataService.addDepartment(this.department)
                .subscribe(function (data) { return _this.departments.push(data); });
        }
        else {
            this.dataService.updateDepartment(this.department)
                .subscribe(function (data) { return _this.loadDepartments(); });
        }
        this.cancel();
    };
    DepartmentComponent.prototype.editDepartment = function (p) {
        this.department = p;
    };
    DepartmentComponent.prototype.cancel = function () {
        this.department = new Department();
        this.tableMode = true;
    };
    DepartmentComponent.prototype.delete = function (p) {
        var _this = this;
        this.dataService.deleteDepartment(p.Id)
            .subscribe(function (data) { return _this.loadDepartments(); });
    };
    DepartmentComponent.prototype.add = function () {
        alert("Pochemu");
        debugger;
        this.cancel();
        this.tableMode = false;
    };
    DepartmentComponent = __decorate([
        Component({
            selector: 'department',
            templateUrl: './department.component.html',
            providers: [DepartmentService]
        }),
        __metadata("design:paramtypes", [DepartmentService])
    ], DepartmentComponent);
    return DepartmentComponent;
}());
export { DepartmentComponent };
//# sourceMappingURL=department.component.js.map