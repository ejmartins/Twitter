import { BaseParser } from "./base.parser";

export class CnpjParser extends BaseParser {
  public static parse(cnpj: string, fromPipe: boolean): any {

    cnpj = cnpj.replace(/[^a-zA-Z0-9]/g, "");

    let pattern = "00.000.000/0000-00";
    let toView = super.parseBase(cnpj, pattern, fromPipe, true);
    let toModel = super.parseBase(cnpj, pattern, fromPipe, true).replace(/[^a-zA-Z0-9]/g, "");

    return {
      toView: toView,
      toModel: toModel
    };
  }
}
