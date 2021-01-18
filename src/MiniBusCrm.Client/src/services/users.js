import { axiosInstance } from 'boot/axios'
import { authHeader } from 'src/common/auth-header'
import { authenticateService } from 'src/services/authenticate'

export const userService = {
  getAllUsers,
  getUser,
  createUser,
  deleteUser,
  updateUser,
  getRoles
}

async function getAllUsers () {
  const response = await axiosInstance.get('/User/get-all', { headers: authHeader() })
    .catch(response => response)
  return authenticateService.handleResponse(response)
}
async function getUser (id) {
  const response = await axiosInstance.get(`/User/get-user/${id}`, { headers: authHeader() })
    .catch(response => response)
  return authenticateService.handleResponse(response)
}
async function createUser (user) {
  const response = await axiosInstance.post('/User/create', user, { headers: authHeader() })
    .catch(response => response)
  return authenticateService.handleResponse(response)
}
async function updateUser (user) {
  const response = await axiosInstance.post('/User/update', { headers: authHeader(), params: user })
    .catch(response => response)
  return authenticateService.handleResponse(response)
}
async function deleteUser (id) {
  const response = await axiosInstance.delete(`/User/delete/${id}`, { headers: authHeader() })
    .catch(response => response)
  return authenticateService.handleResponse(response)
}
async function getRoles () {
  const response = await axiosInstance.get('/User/roles', { headers: authHeader() })
    .catch(response => response)
  return authenticateService.handleResponse(response)
}
