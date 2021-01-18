import { axiosInstance } from 'boot/axios'

export const authenticateService = {
  login,
  logout,
  handleResponse
}

async function login (username, password) {
  const response = await axiosInstance.post('/User/authenticate', { username: username, password: password }, { headers: { 'Content-Type': 'application/json' } })
    .catch(response => response)
  const result = handleResponse(response)
  if (result.data) {
    localStorage.setItem('user', JSON.stringify(result.data))
    return { user: result.data }
  }
  if (result.error) {
    return { error: result.error }
  }
}

function logout () {
  // remove user from local storage to log user out
  localStorage.removeItem('user')
}

function handleResponse (response) {
  if (response instanceof Error) {
    if (response.response && [401, 403].includes(response.response.status)) {
      // auto logout if 401 Unauthorized or 403 Forbidden response returned from api
      authenticateService.logout()
      location.reload()
    }
    return { error: (response.response && response.response.data.message) || (response && response.message) }
  }
  return { data: response.data }
}
