import { CollectionViewer, DataSource } from '@angular/cdk/collections';

import { Observable } from 'rxjs';

export interface TopThreePlayersItem {
  playerName: string
  successSolutions: number,
  taskNames: string[]
}

/**
 * Data source for the TopThreePlayers view. This class should
 * encapsulate all logic for fetching and manipulating the displayed data
 * (including sorting, pagination, and filtering).
 */
export class TopThreePlayersDataSource extends DataSource<TopThreePlayersItem> {
  constructor(private data$: Observable<TopThreePlayersItem[]>) {
    super();
  }

  connect(): Observable<TopThreePlayersItem[]> {
      return this.data$;
  }

  disconnect(collectionViewer: CollectionViewer): void {  }
}
