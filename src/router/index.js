import { createRouter, createWebHistory } from 'vue-router'
import LoginView from '@/views/LoginView.vue'
import DashboardView from '@/views/DashboardView.vue'
import ArtworksView from '@/views/ArtworksView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'dashboard',
      component: DashboardView,
    },
    {
      path: '/login',
      name: 'login',
      component: LoginView,
    },
    {
      path: '/artworks',
      name: 'artworks',
      component: ArtworksView,
    },
    {
      path: '/artworks',
      name: 'artworks',
      component: ArtworksView,
    },
  ],
})

export default router
