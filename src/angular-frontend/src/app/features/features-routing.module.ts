import { RouterModule, Routes } from '@angular/router';

import { NgModule } from '@angular/core';
import { SubmitSolutionComponent } from './submit-solution/submit-solution.component';
import { TopThreePlayersComponent } from './top-three-players/top-three-players.component';

const routes: Routes = [
  {path: '', pathMatch: 'full', redirectTo: 'solve'},
  {path: 'solve', component: SubmitSolutionComponent},
  {path: 'top3', component: TopThreePlayersComponent},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FeaturesRoutingModule { }
