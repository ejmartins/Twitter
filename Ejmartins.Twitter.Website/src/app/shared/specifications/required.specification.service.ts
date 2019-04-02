import { Injectable } from "@angular/core";
import { FormControl } from "@angular/forms";
import { SpecificationBase } from "./specification.base";


@Injectable()

export class RequiredSpecificationService extends SpecificationBase {

  public validate(control: any) {
    return this.isBlank(control.value) || (this.isString(control.value) && control.value == "") || control.value === false ?
      {
        "required": true,
        "errorMessage": "Campo obrigatório."
      } :
      null;
  }
}
