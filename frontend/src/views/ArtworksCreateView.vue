<script setup>
</script>


<template>
    <main class="flex-1 bg-slate-100 px-4 py-10 sm:px-6 lg:px-8">
        <section class="mx-auto max-w-2xl">
            <div class="rounded-lg bg-white p-6 shadow-sm sm:p-8">
                <div class="mb-8">
                    <h1 class="text-3xl font-bold tracking-tight text-slate-900">Upload Artwork</h1>
                    <p class="mt-2 text-slate-600">Add a new piece to your gallery.</p>
                </div>

                <form method="POST" action="" enctype="multipart/form-data" class="space-y-6">
                    <div>
                        <label for="title" class="mb-2 block text-sm font-bold text-slate-700">Title</label>
                        <input id="title" type="text" name="title"  class="w-full rounded-lg border border-slate-300 bg-white px-3 py-2 text-slate-900 outline-none transition focus:border-emerald-500 focus:ring-2 focus:ring-emerald-200"
                        >
                    </div>

                    <div>
                        <label for="image" class="mb-2 block text-sm font-bold text-slate-700">Image</label>
                        <input id="image" type="file" name="image" accept="image/*"  class="w-full rounded-lg border border-slate-300 bg-white px-3 py-2 text-sm text-slate-700 file:mr-4 file:rounded-md file:border-0 file:bg-emerald-50 file:px-3 file:py-2 file:font-medium file:text-emerald-700 hover:file:bg-emerald-100"
                        >
                    </div>

                    <button
                        type="submit"
                        class="rounded-lg bg-emerald-400 px-6 py-3 font-bold text-white transition-colors hover:bg-emerald-500"
                    >
                        Create
                    </button>
                </form>
            </div>
        </section>
    </main>
</template>
