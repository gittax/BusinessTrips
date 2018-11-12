import { Component, OnInit, Inject } from '@angular/core';
import { HttpService } from '../services/http.service';
import { EmployeeBase } from '../models/models';
import { TicketRequest } from '../models/models';

@Component({
  selector: 'app-ticket-request',
  templateUrl: './ticket-request.component.html',
  styleUrls: ['./ticket-request.component.css'],
  providers: [HttpService]
})

export class TicketRequestComponent implements OnInit {
  public ticketRequests: TicketRequest[];
  public employeesBase: EmployeeBase[];
  done: boolean = false;
  employeeBase: EmployeeBase = new EmployeeBase();
  ticketRequest: TicketRequest = new TicketRequest();

  constructor(private httpService: HttpService) {}

  ngOnInit() {
    this.httpService.getEmployeeBase()
      .subscribe(result => { this.employeesBase = result; }, error => console.error(error));

    this.httpService.getTicketRequest()
      .subscribe(result => { this.ticketRequests = result; }, error => console.error(error));

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

  addTicketRequest(newTicketRequest: TicketRequest) {
    this.httpService.postTicketRequest(newTicketRequest)
      .subscribe(result => { console.log(result) }, error => console.error(error));
    this.ngOnInit();
  }

  deleteTicketRequest(id: string) {
    this.httpService.deleteTicketRequest(id)
      .subscribe(result => { console.log(result) }, error => console.error(error));
    this.ngOnInit();
  }

  check() {
    this.ngOnInit();
    //console.log(this.employeesBase);
    //console.log(this.declarer);
  }

}
