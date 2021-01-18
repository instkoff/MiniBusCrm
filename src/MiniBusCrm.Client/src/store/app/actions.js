import { ingotService } from 'src/services/ingot'
import { settingsService } from 'src/services/settings'

export function setCurrentPage (context, page) {
  context.commit('setCurrentPage', page)
}
export function updateIngotNotes (context, notes) {
  context.commit('updateIngotNote', notes)
}
export function changeDrawerState (context) {
  context.commit('changeDrawerState')
}
export function setDrawerState (context, opened) {
  context.commit('setDrawerState', opened)
}
export function changeIngotToolbarState (context, opened) {
  context.commit('changeIngotToolbarState', opened)
}
export function nextBtnDisabled (context, flag) {
  context.commit('setNextBtnState', flag)
}
export function prevBtnDisabled (context, flag) {
  context.commit('setPrevBtnState', flag)
}
export async function getIngots ({ dispatch, commit }, fetchParams) {
  const response = await ingotService.getIngots(fetchParams)
  if (response.error) {
    dispatch('alert/error', response.error, { root: true })
  }
  if (response.data) {
    commit('updateCurrentFetchParams', fetchParams)
    commit('setTotalRowsNumber', response.data.totalRecords)
    commit('setIngotList', response.data.data)
  }
}

export async function getDefectTypes ({ dispatch, commit }) {
  const response = await settingsService.getDefectTypes()
  if (response.error) {
    dispatch('alert/error', response.error, { root: true })
  }
  if (response.data) {
    commit('setDefectTypes', response.data)
  }
}
