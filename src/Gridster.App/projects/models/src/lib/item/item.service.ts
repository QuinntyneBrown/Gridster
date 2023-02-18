// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BASE_URL } from '../constants';
import { map, Observable } from 'rxjs';
import { Item } from './item';

@Injectable({
  providedIn: 'root'
})
export class ItemService {

  constructor(
    @Inject(BASE_URL) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  public get(): Observable<Array<Item>> {
    return this._client.get<{ items: Array<Item> }>(`${this._baseUrl}api/item`)
      .pipe(
        map(x => x.items)
      );
  }

  public getById(options: { itemId: string }): Observable<Item> {
    return this._client.get<{ item: Item }>(`${this._baseUrl}api/item/${options.itemId}`)
      .pipe(
        map(x => x.item)
      );
  }

  public delete(options: { item: Item }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/item/${options.item.itemId}`);
  }

  public create(options: { item: Item }): Observable<{ itemId: string  }> {    
    return this._client.post<{ itemId: string }>(`${this._baseUrl}api/item`, { item: options.item });
  }

  public update(options: { item: Item }): Observable<{ itemId: string }> {    
    return this._client.post<{ itemId: string }>(`${this._baseUrl}api/item`, { item: options.item });
  }
}
