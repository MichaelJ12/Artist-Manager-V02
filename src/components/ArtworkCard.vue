<script setup>
import { defineProps } from 'vue';

defineProps({
  limit: Number,
  title: String,
  imgUrl: URL,
  alt: String
})

</script>

<template>
      <div class="bg-white rounded-lg shadow overflow-hidden">
          <img :src="imgUrl" alt="{{ alt }}" class="w-full h-48 object-cover" >
          <div class="py-4 ml-3">
              <h3 class=" font-bold text-lg" >
                  {{ title }}
              </h3>
          </div>
      </div>
</template>
