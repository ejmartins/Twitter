import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";

import { SessionService } from "../session/session.service";

@Component({
  selector: "app-alert",
  templateUrl: "./alert.component.html"
})
export class AlertComponent implements OnInit {

  public alert: boolean;
  public alertMessage: string;
  public alertSeverity: string;

  ngOnInit() {
    let contextAlert = JSON.parse(sessionStorage.getItem("alert"));
    if (contextAlert) {
      this.alert = true;
      this.alertMessage = contextAlert.message;
      this.alertSeverity = contextAlert.severity;
    }

    sessionStorage.removeItem("alert");
  }

  public showAlert(message: string, severity: string) {
    this.alert = true;
    this.alertMessage = message;
    this.alertSeverity = severity;
  }

  public saveContext(message: string, severity: string) {
    let obj = {
      message: message,
      severity: severity
    };
    sessionStorage.setItem("alert", JSON.stringify(obj));

  }
}
