<script setup>
import {  RouterView } from 'vue-router'
import AppNavbar from '@/components/AppNavbar.vue';
</script>

<template>
  <div class="flex min-h-screen flex-col">
    <AppNavbar />
    <RouterView />
  </div>

</template>

<style scoped>

</style>
