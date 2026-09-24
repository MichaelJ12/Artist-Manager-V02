<script setup>
import {  ref } from 'vue';
import { toast } from 'vue3-toastify'
import api from '@/services/api';
import ActionButton from '@/components/ActionButton.vue';
import { useNavigation } from '@/composables/useNavigation';

const { goBackOrTo, router } = useNavigation()

const title =  ref('')
const image = ref(null)

function handleFileChange(e) {
  image.value = e.target.files[0]
}

async function createArtwork() {
  const formData = new FormData()
  formData.append('Title' , title.value)
  formData.append('Image' , image.value)
  formData.append('UserId' , 1)

  try {
    await api.post('/artworks', formData, {
      headers: { 'Content-Type' : 'multipart/form-data' }
    })

    router.push({
      name: 'artworks',
      query: { toast: 'created' },
    })

  } catch (error) {
    toast.error('Failed to create artwork')
    console.error('something when wrong', error);
  }
}

</script>


<template>
    <main class="flex-1 bg-slate-100 px-4 py-10 sm:px-6 lg:px-8">
        <section class="mx-auto max-w-2xl">
            <div class="rounded-lg bg-white p-6 shadow-sm sm:p-8">
                <div class="mb-8">
                    <h1 class="text-3xl font-bold tracking-tight text-slate-900">Upload Artwork</h1>
                    <p class="mt-2 text-slate-600">Add a new piece to your gallery.</p>
                </div>
                <!-- TODO: show image that is selected. -->
                <form enctype="multipart/form-data" class="space-y-6" @submit.prevent="createArtwork">
                    <div>
                        <label for="title" class="mb-2 block text-sm font-bold text-slate-700">Title</label>
                        <input id="title" v-model="title" type="text" name="title" class="w-full rounded-lg border border-slate-300 bg-white px-3 py-2 text-slate-900 outline-none transition focus:border-emerald-500 focus:ring-2 focus:ring-emerald-200"
                        >
                    </div>

                    <div>
                        <label for="image" class="mb-2 block text-sm font-bold text-slate-700">Image</label>
                        <input id="image" type="file" name="image" accept="image/*" class="w-full rounded-lg border border-slate-300 bg-white px-3 py-2 text-sm text-slate-700 file:mr-4 file:rounded-md file:border-0 file:bg-blue-50 file:px-3 file:py-2 file:font-medium file:text-blue-700 hover:file:bg-blue-100"  @change="handleFileChange"
                        >
                    </div>
                    <div class="flex justify-between">
                      <ActionButton type="button" label="Cancel" color="red" @click="goBackOrTo('artworks')"/>
                      <ActionButton type="submit" label="Submit"/>
                    </div>

                </form>
            </div>
        </section>
    </main>
</template>
