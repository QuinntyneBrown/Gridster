// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HeaderComponent, SidenavComponent } from 'components';
import { createViewModel } from './app.view-model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  standalone: true,
  imports: [
    HeaderComponent,
    SidenavComponent,
    CommonModule,
    RouterModule,
    HttpClientModule
  ]
})
export class AppComponent {
  public vm$ = createViewModel();
}
