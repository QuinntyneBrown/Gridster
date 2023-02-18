// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BASE_URL } from '../constants';
import { map, Observable } from 'rxjs';
import { DashboardItem } from './dashboard-item';

@Injectable({
  providedIn: 'root'
})
export class DashboardItemService {

  constructor(
    @Inject(BASE_URL) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  public get(): Observable<Array<DashboardItem>> {
    return this._client.get<{ dashboardItems: Array<DashboardItem> }>(`${this._baseUrl}api/dashboard-item`)
      .pipe(
        map(x => x.dashboardItems)
      );
  }

  public getById(options: { dashboardItemId: string }): Observable<DashboardItem> {
    return this._client.get<{ dashboardItem: DashboardItem }>(`${this._baseUrl}api/dashboard-item/${options.dashboardItemId}`)
      .pipe(
        map(x => x.dashboardItem)
      );
  }

  public delete(options: { dashboardItem: DashboardItem }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/dashboard-item/${options.dashboardItem.dashboardItemId}`);
  }

  public create(options: { dashboardItem: DashboardItem }): Observable<{ dashboardItemId: string  }> {    
    return this._client.post<{ dashboardItemId: string }>(`${this._baseUrl}api/dashboard-item`, { dashboardItem: options.dashboardItem });
  }

  public update(options: { dashboardItem: DashboardItem }): Observable<{ dashboardItemId: string }> {    
    return this._client.post<{ dashboardItemId: string }>(`${this._baseUrl}api/dashboard-item`, { dashboardItem: options.dashboardItem });
  }
}
