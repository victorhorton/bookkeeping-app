import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'

const router = createRouter({
  linkActiveClass: 'text-white',
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
    },
    {
      path: '/batches',
      name: 'batches',
      children: [
        {
          path: '',
          component: () => import('../views/Batches/IndexView.vue')
        },
        {
          path: 'new',
          component: () => import('../views/Batches/NewView.vue')
        }
      ]
    }
  ]
})

export default router
