import { Component, OnInit } from '@angular/core';
import { Announcement } from '../shared/appmodels.model';
import { DataService } from '../shared/dataservice.service';
import { ActivatedRoute, Params } from '@angular/router';

@Component({
  selector: 'app-single-category',
  templateUrl: './single-category.component.html',
  styleUrls: ['./single-category.component.css']
})
export class SingleCategoryComponent implements OnInit {
  announcements: Announcement[]
  beginner_level: Announcement[]
  intermediate_level: Announcement[]
  advanced_level: Announcement[]

  constructor(private service: DataService, private route: ActivatedRoute) { }

  ngOnInit(): void {

    this.route.params.forEach((params: Params) => {
      this.service.getAnnouncements().subscribe( data => {
        console.log(data);

        this.announcements = data.filter( array => {
          return array.field.toLocaleLowerCase() == params['type'];
        });

        this.beginner_level = this.announcements.filter( array => {
          return array.difficulty.toLocaleLowerCase() == "beginner"
        });

        this.intermediate_level = this.announcements.filter( array => {
          return array.difficulty.toLocaleLowerCase() == "intermediate"
        });

        this.advanced_level = this.announcements.filter( array => {
          return array.difficulty.toLocaleLowerCase() == "advanced"
        });
      })
    })

  }


}
