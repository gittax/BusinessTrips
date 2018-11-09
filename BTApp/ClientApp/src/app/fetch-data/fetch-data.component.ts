import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

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

