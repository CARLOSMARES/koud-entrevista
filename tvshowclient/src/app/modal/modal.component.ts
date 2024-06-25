import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { TvshowsService } from '../services/tvshows.service';

@Component({
  selector: 'app-modal',
  standalone: true,
  imports: [MatDialogModule, FormsModule],
  templateUrl: './modal.component.html',
  styleUrl: './modal.component.css',
})
export class ModalComponent {
  constructor(
    public dialogRef: MatDialogRef<ModalComponent>,
    private TvshowsService: TvshowsService
  ) {}

  name: any;
  favorite: any;

  close() {
    this.dialogRef.close();
  }

  add() {
    // if(this.favorite === )
    const tvshow = {
      name: this.name,
      favorite: this.favorite,
    };
    this.TvshowsService.addShow(tvshow).subscribe((show) => {
      this.dialogRef.close();
    });
  }
}
