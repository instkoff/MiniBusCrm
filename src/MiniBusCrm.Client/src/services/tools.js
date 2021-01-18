import { axiosInstance } from 'boot/axios'
import { notifier } from 'src/services/utils'
import { authHeader } from 'src/common/auth-header'
import { authenticateService } from 'src/services/authenticate'

export async function uploadExcelFile (data) {
  const response = await axiosInstance.post('/Tools/upload-excel', data, { headers: authHeader() })
    .catch(response => response)
  const result = authenticateService.handleResponse(response)
  if (result.data) {
    return { updateResult: result.data }
  }
  if (result.error) {
    return { error: result.error }
  }
}

export async function getCsv (filter) {
  const response = await axiosInstance.get('/IngotImage/export-to-csv', {
    responseType: 'blob',
    headers: authHeader(),
    params: {
      StartDate: filter.startDate,
      EndDate: filter.endDate
    }
  }).catch(response => response)
  if (response instanceof Error) {
    notifier.showErrorNotify(response.message)
  } else {
    const contentDisposition = response.headers['content-disposition']
    const match = contentDisposition.match(/filename\s*=\s*"?(.+)"?;/i)
    const filename = match[1]
    const downloadUrl = window.URL.createObjectURL(new Blob([response.data]))
    const link = document.createElement('a')
    link.href = downloadUrl
    link.setAttribute('download', filename)
    document.body.appendChild(link)
    link.click()
    link.remove()
  }
}
