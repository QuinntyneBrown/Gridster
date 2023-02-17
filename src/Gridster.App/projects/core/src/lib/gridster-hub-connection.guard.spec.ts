// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { TestBed } from '@angular/core/testing';

import { GridsterHubConnectionGuard } from './gridster-hub-connection.guard';

describe('GridsterHubConnectionGuard', () => {
  let guard: GridsterHubConnectionGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(GridsterHubConnectionGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});

    // ARRANGE
    // ARRANGE
    // ARRANGE



