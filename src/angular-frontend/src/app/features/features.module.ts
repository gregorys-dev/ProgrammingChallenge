import { FeaturesRoutingModule } from './features-routing.module';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatRadioModule } from '@angular/material/radio';
import { MatSelectModule } from '@angular/material/select';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { NgModule } from '@angular/core';
import { SharedModule } from './../shared.module';
import { SubmitSolutionComponent } from './submit-solution/submit-solution.component';
import { TopThreePlayersComponent } from './top-three-players/top-three-players.component';

@NgModule({
  declarations: [
    SubmitSolutionComponent,
    TopThreePlayersComponent
  ],
  imports: [
    SharedModule,
    FeaturesRoutingModule,
    MatInputModule,
    MatButtonModule,
    MatSelectModule,
    MatRadioModule,
    MatCardModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatProgressSpinnerModule
  ]
})
export class FeaturesModule { }
