import { Injectable } from "@angular/core";
import { FormControl } from "@angular/forms";

import { SpecificationBase } from "./specification.base";
import { RequiredSpecificationService } from "./required.specification.service";

@Injectable()

export class TelefoneSpecificationService extends SpecificationBase {

  constructor(private required: RequiredSpecificationService) {
    super();
  }

  public validate(control: FormControl) {

    if (this.isPresent(this.required.validate(control))) {
      return null;
    }

    return this.isValidTelefone(control.value) ?
      null :
      {
        "cnpj": true,
        "errorMessage": "Telefone inválido."
      }
  }

  public isValidTelefone(obj) {

    let telefone_ret = obj.replace(/[^\d]+/g, "");

    if (telefone_ret === "") return false;

    if (telefone_ret.length < 8) {
      return false;
    }

    return true;
  }
}
