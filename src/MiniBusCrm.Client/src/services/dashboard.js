import { axiosInstance } from 'boot/axios'
import { Notify } from 'quasar'

export async function getChartRecords () {
  const response = await axiosInstance.get('/Dashboard/get-defects-by-hours')
    .catch(response => response)
  if (response instanceof Error) {
    Notify.create({
      type: 'negative',
      message: response.message
    })
  } else {
    return response.data
  }
}
