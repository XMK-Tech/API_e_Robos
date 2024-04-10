import { format, startOfMonth, endOfMonth, parse } from 'date-fns';
import { FindExpenseContent } from './src/Services/ExpenseService';
import { FindRevenueContent } from './src/Services/RevenueService';
import { FindCollectionContent } from './src/Services/CollectionService';
import { FindFPMContent } from './src/Services/FPMServices';

interface ParsedArgs {
  [key: string]: string;
}

const argsArray = process.argv.slice(2);
export const args: ParsedArgs = {};

argsArray.forEach(arg => {
  const [key, value] = arg.split('=');
  args[key] = value;
}); 

const reference = args.reference

const data = parse(reference, 'dd/MM/yyyy', new Date());
args.startDate = format(startOfMonth(data), 'dd/MM/yyyy')
args.endDate = format(endOfMonth(data), 'dd/MM/yyyy');
args.yarnEndDate = format(new Date(data), 'yyyy')

function formatDate(dateString: string): string {
  return dateString.split('/').join('');
}
args.nameTxt = formatDate(args.reference);

function DefineActionToPerform(): () => Promise<string> {
  switch (args.action) {
    case 'fpm':
      return FindFPMContent;
    case 'expense':
      return FindExpenseContent;
    case 'collection':
      return FindCollectionContent;
    case 'revenue':
      return FindRevenueContent;
    default:
      return undefined
  }
}

async function FindAllContent(): Promise<string> {
  const action = DefineActionToPerform()
  if (action === undefined)
    return undefined

  return await action()
}

FindAllContent()
  .then((data: string) => {

    console.log(data)
    return 0

  }).catch((error: string) => {

    console.error(error)
    return -1

  });
