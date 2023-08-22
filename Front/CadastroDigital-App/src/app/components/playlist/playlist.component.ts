import { Component, Input, OnInit } from '@angular/core';
import { PlayList } from '@app/models/playlist';
import { PageDirection } from '@app/models/pageDirectionEnum';
import { PlaylistService } from '@app/services/playlist.service';

@Component({
  selector: 'app-playlist',
  templateUrl: './playlist.component.html',
  styleUrls: ['./playlist.component.scss']
})
export class PlaylistComponent implements OnInit {

  @Input() playList: PlayList;

  PageDirection = PageDirection;
  finding = false;
  error = false;

  constructor(private playListService: PlaylistService) { }

  ngOnInit() {
    alert('teste')

  }

  movePage(direction: PageDirection) {
    this.finding = true;
    this.error = false;
    this.playListService.movePage(this.playList, direction)
      .subscribe(playList => {
        this.playList = playList;
        this.finding = false;
      }, err => {
        this.finding = false;
        this.error = true;
        console.log(err);
      });
  }

}
