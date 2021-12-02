import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { TopThreePlayersDataSource, TopThreePlayersItem } from './top-three-players-datasource';

import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTable } from '@angular/material/table';
import { PlayersService } from '../players.service';

@Component({
  selector: 'app-top-three-players',
  templateUrl: './top-three-players.component.html',
  styleUrls: ['./top-three-players.component.scss']
})
export class TopThreePlayersComponent implements AfterViewInit {
  @ViewChild(MatTable) table!: MatTable<TopThreePlayersItem>;
  dataSource: TopThreePlayersDataSource;

  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  columnNames: Record<string, string> = {
    playerName: 'NAME', 
    successSolutions: 'success Solutions', 
    taskNames: 'Tasks'
  }
  displayedColumns = Object.keys(this.columnNames)

  constructor(playersService: PlayersService) {
    const data = playersService.getTop3()
    
    this.dataSource = new TopThreePlayersDataSource(data);
  }

  ngAfterViewInit(): void {
    this.table.dataSource = this.dataSource;
  }
}
