import { Routes } from "@angular/router";
import { DashboardComponent } from "./Pages/dashboard.component";

import { InvoiceComponent } from "./Pages/invoice.component";


export const ClientRoutes: Routes = [
  { path: 'Dashboard', component: DashboardComponent },
  { path: 'Invoice', component: InvoiceComponent }
]
