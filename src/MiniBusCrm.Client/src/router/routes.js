import { linksInfo } from 'src/common/const'
import { nsiRoutes, settingsRoutes } from 'src/router/settingsRoutes'
import Planes from 'pages/Planes'

const routes = [
  {
    path: '/',
    component: () => import('layouts/MainLayout.vue'),
    children: [
      {
        name: 'home',
        path: '',
        component: () => import('pages/Index.vue'),
        meta: {
          breadcrumb: [
            {
              title: 'Главная',
              link: '/',
              icon: 'home'
            }
          ]
        }
      },
      {
        name: 'dashboard',
        path: 'dashboard',
        component: () => import('pages/Dashboard.vue'),
        meta: {
          breadcrumb: [
            linksInfo.dashboard
          ]
        }
      },
      {
        name: 'order-wizard',
        path: 'order-wizard',
        component: () => import('pages/Order-wizard.vue'),
        meta: {
          breadcrumb: [
            linksInfo.orderWizard
          ]
        }
      },
      {
        path: 'planes',
        component: Planes,
        children: [
          {
            name: 'planes',
            path: '',
            component: () => import('pages/Planes.vue'),
            meta: {
              breadcrumb: [
                linksInfo.planes
              ]
            }
          },
          {
            name: 'planeDetails',
            path: 'plane-details',
            component: () => import('pages/PlaneDetails.vue'),
            props: true,
            meta: {
              breadcrumb: [
                linksInfo.planes,
                linksInfo.planes.children.planeDetails
              ]
            }
          }
        ]
      },
      {
        path: 'nsi',
        component: () => import('pages/NsiView.vue'),
        children: [
          ...nsiRoutes
        ]
      },
      {
        path: 'settings',
        component: () => import('pages/Settings.vue'),
        children: [
          ...settingsRoutes
        ]
      }
    ]
  },
  {
    path: '/login',
    component: () => import('pages/Login.vue')
  },
  // Always leave this as last one,
  // but you can also remove it
  {
    path: '*',
    component: () => import('pages/Error404.vue')
  }
]

export default routes
