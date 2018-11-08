import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from "rxjs/Observable";
import { of } from "rxjs/observable/of";
import { catchError, map, tap } from 'rxjs/operators';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  private http: HttpClient;
  public forecasts: WeatherForecast[];
  public employeesBase: EmployeeBase;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<WeatherForecast[]>(baseUrl + 'api/SampleData/WeatherForecasts').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
    http.get<EmployeeBase>(baseUrl + `api/EmployeeBases/1`).subscribe(result => {
      this.employeesBase = result;
    }, error => console.error(error));
  }

  getEmployee(id: number, @Inject('BASE_URL') baseUrl: string){
    return this.http.get<EmployeeBase[]>(baseUrl + `api/EmployeeBases/${id}`).pipe(
      catchError(this.handleError<EmployeeBase[]>(`getHero id=${id}`)));
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
  EmployeeBaseId: number;
  Code: string;
  Name: string;
}
interface WeatherForecast {
  dateFormatted: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

