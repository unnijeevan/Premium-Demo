import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { yearsPerPage } from '@angular/material/datepicker';

@Injectable({
  providedIn: 'root'
})
export class PricingService {

  constructor(private httpClient:HttpClient) { }

  getOccupations():Observable<Occupation[]>{
   return this.httpClient.get<Occupation[]>("https://localhost:44316/occupation");
  }

  calculateMonthlyPremimum(dob: Date, amount: number, occupation:string): Observable<number>
  {
    let pricingRequest = { age: this.calculateAge(dob), coverAmount: amount, occupationId: occupation };
    return this.httpClient.post<number>("https://localhost:44316/pricing", pricingRequest);
  }

  calculateAge(dob: Date) : number
  {
    let curDate = new Date();
    let yearsDiff =  curDate.getFullYear() - dob.getFullYear();

    if(curDate.getMonth() < dob.getMonth() || (curDate.getMonth() === dob.getMonth()  && curDate.getDate() < dob.getDate()))
     yearsDiff--;
    
    return yearsDiff; 
  }
}

export class Occupation {
   id:string;
   name:string;
}

