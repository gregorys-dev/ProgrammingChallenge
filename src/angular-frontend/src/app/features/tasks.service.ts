import { map, shareReplay } from "rxjs/operators";

import { ChallengeTask } from './models/models';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { keyBy } from "lodash/fp";

@Injectable({
  providedIn: 'root'
})
export class TasksService {
  constructor(
    private http: HttpClient
  ) { 
    
  }

  tasksById$ = this.http.get<ChallengeTask[]>('/api/tasks')
    .pipe(
      map(keyBy((t: ChallengeTask) => t.id)),
      shareReplay(1)
    )
}
