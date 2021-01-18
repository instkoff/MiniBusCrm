export function success ({ commit }, message) {
  commit('success', message)
}
export function neutral ({ commit }, message) {
  commit('neutral', message)
}
export function error ({ commit }, message) {
  commit('error', message)
}
export function clear ({ commit }) {
  commit('clear')
}
