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
          name: 'batches',
          component: () => import('../views/Batches/IndexView.vue')
        },
        {
          path: 'new',
          component: () => import('../views/Batches/NewView.vue')
        },
        {
          path: 'edit/:id',
          component: () => import('../views/Batches/EditView.vue')
        }
      ]
    },
    {
      path: '/accounts',
      name: 'accounts',
      children: [
        {
          path: '',
          name: 'accounts',
          component: () => import('../views/Accounts/IndexView.vue')
        },
        {
          path: 'new',
          component: () => import('../views/Accounts/NewView.vue')
        },
        {
          path: 'edit/:id',
          component: () => import('../views/Accounts/EditView.vue')
        }
      ]
    },
    {
      path: '/companies',
      name: 'companies',
      children: [
        {
          path: '',
          name: 'companies',
          component: () => import('../views/Companies/IndexView.vue')
        },
        {
          path: 'new',
          component: () => import('../views/Companies/NewView.vue')
        },
        {
          path: 'edit/:id',
          component: () => import('../views/Companies/EditView.vue')
        }
      ]
    }
  ]
})

export default router
