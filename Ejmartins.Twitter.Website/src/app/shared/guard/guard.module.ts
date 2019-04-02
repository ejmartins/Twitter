import { NgModule } from "@angular/core";

import { LoggedInService } from "./logged-in.guard.service";
import { NotLoggedInService } from "./not-logged-in.guard.service";

@NgModule({
  providers: [
    LoggedInService,
    NotLoggedInService
  ]
})

export class GuardModule { }
