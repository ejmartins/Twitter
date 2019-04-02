import { NgModule } from "@angular/core";

import { StartComponent } from "./start.component";
import { routing } from "./start.routing";
import { SharedModule } from "../shared/shared.module";

@NgModule({
  declarations: [
    StartComponent
  ],
  imports: [
    routing,
    SharedModule
  ]
})

export class StartModule {}
