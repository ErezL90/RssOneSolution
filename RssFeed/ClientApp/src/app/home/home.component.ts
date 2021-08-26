import { Component, OnInit } from '@angular/core';
import { IFeed } from '../models/feed.iterface';
import { IRss } from '../models/rss.iterface';
import { RssfeedService } from '../services/rssfeed.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private rssfeedService: RssfeedService) { }

  public selected:number=0;
  public items: Array<IFeed> = [];
  public titleList:string ="";

  public categories: Array<IRss> = [
    { id: "12837", rssName: "קורונה" },
    { id: "2689", rssName: "צבא ובטחון" },
    { id: "5700", rssName: "מדע וסביבה" },
    { id: "272", rssName: "מוזיקה" },
    { id: "156", rssName: "כדורגל ישראלי" },
  ]
  ngOnInit(): void {
    this.dataRss(this.categories[0].id);
  }

  public onCategoryClick(cat: string, i:number) {
    this.selected=i;
    this.dataRss(cat);

  }
  public refreshData(){
    this.dataRss(this.categories[this.selected].id);
  }

  private dataRss(cat:string){
    this.rssfeedService.getAllFeeds(cat).subscribe(
      (data) => {
        this.items = data.list;
        this.titleList = data.nameList;
      },
      (error)=>{
        console.log("ERR"+ error);
      }
    )
  }

}
