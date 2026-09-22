<script setup>
import ArtworkCard from '@/components/ArtworkCard.vue';
import { onMounted  } from 'vue';
import { useArtworkStore } from '@/stores/artworkStore';
import { RouterLink } from 'vue-router';

defineProps({ limit: Number })

const artworkStore = useArtworkStore()

onMounted(() => {
  artworkStore.fetchArtworks()
})
</script>

<template>
  <main class="flex-1 bg-slate-100 px-4 py-10 sm:px-6 lg:px-8">
    <section class="mx-auto flex max-w-7xl items-center justify-between">
      <h1 class="mb-6 text-3xl font-bold tracking-tight text-slate-900" >Gallery</h1>
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



      <div class="grid grid-cols-1 gap-6 md:grid-cols-2 lg:grid-cols-4">
        <ArtworkCard
         v-for="artwork in artworkStore.artworks.slice(0, limit || artworkStore.artworks.length)"
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
