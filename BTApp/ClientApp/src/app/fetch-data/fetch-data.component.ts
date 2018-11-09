import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from "rxjs/Observable";
import { of } from "rxjs/observable/of";
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

import { Response } from '_debugger';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: WeatherForecast[];
  public employeesBase: EmployeeBase[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<WeatherForecast[]>(baseUrl + 'api/SampleData/WeatherForecasts')
      .subscribe(result => { this.forecasts = result; }, error => console.error(error)); 

    http.get<EmployeeBase[]>(baseUrl + `api/EmployeeBases`)
      .subscribe(result => { this.employeesBase = result; }, error => console.error(error)); 

    http.get<EmployeeBase[]>(baseUrl + `api/EmployeeBases`)
      .subscribe(result => { console.log(result); }, error => console.error(error)); 

    http.get<WeatherForecast[]>(baseUrl + 'api/SampleData/WeatherForecasts')
      .subscribe(result => { console.log(result); }, error => console.error(error));

   /* http.get(baseUrl + `api/EmployeeBases`)
      .map((res: Response) => res)
      .do(value => console.log(value));
     http.get<EmployeeBase[]>(baseUrl + `api/EmployeeBases`)
      .subscribe((data: EmployeeBase[]) => this.employeesBase.forEach(employeeBase => {
        employeeBase.EmployeeBaseId = data['EmployeeBaseId'],
        employeeBase.Code = data['Code'],
        employeeBase.Name = data['Name'],
        employeeBase.EmployeeProjectAssigns = data['EmployeeProjectAssigns'] }, error => console.error(error))); */

  }

  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
 
      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead
 
      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}

interface EmployeeBase {
  employeeBaseId: number;
  code: string;
  name: string;
  employeeProjectAssigns: string;
}
interface WeatherForecast {
  dateFormatted: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

