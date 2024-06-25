import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterOutlet } from '@angular/router';
import { TvshowsService } from './services/tvshows.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, FormsModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  [x: string]: any;
  search = '';
  title = 'tvshowclient';
  show: any;
  showArray: any[] = [];

  constructor(private tvshowsService: TvshowsService) {}

  ngOnInit() {
    this.getAll();
  }

  getAll() {
    this.tvshowsService.getShows().subscribe((shows) => {
      this.show = shows;
      console.log(this.show[0]);
    });
  }

  buscar() {
    if (this.search === '') {
      this.getAll();
    }
    this.tvshowsService.searchShow(this.search).subscribe((show) => {
      if (Array.isArray(show)) {
        this.show = show;
      } else {
        this.showArray.push(show);
        this.show = this.showArray;
        this.showArray = [];
      }
    });
  }

  unfavorite(index: any, name: any, fav: any) {
    const tvShowUpdate =
      {
        id: index,
        name: name,
        favorite: !fav,
      };
    console.log(tvShowUpdate);
    this.tvshowsService.updateShow(tvShowUpdate).subscribe((show) => {
      this.getAll();
    });
  }

  delete(id: any){
    this.tvshowsService.deleteShow(id).subscribe((show)=>{
      this.getAll();
    })
  }
}
