// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { importProvidersFrom } from '@angular/core';
import { bootstrapApplication } from '@angular/platform-browser';
import { AppComponent } from './app/app.component';
import { RouterModule } from '@angular/router';
import { GridsterHubConnectionGuard } from '../../core/src/lib/gridster-hub-connection.guard';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


bootstrapApplication(AppComponent, {
  providers: [
    { provide: "BASE_URL", useValue: "https://localhost:7013/" },
    importProvidersFrom(
      RouterModule.forRoot([
        { path: '', loadComponent: () => import('./app/home/home.component').then(m => m.HomeComponent), canActivate: [GridsterHubConnectionGuard]}
      ]), BrowserAnimationsModule,     
    )
  ]
}).catch((err) => console.error(err));
