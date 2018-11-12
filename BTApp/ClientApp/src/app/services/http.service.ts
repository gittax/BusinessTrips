import { Inject } from '@angular/core';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { EmployeeBase } from '../models/models';
import { TicketRequest } from '../models/models';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

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

  getTicketRequest() {
    return this.http.get<TicketRequest[]>(this.baseUrl + `api/Requests`)
  }

  postTicketRequest(ticketRequest: TicketRequest/*, declarer: EmployeeBase, manager: EmployeeBase, officeManager: EmployeeBase*/) {
    /* ticketRequest.declarer = declarer;
    ticketRequest.manager = manager;
    ticketRequest.officeManager = officeManager;*/
    return this.http.post<TicketRequest>(this.baseUrl + `api/Requests`, ticketRequest);
  }

  deleteTicketRequest(id: string) {
    return this.http.delete<TicketRequest>(this.baseUrl + `api/Requests/${id}`);
  }
}
