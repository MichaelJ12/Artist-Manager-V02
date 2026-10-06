<script setup>
import ActionButton from '@/components/ActionButton.vue';
import { useNavigation } from '@/composables/useNavigation';
import api from '@/services/api';
import { ref } from 'vue';
import { toast } from 'vue3-toastify';

const { router } = useNavigation()


const username = ref('')
const email = ref('')
const password = ref('')

async function register() {
  const formData = new FormData()

  formData.append('username', username.value)
  formData.append('email', email.value)
  formData.append('password', password.value)

  try {
    await api.post('/Auth/register', formData, {
      headers : { 'Content-Type' : 'multipart/form-data' }
    })

    router.push({
      name: 'login',
      query: { toast: 'created' },
    })

  } catch(err) {
    toast.error('Failed to register')
    console.error(err);
  }
}
</script>

<template>
	<main class="flex flex-1 items-center justify-center bg-slate-100 ">
		<section class="w-full max-w-md rounded-xl bg-white p-8 shadow-lg ring-1 ring-slate-200">
			<div class="mb-8">
				<h1 class="text-3xl font-bold tracking-tight text-slate-900">Register in</h1>
				<p class="mt-2 text-sm text-slate-600">Register ur details.</p>
			</div>

			<form  class="space-y-5" @submit.prevent="register">
        <div>
					<label class="mb-2 block text-sm font-medium text-slate-700" for="username">Username</label>
					<input
						id="username"
            v-model="username"
						name="username"
						type="username"
						autocomplete="username"
						required
						class="block w-full rounded-lg border border-slate-300 px-3 py-2.5 text-slate-900 outline-none transition placeholder:text-slate-400 focus:border-indigo-500 focus:ring-2 focus:ring-indigo-200"
					/>
				</div>

				<div>
					<label class="mb-2 block text-sm font-medium text-slate-700" for="email">Email</label>
					<input
						id="email"
            v-model="email"
						name="email"
						type="email"
						autocomplete="email"
						required
						class="block w-full rounded-lg border border-slate-300 px-3 py-2.5 text-slate-900 outline-none transition placeholder:text-slate-400 focus:border-indigo-500 focus:ring-2 focus:ring-indigo-200"
					/>
				</div>

				<div>
					<label class="mb-2 block text-sm font-medium text-slate-700" for="password">Password</label>
					<input
						id="password"
            v-model="password"
						name="password"
						type="password"
						autocomplete="password"
						required
						class="block w-full rounded-lg border border-slate-300 px-3 py-2.5 text-slate-900 outline-none transition placeholder:text-slate-400 focus:border-indigo-500 focus:ring-2 focus:ring-indigo-200"
					/>
				</div>
        <ActionButton  type="submit" label="Submit"/>
  </form>
		</section>
	</main>
</template>

<style scoped>

</style>
