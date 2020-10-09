const routes = [
  {
    path: '/',
    component: () => import('layouts/MainLayout.vue'),
    children: [
      { path: '', component: () => import('pages/Index.vue'), meta: { name: 'Главная' } },
      { path: 'order-wizard', component: () => import('pages/Order-wizard.vue'), meta: { name: 'Оформить билет' } },
      { path: 'planes', component: () => import('pages/Planes.vue'), meta: { name: 'Рейсы' } }
    ]
  },

  // Always leave this as last one,
  // but you can also remove it
  {
    path: '*',
    component: () => import('pages/Error404.vue')
  }
]

export default routes
