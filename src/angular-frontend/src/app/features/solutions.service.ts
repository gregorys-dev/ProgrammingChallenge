import { Observable } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { SubmitSolutionCommand } from './dtos/dtos';
import { Injectable } from '@angular/core';
import { Solution } from './models/models';

@Injectable({
  providedIn: 'root'
})
export class SolutionsService {
  constructor(private http: HttpClient) { }

  post(command: SubmitSolutionCommand): Observable<Solution> {
    return this.http.post<number>('/api/solutions', <SubmitSolutionCommand>command)
      .pipe(
        switchMap(res => this.get(res))
      )
  }

  get(id: number): Observable<Solution> {
    return this.http.get<Solution>('/api/solutions/' + id)
  }
}
