import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TvShowApiService {

  constructor(public http: HttpClient) {
    //this.http = new HttpClient();
   }

   GetAll(){
    this.http.get("http://localhost:44498/");
   }

}
