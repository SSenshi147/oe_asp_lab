import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MilesKmConverterComponent } from './miles-km-converter.component';

describe('MilesKmConverterComponent', () => {
  let component: MilesKmConverterComponent;
  let fixture: ComponentFixture<MilesKmConverterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MilesKmConverterComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MilesKmConverterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
