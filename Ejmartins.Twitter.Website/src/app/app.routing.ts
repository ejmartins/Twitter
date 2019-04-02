import { ModuleWithProviders } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { LoggedInService } from "./shared/guard/logged-in.guard.service";
import { NotLoggedInService } from "./shared/guard/not-logged-in.guard.service";

export const routes: Routes = [
    {
        path: "",
        //loadChildren: "app/locais/locais.module#LocaisModule",
        loadChildren: "app/twitter/twitter.module#TwitterModule",
        canActivate: [NotLoggedInService]
    },
    {
        path: "twitter",
        loadChildren: "app/twitter/twitter.module#TwitterModule",
        canActivate: [NotLoggedInService]
    }

    // }, {
    //   path: "administrador/login",
    //   loadChildren: "app/login/login.module#LoginModule",
    //   canActivate: [NotLoggedInService]
    // }, {
    //   path: "recursos-humanos/login",
    //   loadChildren: "app/login/login.module#LoginModule",
    //   canActivate: [NotLoggedInService]
    // }, {
    //   path: "profissional/login",
    //   loadChildren: "app/login/login.module#LoginModule",
    //   canActivate: [NotLoggedInService]
    // }, {
    //   path: "administrador/cadastro",
    //   loadChildren: "app/cadastro/cadastro.module#CadastroModule",
    //   canActivate: [NotLoggedInService]
    // }, {
    //   path: "recursos-humanos/cadastro",
    //   loadChildren: "app/cadastro/cadastro.module#CadastroModule",
    //   canActivate: [NotLoggedInService]
    // }, {
    //   path: "profissional/cadastro",
    //   loadChildren: "app/cadastro/cadastro.module#CadastroModule",
    //   canActivate: [NotLoggedInService]
    // }, {
    //   path: "administrador/recuperar-senha",
    //   loadChildren: "app/recuperar-senha/recuperar-senha.module#RecuperarSenhaModule",
    //   canActivate: [NotLoggedInService]
    // }, {
    //   path: "recursos-humanos/recuperar-senha",
    //   loadChildren: "app/recuperar-senha/recuperar-senha.module#RecuperarSenhaModule",
    //   canActivate: [NotLoggedInService]
    // }, {
    //   path: "profissional/recuperar-senha",
    //   loadChildren: "app/recuperar-senha/recuperar-senha.module#RecuperarSenhaModule",
    //   canActivate: [NotLoggedInService]
    // }, {
    //   path: "administrador/locais",
    //   loadChildren: "app/locais/locais.module#LocaisModule",
    //   canActivate: [LoggedInService]
    // }, {
    //   path: "profissional/locais",
    //   loadChildren: "app/locais/locais.module#LocaisModule"
    //   //,canActivate: [LoggedInService]
    // }, {
    //   path: "recursos-humanos/profissionais",
    //   loadChildren: "app/profissionais/profissionais.module#ProfissionaisModule",
    //   canActivate: [LoggedInService]
    // }, {
    //   path: "profissional/profissionais",
    //   loadChildren: "app/profissionais/profissionais.module#ProfissionaisModule",
    //   canActivate: [LoggedInService]
    // }, {
    //   path: "**", redirectTo: "", pathMatch: "full"
    // }
];

export const routing: ModuleWithProviders = RouterModule.forRoot(routes);
