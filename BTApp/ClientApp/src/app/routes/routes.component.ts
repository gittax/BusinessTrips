import { Component, OnInit} from '@angular/core';
import { HttpService } from '../services/http.service';
import { Request, Route } from '../models/models';
import DataSource from "devextreme/data/data_source";

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
  public routeTypes = [
    { "Name": "Flight", "ID": "0" },
    { "Name": "Train", "ID": "1" }
  ];

  public ticketTypes = [
    { text: "Departure", value: "0" },
    { text: "Arrival", value: "1" },
    { text: "Transit", value: "2" }
  ];

  public classTypes = [
    { text: "Economy class", value: "0" },
    { text: "Premium Economy Class", value: "1" },
    { text: "Business class", value: "2" },
    { text: "First class", value: "3" },
    { text: "Coupe", value: "4" },
    { text: "Sit", value: "5" }
  ];

  public flightClassTypes = [
    { text: "Economy class", value: "0" },
    { text: "Premium Economy Class", value: "1" },
    { text: "Business class", value: "2" },
    { text: "First class", value: "3" }
  ];

  public trainClassTypes = [
    { text: "Coupe", value: "4" },
    { text: "Sit", value: "5" }
  ];

  dataSource: DataSource;

  done: boolean = false;

  routeViewModels: Route[];

  newRoute: Route = new Route();

  constructor(private httpService: HttpService) {}

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

  onEditorPreparing(e) {
    e.editorOptions.disabled = e.parentType === "dataRow" && e.dataField === "routeId"
  };

  onRowInserted(e) {
    this.addRoute(e.data);
  }

  onRowUpdated(e) {
    console.log(e.data);
    var rt: Route = this.routes.find(x => x.routeId == e.key)
    var data = Object.assign({}, rt, e.data)
    console.log(data);
    this.editRoute(e.key, data);
  }

  onRowRemoved(e) {
    this.deleteRoute(e.key);
  }

  addRoute(newRoute: Route) {
    this.httpService.postRoute(newRoute)
      .subscribe(result => { console.log(result) }, error => console.error(error), () => this.ngOnInit());
  }

  editRoute(id: string, route: Route) {
    this.httpService.putRoute(id, route)
      .subscribe(result => { console.log(result) }, error => console.error(error), () => this.ngOnInit());
    /*var editButton = document.getElementsByClassName('edit');
    var addButton = document.getElementsByClassName('add');
    addButton[0].removeAttribute('hidden');
    editButton[0].setAttribute('hidden', '');*/
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


    /*this.dataSource = new DataSource({
      store: {
        type: 'array',
        data: this.routeViewModels,
        key: 'routeId'
      }
    });

    console.log(this.dataSource);*/
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

  onChangePage(pageOfItems: Route[]) {
    // update current page of items
    this.pageOfItems = pageOfItems;
  }
}
