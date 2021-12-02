import { ChallengeTask, TopThreePlayersItem } from './models/models';
import { Observable, combineLatest } from 'rxjs';

import { Dictionary } from 'lodash';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PlayerScore } from './dtos/dtos';
import { TasksService } from './tasks.service';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class PlayersService {

  constructor(
    private http: HttpClient,
    private tasksService: TasksService
  ) { }

  getTop3(): Observable<TopThreePlayersItem[]> {
    return combineLatest([
      this.getTop3Players(),
      this.tasksService.tasksById$
    ])
      .pipe(
        map(([psList, tasks]) => psList.map(ps => mapToRow(ps, tasks)))
      )
  }

  private getTop3Players() {
    return this.http.get<PlayerScore[]>('/api/players/get-top-3')
  }
}

function mapToRow(ps: PlayerScore, tasks: Dictionary<ChallengeTask>): TopThreePlayersItem {
  return {
    playerName: ps.playerName,
    successSolutions: ps.successfulSubmissions,
    taskNames: ps.solvedTaskIds.map(taskId => tasks[taskId]?.name)
  };
}

