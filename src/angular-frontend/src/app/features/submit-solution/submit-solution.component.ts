import { FormBuilder, Validators } from '@angular/forms';
import { Observable, combineLatest, of } from 'rxjs';

import { ChallengeTask } from '../models/models';
import { Component } from '@angular/core';
import { SolutionsService } from '../solutions.service';
import { TasksService } from '../tasks.service';
import { map, startWith } from 'rxjs/operators';
import { keyBy } from 'lodash/fp';

@Component({
  selector: 'app-submit-solution',
  templateUrl: './submit-solution.component.html',
  styleUrls: ['./submit-solution.component.scss']
})
export class SubmitSolutionComponent {
  solutionForm = this.fb.group({
    playerName: [null, Validators.compose([
      Validators.required, 
      Validators.minLength(2)
    ])],
    challengeTaskId: [null, Validators.required],
    solutionCode: [null, Validators.compose([
      Validators.required, 
      Validators.minLength(5)
    ])],
    language: [null, Validators.required]
  });

  private challengeTaskId$: Observable<number>

  languages = [
    {title: 'Python 3', id: 'python3'},
    {title: 'C# (Mono)', id: 'csharp'}
  ]
  public tasks$: Observable<ChallengeTask[]>
  public taskStore$: Observable<Record<number, ChallengeTask>>
  public selectedTask$: Observable<ChallengeTask>

  constructor(
    private fb: FormBuilder,
    public tasksService: TasksService,
    private solutionsService: SolutionsService
  ) {
    this.challengeTaskId$ = this.solutionForm.get('challengeTaskId')?.valueChanges ?? of(null)
    
    const loadingTaskPlaceholder = <ChallengeTask>{name: 'Loading...'}

    this.tasks$ = tasksService.getAll().pipe(
      startWith([loadingTaskPlaceholder])
    )

    this.taskStore$ = this.tasks$.pipe(
      map(keyBy((t: ChallengeTask) => t.id))
    )

    this.selectedTask$ = combineLatest([
      this.taskStore$,
      this.challengeTaskId$
    ])
    .pipe(
      map(([store, selectedId]) => store[selectedId]),
      startWith(loadingTaskPlaceholder),
    )
  }

  onSubmit(): void {
    console.log(this.solutionForm.value)
    
    if(!this.solutionForm.valid) {
      console.error(this.solutionForm)
      alert('form is invalid')
      return
    }

    this.solutionsService.post(this.solutionForm.value);
  }
}
