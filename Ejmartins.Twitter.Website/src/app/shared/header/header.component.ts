import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";

import { SessionService } from "../session/session.service";

@Component({
  selector: "app-header",
  templateUrl: "./header.component.html"
})
export class HeaderComponent implements OnInit {
  public roleRoute: string;
  public navegacao: string;

  constructor(private router: Router, public service: SessionService) {
    this.navegacao = "";
  }

  ngOnInit() {
    this.roleRoute = this.router.url.split("/")[1];
    switch (this.router.url.split("/")[2]) {
      case "locais":
      case "reservas":
        this.navegacao = this.router.url.split("/")[2];
        break;
      case "profissionais":
        this.navegacao = this.router.url.split("/")[2];
        if (this.roleRoute == "profissional" && this.router.url.split("/")[3] == "alterar") {
          this.navegacao += "/alterar";
        }
        break;
    }
  }

  public navegar(destino: string) {
    if (destino == "Logout") {
      this.service.logout();
      this.router.navigate(["/"]);
    } else {
      this.navegacao = destino;
    }
  }
}
