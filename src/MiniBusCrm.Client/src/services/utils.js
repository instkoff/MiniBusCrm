import { Notify } from 'quasar'

export const notifier = {
  showErrorNotify,
  showPositiveNotify,
  showWarningNotify
}

function showErrorNotify (message) {
  Notify.create({
    type: 'negative',
    message: message
  })
}
function showPositiveNotify (message) {
  Notify.create({
    type: 'positive',
    message: message
  })
}
function showWarningNotify (message) {
  Notify.create({
    type: 'warning',
    message: message
  })
}
export function formatDate (dateStr) {
  if (dateStr === null) return null
  const [date, hour] = dateStr.split(' ')
  const [day, month, year] = date.split('.')
  return year + '-' + month + '-' + day + ' ' + hour
}
