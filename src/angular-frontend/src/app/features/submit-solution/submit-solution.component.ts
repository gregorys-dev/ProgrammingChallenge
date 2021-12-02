import { FormBuilder, Validators } from '@angular/forms';
import { Observable, combineLatest, of, Subject } from 'rxjs';

import { ChallengeTask } from '../models/models';
import { ChangeDetectionStrategy, Component } from '@angular/core';
import { SolutionsService } from '../solutions.service';
import { TasksService } from '../tasks.service';
import { map, startWith, switchMap } from 'rxjs/operators';
import { keyBy, values } from 'lodash/fp';
import { SubmitSolutionCommand } from '../dtos/dtos';

@Component({
  selector: 'app-submit-solution',
  templateUrl: './submit-solution.component.html',
  styleUrls: ['./submit-solution.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
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
  public selectedTask$: Observable<ChallengeTask>
  tasks$: Observable<any[] | ChallengeTask[]>;

  constructor(
    private fb: FormBuilder,
    public tasksService: TasksService,
    private solutionsService: SolutionsService
  ) {
    this.challengeTaskId$ = this.solutionForm.get('challengeTaskId')?.valueChanges ?? of(null)
    
    const loadingTaskPlaceholder = <ChallengeTask>{name: 'Loading...'}

    this.tasks$ = tasksService.tasksById$.pipe(
      map(values),
      startWith([loadingTaskPlaceholder])
    )


    this.selectedTask$ = combineLatest([
      this.tasksService.tasksById$,
      this.challengeTaskId$
    ])
    .pipe(
      map(([store, selectedId]) => store[selectedId]),
      startWith(loadingTaskPlaceholder),
    )
  }

  submitClicked$ = new Subject<SubmitSolutionCommand>()

  submitResponse$ = this.submitClicked$.pipe(
    switchMap(value => 
      this.solutionsService.post(value)
        .pipe(
          map(res => ({
            color: res.isPassed ? 'green' : 'red',
            message: res.isPassed ? 'PASSED' : `FAILED. Output: ${res.executionInfo.output}`
          })),
          startWith({color: 'black', message: 'Executing...'})
        ),
    ),
  )

  onSubmit(): void {
    console.log(this.solutionForm.value)
    
    if(!this.solutionForm.valid) {
      console.error(this.solutionForm)
      alert('form is invalid')
      return
    }

    this.submitClicked$.next(this.solutionForm.value)
  }
}
