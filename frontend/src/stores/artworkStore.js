import { defineStore } from 'pinia'
import { ref } from 'vue'
import api from '@/services/api'

export const useArtworkStore = defineStore('artworks', () => {
  const artworks = ref([])
  const loading = ref(false)
  const error = ref(null)

  async function fetchArtworks() {
    loading.value = true
    error.value = null
    try {
      const response = await api.get('/artworks')
      artworks.value = response.data
    } catch (err) {
      error.value = err
      console.error('Failed to fetch artworks:', err)
    } finally {
      loading.value = false
    }
  }

  return { artworks, loading, error, fetchArtworks }
})
