<script setup>
import { ref } from 'vue'

const isMenuOpen = ref(false)
</script>

<template>
	<header class="border-b border-slate-200 bg-white">
		<nav class="mx-auto flex max-w-7xl items-center justify-between px-4 py-4 sm:px-6 lg:px-8" aria-label="Main navigation">
			<RouterLink class="text-xl font-bold tracking-tight text-slate-900" to="/" @click="isMenuOpen = false">
				Artist Manager
			</RouterLink>

			<button
				type="button"
				class="rounded-lg p-2 text-slate-600 hover:bg-slate-100 hover:text-slate-900 focus:outline-none focus:ring-2 focus:ring-indigo-500 sm:hidden"
				:aria-expanded="isMenuOpen"
				aria-controls="main-navigation"
				aria-label="Toggle navigation menu"
				@click="isMenuOpen = !isMenuOpen"
			>
				<span class="block h-0.5 w-5 bg-current"></span>
				<span class="mt-1 block h-0.5 w-5 bg-current"></span>
				<span class="mt-1 block h-0.5 w-5 bg-current"></span>
			</button>

			<div
				id="main-navigation"
				:class="isMenuOpen ? 'block' : 'hidden'"
				class="absolute left-0 right-0 top-18.25 z-10 border-b border-slate-200 bg-white px-4 py-4 shadow-sm sm:static sm:block sm:border-0 sm:p-0 sm:shadow-none"
			>
				<div class="flex flex-col gap-2 sm:flex-row sm:items-center sm:gap-6">
					<RouterLink
						class="rounded-md px-3 py-2 text-sm font-medium text-slate-700 hover:bg-slate-100 hover:text-slate-900"
						active-class="bg-indigo-50 text-indigo-700"
						to="/artworks"
						@click="isMenuOpen = false"
					>
						Artworks
					</RouterLink>
					<RouterLink
						class="rounded-md px-3 py-2 text-sm font-medium text-slate-700 hover:bg-slate-100 hover:text-slate-900"
						active-class="bg-indigo-50 text-indigo-700"
						to="/login"
						@click="isMenuOpen = false"
					>
						Log in
					</RouterLink>
				</div>
			</div>
		</nav>
	</header>
</template>

<style scoped>

</style>
