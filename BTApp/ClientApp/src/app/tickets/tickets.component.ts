import { Component, OnInit } from '@angular/core';
import { HttpService } from '../services/http.service';
import { EmployeeBase, Employee, EmployeeBaseProjectAssign, EmployeeRouteAssign, Request, Project, Route, Subproject, Ticket, TicketViewModel} from '../models/models';

@Component({
  selector: 'app-tickets',
  templateUrl: './tickets.component.html',
  styleUrls: ['./tickets.component.css'],
  providers: [HttpService]
})
export class TicketsComponent implements OnInit {

  private i: number;
  public tickets: Ticket[];
  public employees: Employee[];
  public requests: Request[];
  public employeesBase: EmployeeBase[];
  done: boolean = false;

  ticketViewModels: TicketViewModel[];

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

    this.httpService.getTicket()
      .subscribe(result => { this.tickets = result; }, error => console.error(error), () => this.callback(this.tickets));
  }

  addTicket(newTicket: Ticket) {
    this.httpService.postTicket(newTicket)
      .subscribe(result => { console.log(result) }, error => console.error(error), () => this.ngOnInit());
  }

  deleteTicket(id: string) {
    this.httpService.deleteTicket(id)
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
    if (!this.tickets.length) {
      this.ticketViewModels = [];
      console.log('tickets.length = 0');
      return;
    }

    var empb: EmployeeBase = new EmployeeBase();
    var emp: Employee = new Employee();

    this.ticketViewModels = [];
    this.tickets.forEach((ticket, i) => {
      this.ticketViewModels.push(new TicketViewModel());
      this.ticketViewModels[i].ticketId = ticket.ticketId;
      this.ticketViewModels[i].cost = ticket.cost;
      this.ticketViewModels[i].routeType = ticket.routeType;
      this.ticketViewModels[i].departureTime = ticket.departureTime;
      this.ticketViewModels[i].arrivalTime = ticket.arrivalTime;
      this.ticketViewModels[i].requestId = ticket.requestId;
      
      empb = this.employeesBase.find(x => x.employeeBaseId == ticket.employeeBaseId)
      this.ticketViewModels[i].employeeBase = empb.name;
    });
  }
}
