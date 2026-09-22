<script setup>
import ArtworkCard from '@/components/ArtworkCard.vue';
</script>

<template>
  <main class="flex-1 bg-slate-100 px-4 py-10 sm:px-6 lg:px-8">
    <section class="mx-auto max-w-7xl">
      <h1 class="mb-6 text-3xl font-bold tracking-tight text-slate-900" >Dashboard</h1>
    </section>
    <section class="mx-auto max-w-7xl mb-6">

      <h1 class="mb-6 text-2xl font-bold tracking-tight text-slate-900">Artworks</h1>

      <div class="grid grid-cols-1 gap-6 md:grid-cols-2 lg:grid-cols-4">
        <ArtworkCard title="Cyber Ninja" img-url="/Cyber-ninja-sketches-V15-22.png"/>
        <ArtworkCard title="Encounter" img-url="public\Encounter-V04-6.png"/>
        <ArtworkCard title="Zheng's Shop" img-url="public\Illustration5-VFinale.jpg"/>
        <ArtworkCard title="Journey" img-url="public\Illustration6-V06-11.png"/>
      </div>
    </section>

    <section class="mx-auto max-w-7xl">

      <h1 class="mb-6 text-2xl font-bold tracking-tight text-slate-900">Posts</h1>

      <div class="grid grid-cols-1 gap-6 md:grid-cols-2 lg:grid-cols-4">
        <ArtworkCard />
        <ArtworkCard />
        <ArtworkCard />
        <ArtworkCard />
      </div>
    </section>
  </main>
</template>

<style scoped>

</style>
