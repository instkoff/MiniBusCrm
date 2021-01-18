import { axiosInstance } from 'boot/axios'
import { Notify } from 'quasar'
import { authHeader } from 'src/common/auth-header'
import { authenticateService } from 'src/services/authenticate'
import qs from 'qs'

export const ingotService = {
  getIngotImages,
  sendNote,
  getIngots
}

async function getIngotImages (ingotId) {
  const response = await axiosInstance.get('/IngotImage/get-base64-images/id', { headers: authHeader(), params: { ingotId: ingotId } })
    .catch(response => response)
  console.log(ingotId)
  return authenticateService.handleResponse(response)
}

async function sendNote (note) {
  const response = await axiosInstance.post('/IngotApi/add-note', note, { headers: authHeader() }).catch(response => response)
  if (response instanceof Error) {
    Notify.create({
      type: 'negative',
      message: response.message
    })
  }
}

async function getIngots (fetchParams) {
  const response = await axiosInstance.get('/IngotApi/get-filtered', {
    headers: authHeader(),
    params: {
      StartRow: fetchParams.startRow,
      FetchCount: fetchParams.fetchCount,
      SortBy: fetchParams.sortBy,
      Descending: fetchParams.descending,
      StartDate: !fetchParams.filter.startDate ? null : fetchParams.filter.startDate,
      EndDate: !fetchParams.filter.endDate ? null : fetchParams.filter.endDate,
      DefectIds: fetchParams.filter.defectIds,
      MeltNumber: fetchParams.filter.meltNumber
    },
    paramsSerializer: params => {
      return qs.stringify(params, { arrayFormat: 'repeat', skipNulls: true })
    }
  }).catch(response => response)
  return authenticateService.handleResponse(response)
}
