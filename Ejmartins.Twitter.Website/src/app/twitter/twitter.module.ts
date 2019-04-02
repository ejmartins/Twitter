import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { ReactiveFormsModule } from "@angular/forms";

import { ModalModule } from "ngx-bootstrap";

import { routing } from "./twitter.routing";
import { SharedModule } from "../shared/shared.module";

import { PopoverModule } from "ngx-popover";

import { TwitterPostagemporHashTagComponent } from "./twitter-postagemporhashtag/twitter-postagemporhashtag.component";
import { TwitterPostagemPorDiaComponent } from "./twitter-postagempordia/twitter-postagempordia.component";
import { TwitterTopUsuarioComponent } from "./twitter-topusuario/twitter-topusuario.component";

@NgModule({
    declarations: [
        TwitterTopUsuarioComponent,
        TwitterPostagemporHashTagComponent,
        TwitterPostagemPorDiaComponent
    ],
    imports: [
        routing,
        CommonModule,
        SharedModule,
        ReactiveFormsModule,
        ModalModule.forRoot(),
        PopoverModule
    ]
})

export class TwitterModule { }
