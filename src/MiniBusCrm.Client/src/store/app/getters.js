import { getField } from 'vuex-map-fields'

export function ingotList (state) {
  return state.ingotList
}
export function rowsNumber (state) {
  return state.totalRowsNumber
}
export function currentFetchParams (state) {
  return state.currentFetchParams
}
export function currentPage (state) {
  return state.currentPage
}
export function leftDrawerState (state) {
  return state.currentPage
}
export function ingotDetailsToolbarState (state) {
  return state.ingotDetailsToolbarOpen
}
export function serviceLogToolbarState (state) {
  return state.serviceLogToolbarState
}
export function nextBtnState (state) {
  return state.nextBtnDisabled
}
export function prevBtnState (state) {
  return state.prevBtnDisabled
}
export function defectTypes (state) {
  return getField(state)
}
