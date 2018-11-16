import { Component, OnInit } from '@angular/core';
import { HttpService } from '../services/http.service';
import { EmployeeBase, Employee, EmployeeBaseProjectAssign, EmployeeRouteAssign, Request, Project, Route, Subproject, Ticket, RequestViewModel, EmployeeViewModel } from '../models/models';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css'],
  providers: [HttpService]
})

export class EmployeesComponent implements OnInit {

  private i: number;
  public employees: Employee[];
  public employeesBase: EmployeeBase[];
  public requests: Request[];
  done: boolean = false;

  employeeViewModels: EmployeeViewModel[];

  newEmployee: Employee = new Employee();

  constructor(private httpService: HttpService) { }

  ngOnInit() {

    this.i = 0;
    this.newEmployee = new Employee();

    this.httpService.getRequest()
      .subscribe(result => { this.requests = result; }, error => console.error(error), () => this.callback(this.requests));

    this.httpService.getEmployee()
      .subscribe(result => { this.employees = result; }, error => console.error(error), () => this.callback(this.employees));

    this.httpService.getEmployeeBase()
      .subscribe(result => { this.employeesBase = result; }, error => console.error(error), () => this.callback(this.employeesBase));
  }

  addEmployee(newEmployee: Employee) {
    this.httpService.postEmployee(newEmployee)
      .subscribe(result => { console.log(result) }, error => console.error(error), () => this.ngOnInit());
  }

  deleteEmployee(id: string) {
    this.httpService.deleteEmployee(id)
      .subscribe(result => { console.log(result) }, error => console.error(error), () => this.ngOnInit());
  }

  check() {
    this.ngOnInit();
  }

  callback(result) {
    console.log(result);
    this.i++;
    console.log(this.i);
    if (this.i == 3) {
      this.constructArray();
    }
  }

  constructArray() {
    if (!this.requests.length) {
      this.employeeViewModels = [];
      console.log('requests.length = 0');
      return;
    }

    var emp: EmployeeBase = new EmployeeBase();

    this.employeeViewModels = [];
    this.employees.forEach((employee, i) => {
      this.employeeViewModels.push(new EmployeeViewModel());
      this.employeeViewModels[i].employeeId = employee.employeeId;
      this.employeeViewModels[i].docType = employee.docType;
      this.employeeViewModels[i].docNumber = employee.docNumber;
      this.employeeViewModels[i].validThrough = employee.validThrough;
      this.employeeViewModels[i].gender = employee.gender;
      this.employeeViewModels[i].birthDate = employee.birthDate;
      this.employeeViewModels[i].birthPlace = employee.birthPlace;
      this.employeeViewModels[i].requestId = employee.requestId;

      emp = this.employeesBase.find(x => x.employeeBaseId == employee.employeeBaseId);
      this.employeeViewModels[i].employeeBase = emp.name;
    });
  }
}
