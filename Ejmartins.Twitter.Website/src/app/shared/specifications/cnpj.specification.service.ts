import { Injectable } from "@angular/core";
import { FormControl } from "@angular/forms";

import { SpecificationBase } from "./specification.base";
import { RequiredSpecificationService } from "./required.specification.service";

@Injectable()

export class CNPJSpecificationService extends SpecificationBase {

  constructor(private required: RequiredSpecificationService) {
    super();
  }

  public validate(control: FormControl) {

    if (this.isPresent(this.required.validate(control))) {
      return null;
    }

    return this.isValidCNPJ(control.value) ?
      null :
      {
        "cnpj": true,
        "errorMessage": "CNPJ inválido."
      }
  }

  public isValidCNPJ(obj) {

    let cnpj_ret = obj.replace(/[^\d]+/g, "");

    if (cnpj_ret == "") return false;

    if (cnpj_ret.length != 14) return false;

    // CNPJs invalidos
    if (cnpj_ret == "00000000000000" ||
      cnpj_ret == "11111111111111" ||
      cnpj_ret == "22222222222222" ||
      cnpj_ret == "33333333333333" ||
      cnpj_ret == "44444444444444" ||
      cnpj_ret == "55555555555555" ||
      cnpj_ret == "66666666666666" ||
      cnpj_ret == "77777777777777" ||
      cnpj_ret == "88888888888888" ||
      cnpj_ret == "99999999999999")
      return false;

    // Valida DVs
    let tamanho = cnpj_ret.length - 2;
    let numeros = cnpj_ret.substring(0, tamanho);
    let digitos = cnpj_ret.substring(tamanho);
    let soma = 0;
    let pos = tamanho - 7;
    for (let i = tamanho; i >= 1; i--) {
      soma += numeros.charAt(tamanho - i) * pos--;
      if (pos < 2)
        pos = 9;
    }
    let resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
    if (resultado != digitos.charAt(0))
      return false;

    tamanho = tamanho + 1;
    numeros = cnpj_ret.substring(0, tamanho);
    soma = 0;
    pos = tamanho - 7;
    for (let i = tamanho; i >= 1; i--) {
      soma += numeros.charAt(tamanho - i) * pos--;
      if (pos < 2)
        pos = 9;
    }
    resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
    if (resultado != digitos.charAt(1))
      return false;

    return true;
  }
}
