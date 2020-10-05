import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PricingRequestFormComponent } from './pricing-request-form.component';

describe('PricingRequestFormComponent', () => {
  let component: PricingRequestFormComponent;
  let fixture: ComponentFixture<PricingRequestFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PricingRequestFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PricingRequestFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
