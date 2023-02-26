// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GridsterComponent } from 'angular-gridster2';
import { Dashboard } from 'models';

@Component({
  selector: 'g-dashboard',
  standalone: true,
  imports: [CommonModule, GridsterComponent],
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent { 

  @Input() public dashboard: Dashboard | undefined;

}

