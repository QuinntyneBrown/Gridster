import { inject } from "@angular/core";
import { DashboardStore } from "models";
import { map } from "rxjs";

export function createViewModel() {
    var dashboardStore = inject(DashboardStore);

    return dashboardStore.select(x => x.dashboards).pipe(
        map(dashboards => ({ dashboards }))
    )
}