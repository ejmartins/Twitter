import { Directive, ElementRef, Input, Renderer, ViewContainerRef, ComponentFactoryResolver, ComponentRef, HostListener } from "@angular/core";
import { NgModel, FormGroup, NgControl } from "@angular/forms";
import { TelefoneParser } from "./parsers/telefone.parser";

@Directive({
  selector: "[telefone]",
  providers: [NgModel],
  host: {
    "(blur)": "onBlur($event)",
    "(input)": "OnInput()"
  }
})

export class TelefoneInputMaskDirective {

  constructor(public element: ElementRef, public control: NgControl) {

  }

  onBlur($event, emitEvent) {
    this.parse(this.element.nativeElement.value, true, false, emitEvent);
  }

  OnInput() {
    this.parse(this.element.nativeElement.value, false, true);
  }

  parse(newValue: string, triggerOnBlur?: boolean, fromInput?: boolean, emitirValueChanges?: boolean) {
    newValue = newValue ? newValue.toString() : "";
    emitirValueChanges = emitirValueChanges != null ? emitirValueChanges : true;
    let ret: any = {
      toView: newValue,
      toModel: newValue
    };

    ret = TelefoneParser.parse(newValue, false);

    this.control.control.setValue(ret.toModel, { onlySelf: false, emitEvent: emitirValueChanges });

    this.element.nativeElement.value = ret.toView;
  }
}
