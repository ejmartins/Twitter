import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";

import { CNPJInputMaskDirective } from "./cnpj.input-mask.directive";
import { CPFInputMaskDirective } from "./cpf.input-mask.directive";
import { TelefoneInputMaskDirective } from "./telefone.input-mask.directive";
import { RGInputMaskDirective } from "./rg.input-mask.directive";
import { TimeInputMaskDirective } from "./time.input-mask.directive";
import { NumberInputMaskDirective } from "./number.input-mask.directive";
import { DateInputMaskDirective } from "./date.input-mask.directive";

@NgModule({
  declarations: [
    CNPJInputMaskDirective,
    CPFInputMaskDirective,
    TelefoneInputMaskDirective,
    RGInputMaskDirective,
    TimeInputMaskDirective,
    NumberInputMaskDirective,
    DateInputMaskDirective
  ],
  imports: [
    CommonModule
  ],
  exports: [
    CNPJInputMaskDirective,
    CPFInputMaskDirective,
    TelefoneInputMaskDirective,
    RGInputMaskDirective,
    TimeInputMaskDirective,
    NumberInputMaskDirective,
    DateInputMaskDirective
  ]
})

export class InputMaskModule { }
