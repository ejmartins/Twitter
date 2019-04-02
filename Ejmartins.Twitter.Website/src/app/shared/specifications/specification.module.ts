import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { CommonModule } from "@angular/common";

import { RequiredSpecificationService } from "./required.specification.service";
import { CNPJSpecificationService } from "./cnpj.specification.service";
import { EmailSpecificationService } from "./email.specification.service";
import { PasswordSpecificationService } from "./password.specification.service";
import { PasswordEqualsSpecificationService } from "./password-equals.specification.service";
import { RGSpecificationService } from "./rg.specification.service";
import { CPFSpecificationService } from "./cpf.specification.service";
import { TelefoneSpecificationService } from "./telefone.specification.service";
import { TimeSpecificationService } from "./time.specification.service";

@NgModule({
  declarations: [
  ],
  imports: [
    CommonModule
  ],
  exports: [
  ],
  providers: [
    RequiredSpecificationService,
    CNPJSpecificationService,
    EmailSpecificationService,
    PasswordSpecificationService,
    PasswordEqualsSpecificationService,
    RGSpecificationService,
    CPFSpecificationService,
    TelefoneSpecificationService,
    TimeSpecificationService
  ]
})

export class SpecificationModule { }
