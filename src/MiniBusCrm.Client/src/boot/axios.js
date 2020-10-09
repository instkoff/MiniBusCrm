import Vue from 'vue'
import axios from 'axios'
import { AXIOS_URLS } from 'src/common/const'

let axiosInstance = null

if (process.env.DEV) {
  axiosInstance = axios.create({
    baseURL: AXIOS_URLS.devBaseUrl
  })
}
if (process.env.PROD) {
  axiosInstance = axios.create({
    baseURL: AXIOS_URLS.prodBaseUrl
  })
}

Vue.prototype.$axios = axiosInstance

export { axiosInstance }
