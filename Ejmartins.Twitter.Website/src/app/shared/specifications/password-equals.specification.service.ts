import { Injectable } from "@angular/core";
import { FormControl, FormGroup } from "@angular/forms";

import { SpecificationBase } from "./specification.base";
import { RequiredSpecificationService } from "./required.specification.service";

@Injectable()

export class PasswordEqualsSpecificationService extends SpecificationBase {

  constructor(private required: RequiredSpecificationService) {
    super();
  }

  public validate(param) {
    return (control: FormControl) => {
      if (this.isPresent(this.required.validate(control)))
        return null;

      if (typeof param === "string") {
        let otherControl = (<FormGroup>control.parent).controls[param] as FormControl;
        return control.value == otherControl.value ?
          null :
          {
            "passwordequal": true,
            "errorMessage": "As senhas não são iguais"
          };

      } else {
        return null;
      }
    }
  }

}
