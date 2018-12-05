import { Component, OnInit} from '@angular/core';
import { HttpService } from '../services/http.service';
import { Request, Route, LookUpClass } from '../models/models';
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
  public routeTypes: LookUpClass[];
  public ticketTypes: LookUpClass[];
  public classTypes: LookUpClass[];

  constructor(private httpService: HttpService) { }

  ngOnInit() {
    this.getRequests();
    this.getRoutes();
    this.getTypes();
    this.getFilteredClasses = this.getFilteredClasses.bind(this);
  }

  getRequests() {
    this.httpService.getRequest()
      .subscribe(result => { this.requests = result; }, error => console.error(error));
  }

  getRoutes(){
    this.httpService.getRoute()
      .subscribe(result => { this.routes = result; }, error => console.error(error));
  }

  getTypes() {
    this.httpService.getRouteTypes()
      .subscribe(result => { this.routeTypes = result; }, error => console.error(error));

    this.httpService.getTicketTypes()
      .subscribe(result => { this.ticketTypes = result; }, error => console.error(error));

    this.httpService.getClassTypes()
      .subscribe(result => { this.classTypes = result; }, error => console.error(error));
  }

  getFilteredClasses(options) {
    return {
      store: this.classTypes,
      filter: options.data ? ["routeType", "=", options.data.routeType] : null
    };
  }

  onEditorPreparing(e) {
    e.editorOptions.disabled = e.parentType === "dataRow" && e.dataField === "routeId";
    if (e.parentType === "dataRow" && e.dataField === "classType") {
      e.editorOptions.disabled = (typeof e.row.data.routeType !== "number");
    }
  };

  setRouteTypeValue(rowData: any, value: any): void {
    rowData.classType = null;
    (<any>this).defaultSetCellValue(rowData, value);
  }

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
      .subscribe(result => { console.log(result) }, error => console.error(error), () => this.getRoutes());
  }

  editRoute(id: string, route: Route) {
    this.httpService.putRoute(id, route)
      .subscribe(result => { console.log(result) }, error => console.error(error), () => this.getRoutes());
  }

  deleteRoute(id: string) {
    this.httpService.deleteRoute(id)
      .subscribe(result => { console.log(result) }, error => console.error(error), () => this.getRoutes());
  }
}
