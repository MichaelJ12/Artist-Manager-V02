<script setup>
import { ref , onMounted } from 'vue'
import { useRoute } from 'vue-router';
import { useArtworkStore } from '@/stores/artworkStore';
import api from '@/services/api';

const route = useRoute()
const artwork = ref(null)
const artworkStore = useArtworkStore()

onMounted(async () => {
  try {
    const response = await api.get(`/artworks/${route.params.id}`)
    artwork.value = response.data
    console.log(response.data);

  } catch (err) {
    console.error('something went wrong', err)
  }
})
</script>

<template>
  <main class="grid flex-1 bg-slate-100 px-4 py-6 sm:px-6 lg:grid-cols-[minmax(0,1fr)_minmax(18rem,24rem)] lg:gap-10 lg:px-8 lg:py-10">
    <div v-if="artwork" class="flex items-center justify-center  rounded-lg bg-white">
      <img
        :src="artworkStore.resolveImageUrl(artwork.imageUrl)"
        :alt="artwork.title"
        class="max-h-[calc(100vh-10rem)] w-full object-contain"
      />

    </div>

    <aside v-if="artwork" class="flex items-start  ">
      <div class="w-full text-center py-6 text-2xl font-bold tracking-tight text-slate-900 bg-white  lg:rounded-lg ">
          <h1>{{ artwork.title }}</h1>
      </div>
    </aside>

  </main>
</template>

<style scoped>

</style>
