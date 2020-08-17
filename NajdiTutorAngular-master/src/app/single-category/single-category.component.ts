import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-single-category',
  templateUrl: './single-category.component.html',
  styleUrls: ['./single-category.component.css']
})
export class SingleCategoryComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  beginners = [
    {Name: "Kurs po angliski jazik",
    Tutor: "Viktor Sadikovic",
    Cena: "150den"},
    {Name: "Kurs po angliski jazik",
    Tutor: "Viktor Sadikovic",
    Cena: "300den"},
    {Name: "Kurs po angliski jazik",
    Tutor: "Viktor Sadikovic",
    Cena: "400den"}
  ]
  intermediates = [
    {Name: "Kurs po francuski jazik",
    Tutor: "Viktor Sadikovic",
    Cena: "150den"},
    {Name: "Kurs po angliski jazik",
    Tutor: "Filip Spirovski",
    Cena: "300den"},
    {Name: "Kurs po angliski jazik",
    Tutor: "Viktor Sadikovic",
    Cena: "400den"}
  ]
  advanceds = [
    {Name: "Kurs po francuski jazik",
    Tutor: "Viktor Sadikovic",
    Cena: "150den"},
    {Name: "Kurs po angliski jazik",
    Tutor: "Filip Spirovski",
    Cena: "300den"},
    {Name: "Kurs po angliski jazik",
    Tutor: "Viktor Sadikovic",
    Cena: "400den"}
  ]
}
