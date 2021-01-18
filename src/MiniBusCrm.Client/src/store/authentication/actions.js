import { authenticateService } from 'src/services/authenticate'

export async function login ({ dispatch, commit }, { username, password }) {
  commit('loginRequest', { username })

  const result = await authenticateService.login(username, password)
  if (result.user) {
    commit('loginSuccess', result.user)
    await this.$router.push('/')
  }
  if (result.error) {
    commit('loginFailure', result.error)
    dispatch('alert/error', result.error, { root: true })
  }
}
export function logout ({ commit }) {
  authenticateService.logout()
  commit('logout')
}
