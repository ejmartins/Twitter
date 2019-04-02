import { BaseParser } from "./base.parser";

export class CpfParser extends BaseParser {
  public static parse(cpf: string, fromPipe: boolean): any {

    cpf = cpf.replace(/[^a-zA-Z0-9]/g, "");

    let pattern = "000.000.000-00";
    let toView = super.parseBase(cpf, pattern, fromPipe, true);
    let toModel = super.parseBase(cpf, pattern, fromPipe, true).replace(/[^a-zA-Z0-9]/g, "");

    return {
      toView: toView,
      toModel: toModel
    };
  }
}
