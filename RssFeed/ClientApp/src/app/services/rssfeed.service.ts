import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { ICatrss } from '../models/catrss.iterface';
import { IFeed } from '../models/feed.iterface'

@Injectable({
  providedIn: 'root'
})
export class RssfeedService {

  constructor(private http: HttpClient) { }

  getAllFeeds(cat: string): Observable<ICatrss> {

    return this.http.get(`https://localhost:5001/api/Rss?con=${cat}`).pipe(
      map((data: any) => {
        const feedArray: Array<IFeed> = [];
        for (const id in data.list) {
          feedArray.push(data.list[id]);
        }
        const catRss: ICatrss = { list: feedArray, nameList: data.nameList };
        return catRss;
      })
    );
  }

}
