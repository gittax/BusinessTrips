import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { HttpService } from '../services/http.service';
import { EmployeeBase, Request, Project, Subproject, RequestViewModel, LookUpClass } from '../models/models';
import { PageEvent, MatPaginator, MatTableDataSource, MatSort } from '@angular/material';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  providers: [HttpService]
})

export class HomeComponent implements OnInit {
  private i: number;
  public isLoading: boolean = true;
  public requests: Request[];
  public requestViewModels: RequestViewModel[];
  public employeesBase: EmployeeBase[];
  public projects: Project[];
  public subprojects: Subproject[];
  public statuses: LookUpClass[];
  newRequest: Request = new Request();
  pageEvent: PageEvent;
  
  columnsToDisplay: string[] = ['requestId', 'date', 'declarer', 'project', 'subproject', 'requestNumber', 'budget', 'cost', 'manager', 'status', 'officeManager'];
  dataSource = new MatTableDataSource<RequestViewModel>([]);

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  constructor(private httpService: HttpService) { }

  ngOnInit() {
    this.isLoading = true;

    this.i = 0;
    this.newRequest = new Request();

    this.getEmployeeBase();
    this.getRequests();
    this.getProjects();
    this.getSubprojects();
    this.getRequestStatuses();
  }

  ngAfterViewInit() {
  }

  getEmployeeBase() {
    this.httpService.getEmployeeBase()
      .subscribe(result => { this.employeesBase = result; }, error => console.error(error), () => this.callback(this.employeesBase));
  }

  getRequests() {
    this.httpService.getRequest()
      .subscribe(result => { this.requests = result; }, error => console.error(error), () => this.callback(this.requests));
  }

  getProjects() {
    this.httpService.getProject()
      .subscribe(result => { this.projects = result; }, error => console.error(error), () => this.callback(this.projects));
  }

  getSubprojects() {
    this.httpService.getSubproject()
      .subscribe(result => { this.subprojects = result; }, error => console.error(error), () => this.callback(this.subprojects));
  }

  getRequestStatuses() {
    this.httpService.getRequestStatuses()
      .subscribe(result => { this.statuses = result; }, error => console.log(error), () => this.callback(this.statuses));
  }

  addRequest(newRequest: Request) {
    this.httpService.postRequest(newRequest)
      .subscribe(result => { console.log(result) }, error => console.error(error), () => this.getRequests());
  }
  
  editRequest(id: string, request: Request) {
    this.httpService.putRequest(id, request)
      .subscribe(result => { console.log(result) }, error => console.error(error), () => this.getRequests());
  }

  deleteRequest(id: string) {
    this.httpService.deleteRequest(id)
      .subscribe(result => { console.log(result) }, error => console.error(error), () => this.getRequests());
  }

  callback(result) {
    console.log(result);
    this.i++;
    console.log(this.i);
    if (this.i == 5) {
      this.constructArray();
    }
  }

  constructArray() {
    if (!this.requests.length) {
      this.requestViewModels = [];
      console.log('requests.length = 0');
      return;
    }
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
      this.requestViewModels[i].status = this.statuses.find(x=>x.value==request.status).text;

      this.requestViewModels[i].declarer = this.employeesBase.find(x => x.employeeBaseId == request.declarerId).name;
      this.requestViewModels[i].manager = this.employeesBase.find(x => x.employeeBaseId == request.managerId).name;
      this.requestViewModels[i].officeManager = this.employeesBase.find(x => x.employeeBaseId == request.officeManagerId).name;

      prj = this.projects.find(x => x.projectId == request.projectId)
      if (prj) {
        this.requestViewModels[i].project = prj.name;
      }

      sprj = this.subprojects.find(x => x.subprojectId == request.subprojectId)
      if (sprj) {
        this.requestViewModels[i].subproject = sprj.name;
      }
    })

    this.dataSource = new MatTableDataSource<RequestViewModel>(this.requestViewModels);
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
    this.isLoading = false;
  }

  applyFilter(filterValue: string) {
    filterValue = filterValue.trim(); // Remove whitespace
    filterValue = filterValue.toLowerCase(); // MatTableDataSource defaults to lowercase matches
    this.dataSource.filter = filterValue;
  }
}
