import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-announcement-thumbnail',
  templateUrl: './announcement-thumbnail.component.html',
  styleUrls: ['./announcement-thumbnail.component.css']
})
export class AnnouncementThumbnailComponent implements OnInit {
  @Input() niza

  constructor() { }

  ngOnInit(): void {
  }

}
