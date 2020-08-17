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
    Cena: "150den",
    Date: "01/02/2020"},
    {Name: "Kurs po angliski jazik",
    Tutor: "Viktor Sadikovic",
    Cena: "300den",
    Date: "01/02/2020"},
    {Name: "Kurs po angliski jazik",
    Tutor: "Viktor Sadikovic",
    Cena: "400den",
    Date: "01/02/2020"}
  ]
  intermediates = [
    {Name: "Kurs po francuski jazik",
    Tutor: "Viktor Sadikovic",
    Cena: "150den",
    Date: "01/02/2020"},
    {Name: "Kurs po angliski jazik",
    Tutor: "Filip Spirovski",
    Cena: "300den",
    Date: "01/02/2020"},
    {Name: "Kurs po angliski jazik",
    Tutor: "Viktor Sadikovic",
    Cena: "400den",
    Date: "01/02/2020"}
  ]
  advanceds = [
    {Name: "Kurs po francuski jazik",
    Tutor: "Viktor Sadikovic",
    Cena: "150den",
    Date: "01/02/2020"},
    {Name: "Kurs po angliski jazik",
    Tutor: "Filip Spirovski",
    Cena: "300den",
    Date: "01/02/2020"},
    {Name: "Kurs po angliski jazik",
    Tutor: "Viktor Sadikovic",
    Cena: "400den",
    Date: "01/02/2020"}
  ]
}
