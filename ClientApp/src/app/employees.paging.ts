import { Employee } from './employee';

export class EmployeesPaging{
    constructor(
        public PageNumber?:number,
        public TotalPages?:number,
        public Items?:Employee[],
        public HasNextPage?:boolean,
        public HasPreviousPage?:boolean,
        public Search?:string
    ){}
}