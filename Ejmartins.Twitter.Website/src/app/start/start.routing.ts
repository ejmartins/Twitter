import { RouterModule, Routes } from "@angular/router";

import { StartComponent } from "./start.component";

export const routes: Routes = [

  {
    path: "",
    component: StartComponent
  }
];

export const routing = RouterModule.forChild(routes);
