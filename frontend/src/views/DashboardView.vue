<script setup>
import ArtworkCard from '@/components/ArtworkCard.vue';
import { onMounted  } from 'vue';
import { useArtworkStore } from '@/stores/artworkStore';

const limit = 4

const artworkStore = useArtworkStore()

onMounted(() => {
  if (artworkStore.artworks.length === 0) {
    artworkStore.fetchArtworks()
  }
})
</script>

<template>
  <main class="flex-1 bg-slate-100 px-4 py-10 sm:px-6 lg:px-8">
    <section class="mx-auto max-w-7xl">
      <h1 class="mb-6 text-3xl font-bold tracking-tight text-slate-900" >Dashboard</h1>
    </section>
    <section class="mx-auto max-w-7xl mb-6">

      <h1 class="mb-6 text-2xl font-bold tracking-tight text-slate-900">Artworks</h1>

      <div  class="grid grid-cols-1 gap-6 md:grid-cols-2 lg:grid-cols-4">
        <!-- add created_at to artwork model -->
        <ArtworkCard
         v-for="artwork in artworkStore.artworks.slice(0, limit || artworkStore.artworks.length)"
         :key="artwork.id"
         :id="artwork.id"
         :title="artwork.title"
         :imgUrl="artwork.imageUrl"
         :limit="3"
        />
      </div>
    </section>

    <section class="mx-auto max-w-7xl">

      <h1 class="mb-6 text-2xl font-bold tracking-tight text-slate-900">Posts</h1>

      <div class="grid grid-cols-1 gap-6 md:grid-cols-2 lg:grid-cols-4">

      </div>
    </section>
  </main>
</template>

<style scoped>

</style>
