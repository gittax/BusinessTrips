import { Component, OnInit } from '@angular/core';
import { HttpService } from '../services/http.service';
import { EmployeeBase, Employee, EmployeeBaseProjectAssign, EmployeeRouteAssign, Request, Project, Route, Subproject, Ticket, RequestViewModel } from '../models/models';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  providers: [HttpService]
})

export class HomeComponent {
  private i: number;
  public requests: Request[];
  public requestViewModels: RequestViewModel[];
  public employeesBase: EmployeeBase[];
  public projects: Project[];
  public subprojects: Subproject[];
  public localSubprojects: Subproject[];
  done: boolean = false;
  newEmployeeBase: EmployeeBase = new EmployeeBase();
  newRequest: Request = new Request();

  constructor(private httpService: HttpService) { }

  ngOnInit() {

    this.i = 0;
    this.newRequest = new Request();

    this.httpService.getEmployeeBase()
      .subscribe(result => { this.employeesBase = result; }, error => console.error(error), () => this.callback(this.employeesBase));

    this.httpService.getRequest()
      .subscribe(result => { this.requests = result; }, error => console.error(error), () => this.callback(this.requests));

    this.httpService.getProject()
      .subscribe(result => { this.projects = result; }, error => console.error(error), () => this.callback(this.projects));

    this.httpService.getSubproject()
      .subscribe(result => { this.subprojects = result; }, error => console.error(error), () => this.callback(this.subprojects));

    //console.log(this.employeesBase);
  }

  addEmployeeBase(newEmployeeBase: EmployeeBase) {
    this.httpService.postEmployeeBase(newEmployeeBase)
      .subscribe(result => { console.log(result) }, error => console.error(error), () => this.ngOnInit());
  }

  deleteEmployeeBase(id: string) {
    this.httpService.deleteEmployeeBase(id)
      .subscribe(result => { console.log(result) }, error => console.error(error), () => this.ngOnInit());
  }

  addRequest(newRequest: Request) {
    this.httpService.postRequest(newRequest)
      .subscribe(result => { console.log(result) }, error => console.error(error), () => this.ngOnInit());
    //добавить обработчик для РЕДАКТИРОВАНИЯ ManagerId в Project (отправка по Id выбранного проекта)
  }

  deleteRequest(id: string) {
    this.httpService.deleteRequest(id)
      .subscribe(result => { console.log(result) }, error => console.error(error), () => this.ngOnInit());
  }

  check() {
    this.ngOnInit();
  }

  callback(result) {
    console.log(result);
    this.i++;
    console.log(this.i);
    if (this.i == 4) {
      this.constructArray();
    }
  }

  constructArray() {
    if (!this.requests.length) {
      this.requestViewModels = [];
      console.log('requests.length = 0');
      return;
    }
    var emp: EmployeeBase = new EmployeeBase();
    var prj: Project = new Project();
    var sprj: Subproject = new Subproject();

    this.requestViewModels = [];
    this.requests.forEach((request, i) => {
      this.requestViewModels.push(new RequestViewModel());
      this.requestViewModels[i].requestId = request.requestId;
      this.requestViewModels[i].requestNumber = request.requestNumber;
      this.requestViewModels[i].date = request.date;
      this.requestViewModels[i].businessTripNumber = request.businessTripNumber;
      this.requestViewModels[i].budget = request.budget;
      this.requestViewModels[i].cost = request.cost;
      this.requestViewModels[i].status = request.status;

      emp = this.employeesBase.find(x => x.employeeBaseId == request.declarerId)
      this.requestViewModels[i].declarer = emp.name;
      emp = this.employeesBase.find(x => x.employeeBaseId == request.managerId)
      this.requestViewModels[i].manager = emp.name;
      emp = this.employeesBase.find(x => x.employeeBaseId == request.officeManagerId)
      this.requestViewModels[i].officeManager = emp.name;

      prj = this.projects.find(x => x.projectId == request.projectId)
      this.requestViewModels[i].project = prj.name;

      sprj = this.subprojects.find(x => x.subprojectId == request.subprojectId)
      this.requestViewModels[i].subproject = sprj.name;
      
    })
  }

  onChange(newValue) {
    var i = 0;
    this.localSubprojects = [];
    console.log(newValue);
    this.newRequest.projectId = newValue;
    this.subprojects.forEach((sprj) => {
      if (sprj.projectId == newValue) {
        this.localSubprojects.push(new Subproject());
        this.localSubprojects[i] = sprj;
        i++;
      }
    });
    // ... do other stuff here ...
  }

  //реализовать через типы БД с помощью [ngValue]
}
