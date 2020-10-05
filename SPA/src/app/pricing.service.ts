import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from './../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PricingService {

  constructor(private httpClient:HttpClient) { }

  //this should be in a lookupservice and be cached
  getOccupations():Observable<Occupation[]>{
   return this.httpClient.get<Occupation[]>(environment.application_url+"/occupation");
  }

  calculateMonthlyPremimum(dob: Date, amount: number, occupation:string): Observable<number>
  {
    let pricingRequest = { age: this.calculateAge(dob), coverAmount: amount, occupationId: occupation };
    return this.httpClient.post<number>(environment.application_url+"/pricing", pricingRequest);
  }

   //This could be moved to utilites service
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

