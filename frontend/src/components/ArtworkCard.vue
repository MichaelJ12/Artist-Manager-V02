<script setup>
import { RouterLink } from 'vue-router';
import { useArtworkStore } from '@/stores/artworkStore';

defineProps({
  id: Number,
  title: String,
  imgUrl: String,
})

const artworkStore = useArtworkStore();


</script>

<template>
      <RouterLink :to="`/artworks/${id}`"
        class="block bg-white rounded-lg shadow overflow-hidden cursor-pointer transition-transform hover:scale-105 hover:shadow-lg hover:shadow-emerald-200 ">
          <img :src="artworkStore.resolveImageUrl(imgUrl)" :alt="title" class="w-full h-48 object-cover" >
          <div class="py-4 ml-3">
              <p class=" font-bold text-lg" >
                  {{ title }}
              </p>
          </div>
      </RouterLink>
</template>
