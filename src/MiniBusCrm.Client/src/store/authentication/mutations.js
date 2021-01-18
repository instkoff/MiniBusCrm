export function loginRequest (state, user) {
  state.initialState.status = { loggingIn: true }
  state.initialState.user = user
}

export function loginSuccess (state, user) {
  state.initialState.status = { loggedIn: true }
  state.initialState.user = user
}

export function loginFailure (state) {
  state.initialState.status = {}
  state.initialState.user = null
}

export function logout (state) {
  state.initialState.status = {}
  state.initialState.user = null
}
