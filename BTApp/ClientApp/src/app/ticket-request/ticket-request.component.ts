import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { httpFactory } from '@angular/platform-server/src/http';

@Component({
  selector: 'app-ticket-request',
  templateUrl: './ticket-request.component.html',
  styleUrls: ['./ticket-request.component.css']
})

export class TicketRequestComponent implements OnInit {
  public ticketRequests: TicketRequest[];
  public employeesBase: EmployeeBase[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<TicketRequest[]>(baseUrl + `api/Requests`)
      .subscribe(result => { this.ticketRequests = result; }, error => console.error(error)); 
    http.get<TicketRequest[]>(baseUrl + `api/Requests`)
      .subscribe(result => { console.log(result) }, error => console.error(error)); 

    http.get<EmployeeBase[]>(baseUrl + `api/EmployeeBases`)
      .subscribe(result => { this.employeesBase = result; }, error => console.error(error)); 
    http.get<EmployeeBase[]>(baseUrl + `api/EmployeeBases`)
      .subscribe(result => { console.log(result) }, error => console.error(error));
  }

  postRequest(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.post<TicketRequest[]>(baseUrl + `api/Requests`, this.ticketRequests)
  }
  
  ngOnInit() {
  }

}

interface TicketRequest {
  requestId: number;
  requestNumber: string;
  date: Date;
  declarer: EmployeeBase;
  businessTripNumber: string;
  budget: number;
  cost: number;
  manager: EmployeeBase;
  status: string;
  officeManager: EmployeeBase;
}

interface EmployeeBase {
  employeeBaseId: number;
  code: string;
  name: string;
  employeeProjectAssigns: string;
}
