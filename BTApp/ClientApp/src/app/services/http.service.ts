import { Inject } from '@angular/core';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { EmployeeBase, Employee, EmployeeBaseProjectAssign, EmployeeRouteAssign, Request, Project, Route, Subproject, Ticket } from '../models/models';
@Injectable()
export class HttpService {
  private baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') url: string) {
    this.baseUrl = url
  }

  getEmployeeBase() {
    return this.http.get<EmployeeBase[]>(this.baseUrl + `api/EmployeeBases`);
  }

  postEmployeeBase(employeeBase: EmployeeBase) {
    return this.http.post<EmployeeBase>(this.baseUrl + `api/EmployeeBases`, employeeBase);
  }

  deleteEmployeeBase(id: string) {
    return this.http.delete<EmployeeBase>(this.baseUrl + `api/EmployeeBases/${id}`);
  }



  getRequest() {
    return this.http.get<Request[]>(this.baseUrl + `api/Requests`)
  }

  postRequest(request: Request) {
    return this.http.post<Request>(this.baseUrl + `api/Requests`, request);
  }

  deleteRequest(id: string) {
    return this.http.delete<Request>(this.baseUrl + `api/Requests/${id}`);
  }



  getProject() {
    return this.http.get<Project[]>(this.baseUrl + `api/Projects`)
  }

  getSubproject() {
    return this.http.get<Subproject[]>(this.baseUrl + `api/Subprojects`)
  }
}
