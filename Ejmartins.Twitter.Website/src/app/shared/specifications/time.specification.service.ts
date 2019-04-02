import { Injectable } from "@angular/core";
import { FormControl } from "@angular/forms";

import { SpecificationBase } from "./specification.base";
import { RequiredSpecificationService } from "./required.specification.service";

@Injectable()

export class TimeSpecificationService extends SpecificationBase {

  constructor(private required: RequiredSpecificationService) {
    super();
  }

  public validate(control: FormControl) {

    if (this.isPresent(this.required.validate(control))) {
      return null;
    }

    return this.isValidTime(control.value) ?
      null :
      {
        "time": true,
        "errorMessage": "Horario inválido."
      }
  }

  public isValidTime(obj) {

    let hora_ret = obj.replace(/[^[A-Z0-9]]+/g, "");

    if (hora_ret === "") {
      return false
    };

    if (hora_ret.length !== 4) {
      return false;
    }

    var regex = new RegExp(/^([0-9]|0[0-9]|1[0-9]|2[0-3])[0-5][0-9]$/);
    if (!regex.test(hora_ret)) {
      return false;
    }
    return true;
  }
}
