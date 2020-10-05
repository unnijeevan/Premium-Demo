import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-pricing-request-form',
  templateUrl: './pricing-request-form.component.html',
  styleUrls: ['./pricing-request-form.component.scss']
})
export class PricingRequestFormComponent implements OnInit {

  form: FormGroup;
  max:Date = new Date();
  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    this.form = this.fb.group({
        name: ['', Validators.required],
        dob:[undefined, Validators.required],
        occupation:[undefined, Validators.required],
        amount:['', [Validators.required,Validators.pattern('^-?[0-9]\\d*(\\.\\d{1,2})?$')]]
    });
  }

}
