import { BaseParser } from "./base.parser";

export class TelefoneParser extends BaseParser {
  public static parse(phone: string, fromPipe: boolean): any {

    let num = phone.replace(/[^a-zA-Z0-9]/g, "");

    let ret = "";
    let mask: string[] = [
      "0000-0000",
      "(00) 0000-0000",
      "+00 (00) 0000-0000",
      "00000-0000",
      "(00) 00000-0000",
      "+00 (00) 00000-0000"
    ]

    for (let i = 0; i < mask.length; i++) {
      let SoLetrasENumeros = mask[i].replace(/[^a-zA-Z0-9]/g, "");
      if ((i == 0 && num.length <= SoLetrasENumeros.length) ||
        (num.length == SoLetrasENumeros.length) ||
        (i == mask.length - 1 && num.length >= SoLetrasENumeros.length)) {
        ret = super.parseBase(num, mask[i], fromPipe, true);
        break;
      }
    }

    let toView: string = ret;
    let toModel: string = ret.replace(/[^a-zA-Z0-9]/g, "");

    return {
      toView: toView.toUpperCase(),
      toModel: toModel.toUpperCase()
    };
  }
}
