import { updateField } from 'vuex-map-fields'

export function setCurrentPage (state, page) {
  state.currentPage = page
}
export const updateIngotNote = (state, note) => {
  const ingot = state.ingotList.filter(x => x.id === note.ingotId)
  ingot[0].notes = note.text
}
export function changeDrawerState (state) {
  state.leftDrawerOpen = !state.leftDrawerOpen
}
export function setDrawerState (state, opened) {
  state.leftDrawerOpen = opened
}
export function setIngotList (state, ingots) {
  state.ingotList.splice(0, state.ingotList.length, ...ingots)
}
export function setTotalRowsNumber (state, number) {
  state.totalRowsNumber = number
}
export function changeIngotToolbarState (state, open) {
  state.ingotDetailsToolbarOpen = open
}
export function changeServiceLogToolbarState (state, open) {
  state.serviceLogToolbarState = open
}
export function updateCurrentFetchParams (state, params) {
  state.currentFetchParams = params
}
export function setNextBtnState (state, flag) {
  state.nextBtnDisabled = flag
}
export function setPrevBtnState (state, flag) {
  state.prevBtnDisabled = flag
}
export function setDefectTypes (state, defects) {
  state.defectTypes.splice(0, state.defectTypes.length, ...defects)
}
export function updateDefectTypes (state, editedDefectTypes) {
  updateField(state, editedDefectTypes)
}
