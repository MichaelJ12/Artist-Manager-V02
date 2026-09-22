import axios from 'axios'

const api = axios.create({
  baseURL: 'https://localhost:7221/api'
})

export default api
