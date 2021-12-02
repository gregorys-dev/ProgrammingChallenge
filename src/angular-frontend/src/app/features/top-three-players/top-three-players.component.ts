import { ChangeDetectionStrategy, Component } from '@angular/core';
import { map, tap } from 'rxjs/operators';

import { BehaviorSubject } from 'rxjs';
import { MatTableDataSource } from '@angular/material/table';
import { PlayersService } from '../players.service';

@Component({
  selector: 'app-top-three-players',
  templateUrl: './top-three-players.component.html',
  styleUrls: ['./top-three-players.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class TopThreePlayersComponent {
  isLoaded$ = new BehaviorSubject(false)
  
  dataSource$ = this.playersService.getTop3()
    .pipe(
      tap(x => this.isLoaded$.next(true)),
      map(data => new MatTableDataSource(data))
    )

  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  columnNames: Record<string, string> = {
    playerName: 'NAME', 
    successSolutions: 'success Solutions', 
    taskNames: 'Tasks'
  }
  displayedColumns = Object.keys(this.columnNames)

  constructor(private playersService: PlayersService) {

  }
}
