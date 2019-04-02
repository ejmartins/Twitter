import { Injectable } from "@angular/core";
import { FormControl } from "@angular/forms";

import { SpecificationBase } from "./specification.base";
import { RequiredSpecificationService } from "./required.specification.service";

@Injectable()

export class RGSpecificationService extends SpecificationBase {

  constructor(private required: RequiredSpecificationService) {
    super();
  }

  public validate(control: FormControl) {

    if (this.isPresent(this.required.validate(control))) {
      return null;
    }

    return this.isValidRG(control.value) ?
      null :
      {
        "cnpj": true,
        "errorMessage": "RG inválido."
      }
  }

  public isValidRG(obj) {

    let rg_ret = obj.replace(/[^[A-Z0-9]]+/g, "");

    if (rg_ret === "") return false;

    if (rg_ret.length !== 9) {
      return false;
    }
    return true;
  }
}
