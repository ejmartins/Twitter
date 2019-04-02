import { BaseParser } from "./base.parser";

export class RgParser extends BaseParser {
  public static parse(rg: string, fromPipe: boolean): any {

    rg = rg.replace(/[^a-zA-Z0-9]/g, "");

    let pattern = "00.000.000-M";
    let toView = super.parseBase(rg, pattern, fromPipe, true);
    let toModel = super.parseBase(rg, pattern, fromPipe, true).replace(/[^a-zA-Z0-9]/g, "");

    return {
      toView: toView,
      toModel: toModel
    };
  }
}
