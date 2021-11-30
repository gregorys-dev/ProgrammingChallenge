import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';

@NgModule({
    exports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
    ],
})
export class SharedModule {}
