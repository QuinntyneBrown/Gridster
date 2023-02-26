// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { PushModule } from '@ngrx/component';
import { map, of } from 'rxjs';

@Component({
  selector: 'g-create-dashboard',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, PushModule],
  templateUrl: './create-dashboard.component.html',
  styleUrls: ['./create-dashboard.component.scss']
})
export class CreateDashboardComponent {

  public vm$ = of(new FormGroup({
    name: new FormControl(null,[Validators.required])
  })).pipe(
    map(formGroup => {
      return {
        form: formGroup
      }
    })
  )
}

