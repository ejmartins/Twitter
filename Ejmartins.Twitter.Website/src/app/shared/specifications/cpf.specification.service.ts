import { Injectable } from "@angular/core";
import { FormControl } from "@angular/forms";

import { SpecificationBase } from "./specification.base";
import { RequiredSpecificationService } from "./required.specification.service";

@Injectable()

export class CPFSpecificationService extends SpecificationBase {

  constructor(private required: RequiredSpecificationService) {
    super();
  }

  public validate(control: FormControl) {

    if (this.isPresent(this.required.validate(control))) {
      return null;
    }

    return this.isValidCPF(control.value) ?
      null :
      {
        "cnpj": true,
        "errorMessage": "CPF inválido."
      }
  }

  public isValidCPF(obj) {

    let cpf_ret = obj.replace(/[^\d]+/g, "");

    if (cpf_ret === "") return false;

    if (cpf_ret.length !== 11) {
      return false;
    }

    // CPFs invalidos
    if (cpf_ret == "00000000000" ||
      cpf_ret == "11111111111" ||
      cpf_ret == "22222222222" ||
      cpf_ret == "33333333333" ||
      cpf_ret == "44444444444" ||
      cpf_ret == "55555555555" ||
      cpf_ret == "66666666666" ||
      cpf_ret == "77777777777" ||
      cpf_ret == "88888888888" ||
      cpf_ret == "99999999999")
      return false;

    let Soma = 0;
    let Resto;

    if (cpf_ret == "00000000000") return false;

    for (let i = 1; i <= 9; i++) {
      Soma = Soma + parseInt(cpf_ret.substring(i - 1, i)) * (11 - i);
    }

    Resto = (Soma * 10) % 11;

    if ((Resto == 10) || (Resto == 11)) {
      Resto = 0;
    }
    if (Resto != parseInt(cpf_ret.substring(9, 10))) {
      return false;
    }

    Soma = 0;

    for (let i = 1; i <= 10; i++) {
      Soma = Soma + parseInt(cpf_ret.substring(i - 1, i)) * (12 - i);
    }

    Resto = (Soma * 10) % 11;

    if ((Resto == 10) || (Resto == 11)) {
      Resto = 0;
    }

    if (Resto != parseInt(cpf_ret.substring(10, 11))) {
      return false;
    }
    return true;
  }
}
