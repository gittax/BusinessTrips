import { Component, OnInit } from '@angular/core';
import { HttpService } from '../services/http.service';
import { EmployeeBase, Employee, EmployeeBaseProjectAssign, EmployeeRouteAssign, Request, Project, Route, Subproject, Ticket, RequestViewModel } from '../models/models';

@Component({
  selector: 'app-routes',
  templateUrl: './routes.component.html',
  styleUrls: ['./routes.component.css'],
  providers: [HttpService]
})
export class RoutesComponent implements OnInit {

  private i: number;
  public routes: Route[];
  public requests: Request[];
  done: boolean = false;

  routeViewModels: Route[];

  newRoute: Route = new Route();

  constructor(private httpService: HttpService) { }

  items: Route[] = this.routeViewModels;

  pageOfItems: Route[];

  ngOnInit() {

    this.i = 0;
    this.newRoute = new Route();

    this.httpService.getRequest()
      .subscribe(result => { this.requests = result; }, error => console.error(error), () => this.callback(this.requests));

    this.httpService.getRoute()
      .subscribe(result => { this.routes = result; }, error => console.error(error), () => this.callback(this.routes));
  }

  addRoute(newRoute: Route) {
    this.httpService.postRoute(newRoute)
      .subscribe(result => { console.log(result) }, error => console.error(error), () => this.ngOnInit());
  }

  editRoute(id: string, route: Route) {
    this.httpService.putRoute(id, route)
      .subscribe(result => { console.log(result) }, error => console.error(error), () => this.ngOnInit());
    var editButton = document.getElementsByClassName('edit');
    var addButton = document.getElementsByClassName('add');
    addButton[0].removeAttribute('hidden');
    editButton[0].setAttribute('hidden', '');
  }

  deleteRoute(id: string) {
    this.httpService.deleteRoute(id)
      .subscribe(result => { console.log(result) }, error => console.error(error), () => this.ngOnInit());
  }

  check() {
    this.ngOnInit();
  }

  callback(result) {
    console.log(result);
    this.i++;
    console.log(this.i);
    if (this.i == 2) {
      this.constructArray();
    }
  }

  constructArray() {

    this.routeViewModels = [];
    this.routes.forEach((rts,i) => {
      this.routeViewModels.push(new Route());
      this.routeViewModels[i].arrivalCity = rts.arrivalCity;
      this.routeViewModels[i].arrivalTime = rts.arrivalTime;
      this.routeViewModels[i].budget = rts.budget;
      this.routeViewModels[i].classType = rts.classType;
      this.routeViewModels[i].departureCity = rts.departureCity;
      this.routeViewModels[i].departureTime = rts.departureTime;
      this.routeViewModels[i].flightNumber = rts.flightNumber;
      this.routeViewModels[i].requestId = rts.requestId;
      this.routeViewModels[i].routeId = rts.routeId;
      this.routeViewModels[i].routeType = rts.routeType;
      this.routeViewModels[i].ticketType = rts.ticketType;
    })
  }

  goEdit(id: string) {
    var editButton = document.getElementsByClassName('edit');
    var addButton = document.getElementsByClassName('add');
    editButton[0].removeAttribute('hidden');
    addButton[0].setAttribute('hidden', '');

    var nid = +id;

    var rt: Route = this.routes.find(x => x.routeId == nid)

    this.newRoute = rt;
  }

  onChangePage(pageOfItems: RequestViewModel[]) {
    // update current page of items
    this.pageOfItems = pageOfItems;
  }
}
