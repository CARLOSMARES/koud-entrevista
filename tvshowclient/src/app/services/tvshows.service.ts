import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class TvshowsService {
  constructor(private http: HttpClient) {}

  getShows() {
    return this.http.get('http://localhost:5274/api/v1/All');
  }

  searchShow(name: string) {
    return this.http.get(`http://localhost:5274/api/v1/search/${name}`);
  }

  updateShow(tvshow: any) {
    return this.http.put('http://localhost:5274/api/v1', tvshow);
  }

  deleteShow(id: any) {
    return this.http.delete('http://localhost:5274/api/v1/' + id);
  }

  addShow(tvshow: any) {
    return this.http.post('http://localhost:5274/api/v1/New', tvshow);
  }
}
