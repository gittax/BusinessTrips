import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css']
})
export class EmployeesComponent implements OnInit {
  public employees: Employee[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Employee[]>(baseUrl + `api/Employees`)
      .subscribe(result => { this.employees = result; }, error => console.error(error)); 
  }

  ngOnInit() {
  }

}

interface Employee {
  employeeId: number;
  docType: string;
  docNumber: string;
  validThrough: string;
  gender: string;
  birthDate: string;
  birthPlace: string;
  request: TicketRequest;
  employeeRouteAssigns: string;
  employeeBase: EmployeeBase;
}

interface EmployeeBase {
  employeeBaseId: number;
  code: string;
  name: string;
  employeeProjectAssigns: string;
}

interface TicketRequest {
  requestId: number;
  requestNumber: string;
  date: string;
  declarer: string;
  businessTripNumber: string;
  budget: number;
  cost: number;
  manager: string;
  status: string;
  officeManager: string;
  project: string;
}
