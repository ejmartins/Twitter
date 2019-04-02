import { FormControl } from "@angular/forms";

export class SpecificationBase {
  
  public isPresent(obj) {
    return obj !== undefined && obj !== null;
  }
  public isBlank(obj) {
    return obj === undefined || obj === null;
  }
  public isBoolean(obj) {
    return typeof obj === "boolean";
  }
  public isNumber(obj) {
    return typeof obj === "number";
  }
  public isString(obj) {
    return typeof obj === "string";
  }
  public isFunction(obj) {
    return typeof obj === "function";
  }
  public isType(obj) {
    return this.isFunction(obj);
  }
  public isStringMap(obj) {
    return typeof obj === "object" && obj !== null;
  }
  public isArray(obj) {
    return Array.isArray(obj);
  }
  public isDate(obj) {
    return obj instanceof Date && !isNaN(obj.valueOf());
  }
}
