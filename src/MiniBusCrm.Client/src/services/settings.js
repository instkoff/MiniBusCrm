import { axiosInstance } from 'boot/axios'
import { authHeader } from 'src/common/auth-header'
import { authenticateService } from 'src/services/authenticate'
import { store } from 'src/store'
import { DefectType } from 'src/common/models'

export const settingsService = {
  validateSettings,
  getServiceSettings,
  updateServiceSettings,
  updateEvaluationSettings,
  getDefectTypes
}

function validateSettings (source) {
  const excludedParams = ['WarpMat', 'InitialTimeStamp']
  let result = true
  const obj = source
  for (const key in obj) {
    const value = obj[key]
    if (value === '' && !excludedParams.includes(key)) {
      return false
    } else {
      if (typeof value === 'object' && value !== null) {
        result = validateSettings(value)
        if (!result) return result
      }
    }
  }
  return result
}

async function getServiceSettings () {
  const response = await axiosInstance.get('/ServiceSettings/get', { headers: authHeader() })
    .catch(response => response)
  return authenticateService.handleResponse(response)
}

async function updateServiceSettings (settings) {
  const settingsJson = JSON.stringify(settings)
  const response = await axiosInstance.post('/ServiceSettings/update-service-settings', { settingsJson }, { headers: authHeader() })
    .catch(response => response)
  await processResponse(response)
}

async function updateEvaluationSettings (defectTypes) {
  const defectsArray = defectTypes.map((defect) => {
    return new DefectType(defect.createDate, defect.defectId, defect.id, defect.innerName, defect.isActive, defect.minConfidence, defect.minDefectSize, defect.name)
  })
  const response = await axiosInstance.post('/ServiceSettings/update-evaluation-settings', { defectTypes: defectsArray }, { headers: authHeader() })
    .catch(response => response)
  await processResponse(response)
}

async function getDefectTypes () {
  const response = await axiosInstance.get('/ServiceSettings/get-defect-types', { headers: authHeader() })
    .catch(response => response)
  return authenticateService.handleResponse(response)
}

async function processResponse (response) {
  if (response.status === 204) {
    await store.dispatch('alert/neutral', 'No settings changed')
    return
  }
  const result = authenticateService.handleResponse(response)
  if (result.data || result.data === '') {
    await store.dispatch('alert/success', 'Update successful')
    return
  }
  if (result.error) {
    await store.dispatch('alert/error', result.error)
  }
}
