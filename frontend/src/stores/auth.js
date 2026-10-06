import { defineStore } from "pinia";
import api from '@/services/api'
import router from '@/router';
import { toast } from "vue3-toastify";

export const useAuthStore = defineStore('auth', {
  state: () => ({
    accessToken: localStorage.getItem('accessToken') || null,
    refreshToken: localStorage.getItem('refreshToken') || null,
    user: null
  }),

  getters: {
    isLoggedIn: (state) => !!state.accessToken
  },

  actions: {
    async login(email, password) {
        try {
          const response = await api.post('/Auth/login', {
            email,
            password
          })

          this.accessToken = response.data.accessToken
          this.refreshToken = response.data.refreshToken
          console.log(response.data)
          localStorage.setItem('accessToken', this.accessToken)
          localStorage.setItem('refreshToken', this.refreshToken)

          router.push({
            name: 'dashboard',
            query: {toast : 'created'}
          })

        } catch (error) {
          toast.error(error.response.data.detail)
          console.error(error.response);
        }
    },

    async refreshToken() {
      const response = await api.post('/Auth/refresh', {
        refreshToken: localStorage.getItem('refreshToken')
      })

      this.accessToken = response.data.accessToken
      this.refreshToken = response.data.refreshToken
      localStorage.setItem('accessToken', this.accessToken)
      localStorage.setItem('refreshToken', this.refreshToken)
    },

    logout() {
      this.accessToken = null
      this.refreshToken = null
      this.user = null
      localStorage.removeItem('accessToken')
      localStorage.removeItem('refreshToken')
    }
  }
})
