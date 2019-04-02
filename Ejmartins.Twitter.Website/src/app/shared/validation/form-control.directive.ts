import { Directive, ElementRef, HostListener, Renderer } from "@angular/core";
import { NgControl, AbstractControl, FormArray } from "@angular/forms";
import { Router, ActivatedRoute } from "@angular/router";

import { EventService } from "../event/event.service";

@Directive({
  selector: "[formControlName]",
})

export class FormControlDirective {

  public labelTitle: string;
  public labelElement: any;
  public type: string;
  static lastEvent: number;

  constructor(
    public control: NgControl,
    public element: ElementRef,
    public renderer: Renderer,
    public event: EventService,
    public router: Router) {

    this.event.on("validation-clear", () => {
      this.cleanControl();
    });

    this.event.on("form-submitted", (event: Event) => {
      if (this.element.nativeElement.closest("form") != event.srcElement) {
        return "";
      }

      if (FormControlDirective.lastEvent != event.timeStamp) {
        FormControlDirective.lastEvent = event.timeStamp;
        control.control.root.updateValueAndValidity();
      }

      this.labelElement = this.getLabel();

      this.labelTitle = this.labelElement ? this.labelElement.innerText : "";

      let node = this.element.nativeElement.closest(".form-group");

      if (this.control && this.control.control && this.control.control.invalid) {
        node.classList.add("has-error");
        this.type = "field";
        this.createMessage(node, this.control);
      }
    })
  }

  getLabel() {
    if (this.element.nativeElement.closest(".form-group")) {
      return this.element.nativeElement.closest(".form-group").querySelector("label");
    } else {
      return null;
    }
  }

  @HostListener("focus", ["$event"])
  public cleanControl() {
    let node = this.element.nativeElement.closest(".form-group");
    node.classList.remove("has-error");
    this.removeMessage(node);

  }

  getParentFormArray(control: AbstractControl): FormArray {
    if (control.parent instanceof FormArray) {
      return control.parent;
    } else if (control.parent instanceof AbstractControl) {
      return this.getParentFormArray(control.parent);
    }
    return null;
  }

  createMessage(node: any, control) {
    this.removeMessage(node);
    let url = this.router.url;
    if (this.router.url.match(/.{8}-.{4}-.{4}-.{4}-.{8}/) || this.router.url.match(/\d+$/)) {
      url = this.router.url.substr(0, this.router.url.lastIndexOf("/"));
    }
    if (!control.errors) {
      return;
    }

    let message: string = (<any>control.errors).errorMessage;
    let parseVals: any[] = (<any>control.errors).parseVals;

    if (parseVals) {
      parseVals.forEach((_, index) => {
        let v = _ === "fieldName" ? this.labelTitle : _.toString();
        message = message.replace("{" + index + "}", v);
      });
    }

    if (message) {
      message = message.replace(" *", "");

      switch (this.type) {
        case "field":
          this.createMessageElement(node, message);
          break;
        case "inline block":
          this.createGroupMessageElement(node, message);
          break;
        case "table":
          this.createTableMessageElement(node, message);
          break;
      }
    }
  }

  createMessageElement(node: any, message: string) {
    this.renderer.createElement(node, "small");
    node.lastElementChild.classList.add("help-block");
    node.lastElementChild.classList.add("error-container");
    node.lastElementChild.innerText = message;
  }

  createGroupMessageElement(node: any, message: string) {
    this.renderer.createElement(node, "div");
    node.lastElementChild.classList.add("row");
    node.lastElementChild.classList.add("error-container");
    this.renderer.createElement(node.lastElementChild, "div");
    node.lastElementChild.lastElementChild.classList.add("np-6");
    this.renderer.createElement(node.lastElementChild.lastElementChild, "small");
    node.lastElementChild.lastElementChild.lastElementChild.classList.add("help-block");
    node.lastElementChild.lastElementChild.lastElementChild.innerText = message;
  }

  createTableMessageElement(node: any, message: string) {
    let tbody = node.querySelector("tbody");
    this.renderer.createElement(tbody, "tr");
    tbody.lastElementChild.classList.add("error-container");
    tbody.lastElementChild.setAttribute("colspan", node.querySelector("thead").firstElementChild.childElementCount);
    this.renderer.createElement(tbody.lastElementChild, "small");
    tbody.lastElementChild.lastElementChild.classList.add("help-block");
    tbody.lastElementChild.lastElementChild.innerText = message;
  }

  removeMessage(node: any) {
    let smalls: any;
    smalls = node.querySelectorAll(".error-container");

    smalls.forEach(_ => {
      if (this.type === "table") {
        let bodies = node.querySelectorAll("tbody");
        bodies.forEach(__ => {
          if (__.contains(_)) {
            __.removeChild(_);
          }
        })

      } else {
        if (node.contains(_)) {
          node.removeChild(_);
        }
      }
    })
  }

  ngOnInit() {
    this.control.statusChanges.subscribe((value) => {
      if (this.control.pristine) {
        this.cleanControl();
      }
    })
  }

}

@Directive({
  selector: "[formGroup]"
})

export class FormGroupDirective {

  constructor(public event: EventService) {

  }

  @HostListener("submit", ["$event"])
  onSubmit(event: Event) {
    event.preventDefault();
    this.event.broadcast("validation-clear", event);
    this.event.broadcast("form-submitted", event);
  }
}
