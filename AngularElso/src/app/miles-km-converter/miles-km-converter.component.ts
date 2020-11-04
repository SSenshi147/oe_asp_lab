import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-miles-km-converter',
  templateUrl: './miles-km-converter.component.html',
  styleUrls: ['./miles-km-converter.component.css']
})
export class MilesKmConverterComponent implements OnInit {

  public miles: number;
  
  constructor() {}

  calculate(inputkm: HTMLInputElement){
    const km = parseFloat(inputkm.value);
    this.miles = km * 0.621371;
    inputkm.value='';
  }

  reset(){
    this.miles=0;
  }

  ngOnInit(): void {
  }

}
