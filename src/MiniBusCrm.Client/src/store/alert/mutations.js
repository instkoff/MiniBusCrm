export function success (state, message) {
  state.type = 'alert-success'
  state.message = message
  state.textColor = 'text-positive'
}
export function neutral (state, message) {
  state.type = 'alert-neutral'
  state.message = message
  state.textColor = 'text-warning'
}
export function error (state, message) {
  state.type = 'alert-danger'
  state.message = message
  state.textColor = 'text-negative'
}
export function clear (state) {
  state.type = null
  state.message = null
  state.textColor = null
}
