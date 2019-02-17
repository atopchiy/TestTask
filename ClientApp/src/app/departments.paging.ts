import { Department } from './department';

export class DepartmentsPaging{
    constructor(
        public PageNumber?:number,
        public TotalPages?:number,
        public Items?:Department[],
        public HasNextPage?:boolean,
        public HasPreviousPage?:boolean,
        public Search?:string
    ){}
}