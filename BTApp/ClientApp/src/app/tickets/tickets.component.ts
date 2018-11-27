import { Component, OnInit } from '@angular/core';
import { HttpService } from '../services/http.service';
import { EmployeeBase, Employee, Request, Ticket, TicketViewModel, EmployeeBaseViewModel} from '../models/models';

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
  employeeBaseViewModels: EmployeeBaseViewModel[];

  newTicket: Ticket = new Ticket();

  constructor(private httpService: HttpService) { }

  items: TicketViewModel[] = this.ticketViewModels;

  pageOfItems: TicketViewModel[];

  ngOnInit() {

    this.i = 0;
    this.newTicket = new Ticket();

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

  editTicket(id: string, ticket: Ticket) {
    this.httpService.putTicket(id, ticket)
      .subscribe(result => { console.log(result) }, error => console.error(error), () => this.ngOnInit());
    var editButton = document.getElementsByClassName('edit');
    var addButton = document.getElementsByClassName('add');
    addButton[0].removeAttribute('hidden');
    editButton[0].setAttribute('hidden', '');
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

    var emp: Employee = new Employee();
    var empb: EmployeeBase = new EmployeeBase();

    this.employeeBaseViewModels = [];
    this.employees.forEach((employee, i) => {
      this.employeeBaseViewModels.push(new EmployeeBaseViewModel());

      this.employeeBaseViewModels[i].employeeId = employee.employeeId;
      empb = this.employeesBase.find(x => x.employeeBaseId == employee.employeeBaseId);
      this.employeeBaseViewModels[i].name = empb.name;
      this.employeeBaseViewModels[i].code = empb.code;
      this.employeeBaseViewModels[i].employeeBaseId = empb.employeeBaseId;
    })

    if (!this.tickets.length) {
      this.ticketViewModels = [];
      console.log('tickets.length = 0');
      return;
    }

    this.ticketViewModels = [];
    this.tickets.forEach((ticket, i) => {
      this.ticketViewModels.push(new TicketViewModel());
      this.ticketViewModels[i].ticketId = ticket.ticketId;
      this.ticketViewModels[i].cost = ticket.cost;
      this.ticketViewModels[i].routeType = ticket.routeType;
      this.ticketViewModels[i].departureTime = ticket.departureTime;
      this.ticketViewModels[i].arrivalTime = ticket.arrivalTime;
      this.ticketViewModels[i].requestId = ticket.requestId;

      emp = this.employees.find(x => x.employeeId == ticket.employeeId)
      empb = this.employeesBase.find(x => x.employeeBaseId == emp.employeeBaseId)
      this.ticketViewModels[i].employee = empb.name;
    });
  }

  goEdit(id: string) {
    var editButton = document.getElementsByClassName('edit');
    var addButton = document.getElementsByClassName('add');
    editButton[0].removeAttribute('hidden');
    addButton[0].setAttribute('hidden', '');

    var nid = +id;

    var tckt: Ticket = this.tickets.find(x => x.ticketId == nid)

    this.newTicket = tckt;
  }

  onChangePage(pageOfItems: TicketViewModel[]) {
    // update current page of items
    this.pageOfItems = pageOfItems;
  }
}
