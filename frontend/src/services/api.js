import axios from 'axios'
import { useAuthStore } from '@/stores/auth'

const api = axios.create({
  baseURL: 'https://localhost:7221/api'
})

api.interceptors.request.use((config) => {
  const authStore = useAuthStore()
  if (authStore.accessToken) {
    config.headers.set('Authorization', `Bearer ${authStore.accessToken}`)
  }
  return config
})

api.interceptors.response.use(
  (response) => response,
  async (error) => {
    if (error.response?.status == 401) {
      const authStore = useAuthStore()
      try {
        await authStore.refreshToken()

        return api(error.config)
      } catch {
        authStore.logout()
        if (window.location.href != 'http://localhost:5173/login'){
          window.location.href = '/login'
        }
      }
    }
    return Promise.reject(error)
  }
)

export default api
