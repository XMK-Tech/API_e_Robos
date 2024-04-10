export function removeDuplicates<T>(array: T[]): T[] {
  const uniqueSet = new Set<string>();
  const uniqueObjects: T[] = [];

  for (const item of array) {
    const signature = JSON.stringify(item);
    if (!uniqueSet.has(signature)) {
      uniqueSet.add(signature);
      uniqueObjects.push(item);
    }
  }

  return uniqueObjects;
}