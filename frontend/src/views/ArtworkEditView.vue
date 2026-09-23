<script setup>
import { ref , onMounted, watch } from 'vue'
import { useRoute } from 'vue-router';
import { useArtworkStore } from '@/stores/artworkStore';
import api from '@/services/api';
import ActionButton from '@/components/ActionButton.vue'
import { useNavigation } from '@/composables/useNavigation';
import { toast } from 'vue3-toastify'
import router from '@/router';

const { goBackOrTo } = useNavigation()
const route = useRoute()
const artwork = ref(null)
const artworkStore = useArtworkStore()
const errorMsg = ref('')

function validateTitle(title) {
  if (!title || title.trim() === '') return 'Title is required'
  if (title.trim().length < 3 ) return 'Title needs atleast 3 characters'
  return ''
}

watch(() => artwork.value?.title, (newTitle) => {
    errorMsg.value = validateTitle(newTitle)
  },
  { immediate: true }
)

async function UpdateArtwork() {
  const validationMessage = validateTitle(artwork.value?.title)
  errorMsg.value = validationMessage

  if (validationMessage) {
    return
  }

  try {
    await api.put(`/artworks/${route.params.id}`, {
      title: artwork.value.title,
      imageUrl: artwork.value.imageUrl,
      userId: 1,
    })

    router.push({
      name: 'artworks',
      query: { toast: 'updated' },
    })
  } catch (error) {
    toast.error('Failed to update artwork')
    console.error('something went wrong', error)
  }
}

onMounted(async () => {
  try {
    const response = await api.get(`/artworks/${route.params.id}`)
    artwork.value = response.data

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
        :alt="artwork.title.value"
        class="max-h-[calc(100vh-10rem)] w-full object-contain"
      />

    </div>

    <aside v-if="artwork" class="flex items-start  ">
      <div class="w-full  p-6  tracking-tight text-slate-900 bg-white  lg:rounded-lg ">
        <form @submit.prevent="UpdateArtwork" enctype="multipart/form-data" class="space-y-6">

                <label for="title" class="mb-6 block text-center text-2xl font-bold text-slate-700">Title</label>
                <input id="title" type="text" name="title" v-model="artwork.title"
                 class=" w-full rounded-lg border border-slate-300 bg-white mb-6 px-3 py-2 text-slate-900 outline-none transition focus:border-emerald-500 focus:ring-2 focus:ring-emerald-200"
                >
                <p v-if="errorMsg" class="text-red-500">
                  {{ errorMsg }}
                </p>
                <div class="flex justify-between">
                  <ActionButton
                    type="button"
                    label="Cancel"
                    color="red"
                    @click="goBackOrTo"
                  />

                  <ActionButton
                    type="submit"
                    label="Submit"
                    color="emerald"
                  />
                </div>


        </form>
      </div>
    </aside>

  </main>
</template>

<style scoped>

</style>
