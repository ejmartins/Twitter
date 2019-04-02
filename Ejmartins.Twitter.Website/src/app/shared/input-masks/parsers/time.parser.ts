import { BaseParser } from "./base.parser";

export class TimeParser extends BaseParser {
  public static parse(hora: string, fromPipe: boolean): any {

    hora = hora.replace(/[^a-zA-Z0-9]/g, "");

    let pattern = "00:00";
    let toView = super.parseBase(hora, pattern, fromPipe, true);
    let toModel = super.parseBase(hora, pattern, fromPipe, true).replace(/[^a-zA-Z0-9]/g, "");

    return {
      toView: toView,
      toModel: toModel
    };
  }
}
