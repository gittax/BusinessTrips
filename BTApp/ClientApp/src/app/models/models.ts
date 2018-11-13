import { Time } from "@angular/common";

export class EmployeeBase{
  employeeBaseId: number;
  code: string;
  name: string;
}

export class Employee {
  employeeId: number;
  docType: string;
  docNumber: string;
  validThrough: Date;
  gender: string;
  birthDate: Date;
  birthPlace: string;
  employeeBaseId: number;
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
  managerEmployeeBaseId: number;
}

export class Request {
  requestId: number;
  requestNumber: string;
  date: Date;
  businessTripNumber: string;
  budget: number;
  cost: number;
  status: string;
  declarerEmployeeBaseId: number;
  managerEmployeeBaseId: number;
  officeManagerEmployeeBaseId: number;
  projectId: number;
  subprojectId: number;
}

export class Route {
  routeId: number;
  routeType: string;
  departureTime: Time;
  arrivalTime: Time;
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
  departureTime: Time;
  arrivalTime: Time;
  employeeId: number;
  requestId: number;
}
