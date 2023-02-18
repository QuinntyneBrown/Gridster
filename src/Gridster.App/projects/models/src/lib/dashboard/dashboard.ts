// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { DashboardItem } from "../dashboard-item";

export type Dashboard = {
  dashboardId?: string;
  name?: string;
  dashboardItems: DashboardItem[]
};


