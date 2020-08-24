import { Component, OnInit } from '@angular/core';
import { DataService } from '../shared/dataservice.service';
import { Announcement } from '../shared/appmodels.model';
import { ActivatedRoute, Params } from '@angular/router';

@Component({
  selector: 'app-announcement-details',
  templateUrl: './announcement-details.component.html',
  styleUrls: ['./announcement-details.component.css']
})
export class AnnouncementDetailsComponent implements OnInit {
  announcement: Announcement;
  stars = [1,2,3,4,5]
  rating = 0;
  hoverState = 0;


  constructor(private service: DataService, private route: ActivatedRoute) { }

  ngOnInit(): void {

    this.route.params.forEach((params: Params) => {
      this.service.getAnnouncement(+params['id']).subscribe((ann: Announcement) => {
        this.announcement = ann;
        console.log("Announcement = ");
        console.log(this.announcement)
        this.rating = this.announcement.score

        // this.getTutor(+this.post.albumId)
      })
    })

  }

  onStarEnter(starId: number){
    this.hoverState = starId;
  }

  onStarLeave(){
    this.hoverState = 0;
  }

  onStarClicked(starId: number){
    this.rating = starId;
    this.announcement.score = this.rating;
  }
  

}
