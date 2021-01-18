import { axiosInstance } from 'boot/axios'
import { authHeader } from 'src/common/auth-header'
import { authenticateService } from 'src/services/authenticate'

export const busDriversService = {
  getAll,
  get,
  create,
  deleteDriver,
  update
}

async function getAll () {
  const response = await axiosInstance.get('/BusDriver', { headers: authHeader() })
    .catch(response => response)
  return authenticateService.handleResponse(response)
}
async function get (id) {
  const response = await axiosInstance.get('/BusDriver/id', { headers: authHeader(), params: id })
    .catch(response => response)
  return authenticateService.handleResponse(response)
}
async function create (driver) {
  const response = await axiosInstance.post('/BusDriver', driver, { headers: authHeader() })
    .catch(response => response)
  return authenticateService.handleResponse(response)
}
async function update (driver) {
  const response = await axiosInstance.put('/BusDriver', driver, { headers: authHeader() })
    .catch(response => response)
  return authenticateService.handleResponse(response)
}
async function deleteDriver (id) {
  const response = await axiosInstance.delete('/BusDriver/id', { headers: authHeader(), params: { id: id } })
    .catch(response => response)
  return authenticateService.handleResponse(response)
}
