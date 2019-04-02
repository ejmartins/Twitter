import { DateTimeBaseParser } from "./date-time-base.parser";

export class DateParser extends DateTimeBaseParser {

  public static parse(date: string, fromPipe: boolean, triggerOnBlur?: boolean): any {

    let pattern = "dd/MM/yyyy";
    let dateObj = DateParser.extractDateTime(date, pattern);
    let toView = this.parseDateTime(dateObj, pattern, false);
    let toModel = this.parseDateTime(dateObj, pattern, true);

    if ((toView.length == pattern.length && !this.isValid(toModel)) ||
      (toView.length < pattern.length && triggerOnBlur)) {
      return {
        toView: "",
        toModel: ""
      }
    }

    console.log("data: ", toModel);

    return {
      toView: toView,
      toModel: toModel
    };
  }
}
