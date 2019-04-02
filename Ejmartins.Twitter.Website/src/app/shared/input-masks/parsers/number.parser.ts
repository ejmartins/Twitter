import { BaseParser } from "./base.parser";

export class NumeroParser extends BaseParser {
  public static parse(num: string, fromPipe: boolean, LeftToRight: boolean, casasDecimais: string, fromInput?: boolean): any {

    casasDecimais = casasDecimais ? casasDecimais : "0";

    if (!fromInput && +casasDecimais > 0 && num) {
      let posicaoSeparador = num.search(/[\.\,]/g);
      if (posicaoSeparador < 0) {
        num += Array(+casasDecimais + 1).join("0");
      } else {
        let decimaisNumero = num.substr(posicaoSeparador + 1).length;
        if (decimaisNumero < +casasDecimais) {
          num += Array(+casasDecimais - decimaisNumero + 1).join("0");
        }
      }
    }

    num = num ? num.replace(/[^a-zA-Z0-9]/g, "") : "";

    if (num.length > 1) {
      num = num.replace(/^0+/, '');
    }

    let ret = "";

    let separadorDecimal = ",";
    let separadorMilhar = "";

    let mascaraCasasDecimais: string = "";

    if (casasDecimais && (+casasDecimais) > 0) {
      mascaraCasasDecimais = separadorDecimal + Array(+casasDecimais + 1).join("0");
    }

    let mascaraMilhar: string = "";

    let grupos = num.substr(0, num.length - (+casasDecimais)).split(/(?=(?:...)*$)/);

    if (grupos.length > 0) {
      for (let i = 0; i < grupos.length; i++) {
        mascaraMilhar += Array(grupos[i].length + 1).join("0");
        if (i < grupos.length - 1) {
          mascaraMilhar += separadorMilhar;
        }
      }
    } else {
      mascaraMilhar = "0";
    }

    num = !num ? "0" : num;

    if (num.length < (+casasDecimais) + 1) {
      num = (Array((+casasDecimais) + 1).join("0") + num).substring(num.length - 1);
    }

    ret = super.parseBase(num, mascaraMilhar + mascaraCasasDecimais, fromPipe, true);

    let separadorDecimalPattern = new RegExp("\\" + separadorDecimal, "g");
    //let separadorMilharPattern = new RegExp("\\" + separadorMilhar, "g");

    let toView = ret;
    let toModel = ret.replace(separadorDecimalPattern, ".");

    return {
      toView: toView,
      toModel: toModel
    }
  }
}
