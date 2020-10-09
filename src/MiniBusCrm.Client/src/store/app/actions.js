export function changeDrawerState (context) {
  context.commit('changeDrawerState')
}
export function setDrawerState (context, opened) {
  context.commit('setDrawerState', opened)
}
