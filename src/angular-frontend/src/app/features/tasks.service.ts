import { Observable, Subject } from 'rxjs';

import { ChallengeTask } from './models/models';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TasksService {
  constructor(
    private http: HttpClient
  ) { 
    
  }

  getAll(){
    return this.http.get<ChallengeTask[]>('/api/tasks')
  }
}
