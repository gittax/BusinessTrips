import { Component, OnInit } from '@angular/core';
import { HttpService } from '../services/http.service';
import { EmployeeBase, Employee, EmployeeBaseProjectAssign, EmployeeRouteAssign, Request, Project, Route, Subproject, Ticket } from '../models/models';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  providers: [HttpService]
})

export class HomeComponent {
  public requests: Request[];
  public employeesBase: EmployeeBase[];
  public projects: Project[];
  public subprojects: Subproject[];
  done: boolean = false;
  newEmployeeBase: EmployeeBase = new EmployeeBase();
  newRequest: Request = new Request();

  constructor(private httpService: HttpService) { }

  ngOnInit() {
    this.httpService.getEmployeeBase()
      .subscribe(result => { this.employeesBase = result; }, error => console.error(error));

    this.httpService.getRequest()
      .subscribe(result => { this.requests = result; }, error => console.error(error));

    this.httpService.getProject()
      .subscribe(result => { this.projects = result; }, error => console.error(error));

    this.httpService.getSubproject()
      .subscribe(result => { this.subprojects = result; }, error => console.error(error));

    //console.log(this.employeesBase);
  }

  addEmployeeBase(newEmployeeBase: EmployeeBase) {
    this.httpService.postEmployeeBase(newEmployeeBase)
      .subscribe(result => { console.log(result) }, error => console.error(error));
    this.ngOnInit();
  }

  deleteEmployeeBase(id: string) {
    this.httpService.deleteEmployeeBase(id)
      .subscribe(result => { console.log(result) }, error => console.error(error));
    this.ngOnInit();
  }

  addRequest(newRequest: Request) {
    this.httpService.postRequest(newRequest)
      .subscribe(result => { console.log(result) }, error => console.error(error));
    this.ngOnInit();
  }

  deleteRequest(id: string) {
    this.httpService.deleteRequest(id)
      .subscribe(result => { console.log(result) }, error => console.error(error));
    this.ngOnInit();
  }

  check() {
    this.ngOnInit();
    //console.log(this.employeesBase);
    //console.log(this.declarer);
  }

}
