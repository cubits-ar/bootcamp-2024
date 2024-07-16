import { createRouter, createWebHistory } from 'vue-router'
import UserList from '@/pages/User-List.vue'
import UserCreate from '@/pages/User-Create.vue'
import UserUpdate from '@/pages/User-Update.vue'
import UserDelete from '@/pages/User-Delete.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'user-list',
      component: UserList
    },
    {
      path: '/create',
      name: 'user-create',
      component: UserCreate
    },
    {
      path: '/:userId/update',
      name: 'user-update',
      component: UserUpdate
    },
    {
      path: '/:userId/delete',
      name: 'user-delete',
      component: UserDelete
    }
  ]
})

export default router
