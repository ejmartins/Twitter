import { Injectable } from "@angular/core";
import { CanActivate, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";
import { SessionService } from "../session/session.service";

@Injectable()
export class NotLoggedInService implements CanActivate {

  constructor(private session: SessionService, private router: Router) {

  }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {

    let paths: { [id: string]: string; } = {};
    paths["administrador"] = "/administrador/locais/consultar";
    paths["recursos-humanos"] = "/recursos-humanos/profissionais/consultar";
    paths["profissional"] = "/profissional/profissionais/alterar";

    let claims = JSON.parse(localStorage.getItem("user_claims"));
    if (claims) {
      this.router.navigate([paths[claims[3].value]]);
    }

    return true;
  }
}
