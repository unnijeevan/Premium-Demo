import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PricingService, Occupation } from '../pricing.service';
@Component({
  selector: 'app-pricing-request-form',
  templateUrl: './pricing-request-form.component.html',
  styleUrls: ['./pricing-request-form.component.scss']
})
export class PricingRequestFormComponent implements OnInit {

  form: FormGroup;
  max:Date = new Date();
  occupationOptions: Occupation[];
  monthlyPremium:number;
  constructor(private fb: FormBuilder, private pricingService: PricingService) { }

  ngOnInit(): void {

    this.pricingService.getOccupations().subscribe( 
      x => {
       this.occupationOptions = x;
       this.form = this.fb.group({
        name: ['', Validators.required],
        dob:[undefined, Validators.required],
        occupation:[undefined, Validators.required],
        amount:['', [Validators.required,Validators.pattern('^-?[0-9]\\d*(\\.\\d{1,2})?$')]]
    });
    });
   
  }

  calculatePrice()
  {
     if(this.form.valid)
     {
       this.pricingService.calculateMonthlyPremimum(
         this.form.get("dob").value,
         this.form.get("amount").value,
         this.form.get("occupation").value
       ).subscribe(x=>{
         this.monthlyPremium = x;
       });
     }
     else
      this.monthlyPremium = undefined;

  }

}
