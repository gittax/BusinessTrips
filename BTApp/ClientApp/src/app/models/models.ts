export class EmployeeBase{
  employeeBaseId: number;
  code: string;
  name: string;
  employeeProjectAssigns: string;
}

export class TicketRequest {
  requestId: number;
  requestNumber: string;
  date: Date;
  declarer: EmployeeBase;
  businessTripNumber: string;
  budget: number;
  cost: number;
  manager: EmployeeBase;
  status: string;
  officeManager: EmployeeBase;
}
