import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { MatButtonModule, MatDialogModule, MatIconModule, MatInputModule, MatPaginatorModule, MatSortModule,
  MatTableModule, MatToolbarModule } from '@angular/material';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { EmployeesComponent } from './employees/employees.component';
import { RoutesComponent } from './routes/routes.component';
import { TicketsComponent } from './tickets/tickets.component';
import { EditDialogComponent } from './home/dialogs/edit.dialog/edit.dialog.component';
import { AddDialogComponent } from './home/dialogs/add.dialog/add.dialog.component';
import { DeleteDialogComponent } from './home/dialogs/delete.dialog/delete.dialog.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    EmployeesComponent,
    RoutesComponent,
    TicketsComponent,
    EditDialogComponent,
    AddDialogComponent,
    DeleteDialogComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    MatTableModule,
    MatInputModule,
    MatDialogModule,
    MatSortModule,
    MatPaginatorModule,
    MatButtonModule,
    MatToolbarModule,
    MatIconModule,
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
