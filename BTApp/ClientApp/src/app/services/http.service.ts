import { Inject } from '@angular/core';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { EmployeeBase, Employee, EmployeeBaseProjectAssign, EmployeeRouteAssign, Request, Project, Route, Subproject, Ticket } from '../models/models';
@Injectable()
export class HttpService {
  private baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') url: string) {
    this.baseUrl = url;
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



  getEmployee() {
    return this.http.get<Employee[]>(this.baseUrl + `api/Employees`);
  }

  postEmployee(employee: Employee) {
    return this.http.post<Employee>(this.baseUrl + `api/Employees`, employee);
  }

  putEmployee(id: string, employee: Employee) {
    return this.http.put<Employee>(this.baseUrl + `api/Employees/${id}`, employee);

  }

  deleteEmployee(id: string) {
    return this.http.delete<Employee>(this.baseUrl + `api/Employees/${id}`);
  }



  getRequest() {
    return this.http.get<Request[]>(this.baseUrl + `api/Requests`)
  }

  postRequest(request: Request) {
    return this.http.post<Request>(this.baseUrl + `api/Requests`, request);
  }

  putRequest(id: string, request: Request) {
    return this.http.put<Request>(this.baseUrl + `api/Requests/${id}`, request);

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



  getRoute() {
    return this.http.get<Route[]>(this.baseUrl + `api/Routes`)
  }

  postRoute(route: Route) {
    return this.http.post<Route>(this.baseUrl + `api/Routes`, route)
  }

  putRoute(id: string, route: Route) {
    return this.http.put<Route>(this.baseUrl + `api/Routes/${id}`, route);
  }

  deleteRoute(id: string) {
    return this.http.delete<Route>(this.baseUrl + `api/Routes/${id}`);
  }



  getTicket() {
    return this.http.get<Ticket[]>(this.baseUrl + `api/Tickets`)
  }

  postTicket(ticket: Ticket) {
    return this.http.post<Ticket>(this.baseUrl + `api/Tickets`, ticket)
  }

  putTicket(id: string, ticket: Ticket) {
    return this.http.put<Ticket>(this.baseUrl + `api/Tickets/${id}`, ticket);

  }

  deleteTicket(id: string) {
    return this.http.delete<Ticket>(this.baseUrl + `api/Tickets/${id}`);
  }
}
