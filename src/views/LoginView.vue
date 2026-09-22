<script setup>

</script>

<template>
	<main class="flex flex-1 items-center justify-center bg-slate-100 ">
		<section class="w-full max-w-md rounded-xl bg-white p-8 shadow-lg ring-1 ring-slate-200">
			<div class="mb-8">
				<h1 class="text-3xl font-bold tracking-tight text-slate-900">Log in</h1>
				<p class="mt-2 text-sm text-slate-600">Welcome back. Enter your details to continue.</p>
			</div>

			<form class="space-y-5">
				<div>
					<label class="mb-2 block text-sm font-medium text-slate-700" for="email">Email</label>
					<input
						id="email"
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
						name="password"
						type="password"
						autocomplete="current-password"
						required
						class="block w-full rounded-lg border border-slate-300 px-3 py-2.5 text-slate-900 outline-none transition placeholder:text-slate-400 focus:border-indigo-500 focus:ring-2 focus:ring-indigo-200"
					/>
				</div>

				<button
					type="submit"
					class="w-full rounded-lg bg-indigo-600 px-4 py-2.5 text-sm font-semibold text-white transition hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-indigo-500 focus:ring-offset-2"
				>
					Log in
				</button>
			</form>
		</section>
	</main>
</template>

<style scoped>

</style>
