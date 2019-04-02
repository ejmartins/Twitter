import { Injectable } from "@angular/core";
import { FormControl } from "@angular/forms";

import { SpecificationBase } from "./specification.base";
import { RequiredSpecificationService } from "./required.specification.service";

@Injectable()

export class PasswordSpecificationService extends SpecificationBase {

  constructor(private required: RequiredSpecificationService) {
    super();
  }

  public validate(control: FormControl) {

    if (this.isPresent(this.required.validate(control)))
      return null;
    var regex = new RegExp(/^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*])(?=.{8,})/);
    return regex.test(control.value) ?
      null :
      {
        "email": true,
        "errorMessage": "A senha deve conter pelo menos 8 caracteres, contendo ao menos uma letra maiúscula, um número e um caractere especial."
      };
  }

}
