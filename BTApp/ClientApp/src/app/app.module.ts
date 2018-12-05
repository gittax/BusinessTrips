import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule, MatInputModule } from '@angular/material';
import { MatSortModule } from '@angular/material/sort'; 
import { DxDataGridModule } from 'devextreme-angular';
import { LoggerModule, NgxLoggerLevel } from 'ngx-logger';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { EmployeesComponent } from './employees/employees.component';
import { RoutesComponent } from './routes/routes.component';
import { TicketsComponent } from './tickets/tickets.component';
import { JwPaginationComponent } from 'jw-angular-pagination';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    EmployeesComponent,
    RoutesComponent,
    JwPaginationComponent,
    TicketsComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    MatTableModule,
    MatInputModule,
    MatSortModule,
    MatPaginatorModule,
    DxDataGridModule,
    LoggerModule.forRoot({ serverLoggingUrl: '/api/Logs', level: NgxLoggerLevel.DEBUG, serverLogLevel: NgxLoggerLevel.DEBUG }),
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'employees', component: EmployeesComponent },
      { path: 'routes', component: RoutesComponent },
      { path: 'tickets', component: TicketsComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
