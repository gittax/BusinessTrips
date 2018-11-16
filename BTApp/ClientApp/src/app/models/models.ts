import { Time } from "@angular/common";

export class EmployeeBase{
  employeeBaseId: number;
  code: string;
  name: string;
}

export class Employee {
  employeeId: number;
  employeeBaseId: number;
  docType: string;
  docNumber: string;
  validThrough: Date;
  gender: string;
  birthDate: Date;
  birthPlace: string;
  requestId: number;
}

export class EmployeeViewModel {
  employeeId: number;
  employeeBase: string;
  docType: string;
  docNumber: string;
  validThrough: Date;
  gender: string;
  birthDate: Date;
  birthPlace: string;
  requestId: number;
}

export class EmployeeBaseProjectAssign {
  employeeBaseId: number;
  projectId: number;
  employeeId: number;
}

export class EmployeeRouteAssign {
  employeeId: number;
  routeId: number;
}

export class Project {
  projectId: number;
  name: string;
  managerId: number;
}

export class Request {
  requestId: number;
  requestNumber: string;
  date: Date;
  businessTripNumber: string;
  budget: number;
  cost: number;
  status: string;
  declarerId: number;
  managerId: number;
  officeManagerId: number;
  projectId: number;
  subprojectId: number;
}

export class RequestViewModel {
  requestId: number;
  requestNumber: string;
  date: Date;
  businessTripNumber: string;
  budget: number;
  cost: number;
  status: string;
  declarer: string;
  manager: string;
  officeManager: string;
  project: string;
  subproject: string;
}

export class Route {
  routeId: number;
  routeType: string;
  departureTime: Date;
  arrivalTime: Date;
  ticketType: string;
  departureCity: string;
  arrivalCity: string;
  flightNumber: string;
  classType: string;
  budget: number;
  requestId: number;
}

export class Subproject {
  subprojectId: number;
  name: string;
  projectId: number;
}

export class Ticket {
  ticketId: number;
  cost: number;
  routeType: string;
  departureTime: Date;
  arrivalTime: Date;
  employeeBaseId: number;
  requestId: number;
}

export class TicketViewModel {
  ticketId: number;
  cost: number;
  routeType: string;
  departureTime: Date;
  arrivalTime: Date;
  employeeBase: string;
  requestId: number;
}
