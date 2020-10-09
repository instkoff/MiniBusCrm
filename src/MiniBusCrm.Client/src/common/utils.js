export function formatDate (dateStr) {
  if (dateStr === null) return null
  const [date, hour] = dateStr.split(' ')
  const [day, month, year] = date.split('.')
  return year + '-' + month + '-' + day + ' ' + hour
}
