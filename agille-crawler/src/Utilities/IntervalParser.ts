import moment = require('moment');
import { MonthInterval } from '../Types/Inteval';

export function CalculateIntervals(startingReference: string, endingReference: string): MonthInterval[] {
  const intervals = [];

  const startDate = moment(startingReference, 'DD/MM/YYYY');
  const endDate = moment(endingReference, 'DD/MM/YYYY');

  while (endDate.diff(startDate, 'months') >= 2) {
    const intervalStart = startDate.format('DD/MM/YYYY');
    const intervalEnd = startDate.add(2, 'months').subtract(1, 'day').format('DD/MM/YYYY');

    intervals.push(
      {
        startingReference: intervalStart,
        endingReference: intervalEnd
      });
    startDate.add(1, 'day');
  }

  if (endDate.diff(startDate, 'days') >= 0) {
    const intervalStart = startDate.format('DD/MM/YYYY');
    const intervalEnd = endDate.format('DD/MM/YYYY');

    intervals.push(
      {
        startingReference: intervalStart,
        endingReference: intervalEnd
      });
  }

  return intervals;
} 