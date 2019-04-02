import { Pipe, PipeTransform, Injectable } from '@angular/core';

import { TimeParser } from "../input-masks/parsers/time.parser";

@Pipe({
  name: 'time',
  pure: false
})

export class TimePipe implements PipeTransform {

  constructor() {

  }

  transform(phrase: any): any {

    return TimeParser.parse(phrase, true).toView;
  }

}
