import { inject } from "@angular/core";
import { DashboardService } from "models";
import { map } from "rxjs";

export function createViewModel() {
    var dashboardService = inject(DashboardService);

    return dashboardService.get().pipe(
        map(dashboards => ({ dashboards }))
    )
}