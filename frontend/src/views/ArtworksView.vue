<script setup>
import ArtworkCard from '@/components/ArtworkCard.vue';
import { ref, onMounted, computed, watch  } from 'vue';
import { useArtworkStore } from '@/stores/artworkStore';
import { RouterLink } from 'vue-router';
import { Search } from 'lucide-vue-next'

defineProps({ limit: Number })

const search = ref('')
const artworkStore = useArtworkStore()
const result = ref(false)

const filteredArtworks = computed(() => {
  return artworkStore.artworks.filter((artwork) => {
    const query = search.value.trim().toLowerCase()
    if (!query) {
      return true
    }

    return artwork.title.toLowerCase().includes(query)
  })
})

watch(filteredArtworks, (filteredSearch) => {
  result.value = filteredSearch.length === 0
})
onMounted(() => {
  artworkStore.fetchArtworks()
})
</script>

<template>
  <main class="flex-1 bg-slate-100 px-4 py-10 sm:px-6 lg:px-8">
    <section class="mx-auto flex max-w-7xl items-center justify-between gap-4">
      <h1 class="mb-6 text-3xl font-bold tracking-tight text-slate-900" >Gallery</h1>

      <div class="relative flex-1 max-w-md">
        <span class="pointer-events-none absolute inset-y-0 left-0 flex items-center pl-3 text-slate-400">
          <Search class="h-4 w-4" />
        </span>
        <input
          v-model="search"
          placeholder="Search artworks..."
          class="w-full rounded-2xl border border-slate-300 bg-white py-2.5 pl-10 pr-4 text-sm text-slate-700 shadow-sm outline-none transition focus:border-emerald-500 focus:ring-2 focus:ring-emerald-200"
        >
      </div>

      <RouterLink
        to="/artworks/create"
        class="rounded-lg bg-emerald-400 px-7 py-3 font-bold text-white transition-colors hover:bg-emerald-500"
      >
        Upload Artwork
      </RouterLink>
    </section>
    <section class="mx-auto max-w-7xl mb-6">

      <div class="flex mb-6 ">
        <h1 class="text-2xl font-bold tracking-tight text-slate-900">Artworks</h1>
        <p class="mt-2 pl-2">{{ artworkStore.artworks.length }} Artworks</p>
      </div>
      <div v-if="result" class="flex justify-center pt-20">
        <p class="text-center">
          <Search class="h-24 w-24" />
          No results
        </p>
      </div>
      <div class="grid grid-cols-1 gap-6 md:grid-cols-2 lg:grid-cols-4">
        <ArtworkCard
         v-for="artwork in filteredArtworks"
         :key="artwork.id"
         :id="artwork.id"
         :title="artwork.title"
         :imgUrl="artwork.imageUrl"
        />
      </div>
    </section>
  </main>
</template>

<style scoped>

</style>
