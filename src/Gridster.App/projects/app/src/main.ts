// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { importProvidersFrom } from '@angular/core';
import { bootstrapApplication } from '@angular/platform-browser';
import { AppComponent } from './app/app.component';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BASE_URL } from 'models';
import { GridsterHubConnectionGuard } from 'core';
import { HttpClientModule } from '@angular/common/http';


bootstrapApplication(AppComponent, {
  providers: [
    { provide: BASE_URL, useValue: "https://localhost:7013/" },    
    importProvidersFrom(
      HttpClientModule,
      RouterModule.forRoot([
        { path: '', redirectTo: 'home', pathMatch: 'full' },
        { path: 'home', loadComponent: () => import('./app/home/home.component').then(m => m.HomeComponent), canActivate: [GridsterHubConnectionGuard]},
        { path: 'home/:dashboardId', loadComponent: () => import('./app/home/home.component').then(m => m.HomeComponent), canActivate: [GridsterHubConnectionGuard]}
      ]), BrowserAnimationsModule,     
    )
  ]
}).catch((err) => console.error(err));
