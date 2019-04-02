import { RouterModule, Routes } from "@angular/router";

import { TwitterPostagemporHashTagComponent } from "./twitter-postagemporhashtag/twitter-postagemporhashtag.component";
import { TwitterPostagemPorDiaComponent } from "./twitter-postagempordia/twitter-postagempordia.component";
import { TwitterTopUsuarioComponent } from "./twitter-topusuario/twitter-topusuario.component";

export const routes: Routes = [

    {
        path: "topusuario",
        component: TwitterTopUsuarioComponent
    },
    {
        path: "postagemporhashtag",
        component: TwitterPostagemporHashTagComponent
    },
    {
        path: "postagempordia",
        component: TwitterPostagemPorDiaComponent
    },
    {
        path: "",
        redirectTo: "topusuario"
    },
    {
        path: "**",
        redirectTo: "topusuario"
    }
];

export const routing = RouterModule.forChild(routes);
