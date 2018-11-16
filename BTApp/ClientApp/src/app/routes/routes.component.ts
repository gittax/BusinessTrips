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

  newRoute: Route = new Route();

  constructor(private httpService: HttpService) { }

  ngOnInit() {

    this.i = 0;
    this.newRoute = new Route();

    this.httpService.getRequest()
      .subscribe(result => { this.requests = result; }, error => console.error(error));

    this.httpService.getRoute()
      .subscribe(result => { this.routes = result; }, error => console.error(error));
  }

  addRoute(newRoute: Route) {
    this.httpService.postRoute(newRoute)
      .subscribe(result => { console.log(result) }, error => console.error(error), () => this.ngOnInit());
  }

  deleteRoute(id: string) {
    this.httpService.deleteRoute(id)
      .subscribe(result => { console.log(result) }, error => console.error(error), () => this.ngOnInit());
  }

  check() {
    this.ngOnInit();
  }

}
