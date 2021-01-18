import { date } from 'quasar'

export const AXIOS_URLS = {
  devBaseUrl: 'http://localhost:5000/api',
  prodBaseUrl: 'http://10.3.189.50:8000/api'
}

export const linksInfo = {
  dashboard: {
    title: 'Dashboard',
    icon: 'dashboard',
    linkTo: '/dashboard',
    access: ['admin', 'oper']
  },
  orderWizard: {
    title: 'Оформление билета',
    icon: 'receipt',
    linkTo: '/order-wizard',
    access: ['admin', 'oper']
  },
  planes: {
    title: 'Список рейсов',
    icon: 'dvr',
    linkTo: '/planes',
    access: ['admin', 'oper'],
    children: {
      planeDetails: {
        title: 'Детали рейса',
        linkTo: '/planes/plane-details',
        icon: 'alt_route'
      }
    }
  },
  nsiRoutes: {
    title: 'НСИ',
    icon: 'note',
    linkTo: null,
    access: ['admin'],
    expansionItem: true,
    children: {
      buses: {
        title: 'Автобусы',
        linkTo: '/nsi/buses',
        icon: 'directions_bus'
      },
      busDrivers: {
        title: 'Водители',
        linkTo: '/nsi/bus-drivers',
        icon: 'person'
      },
      passengers: {
        title: 'Пассажиры',
        linkTo: '/nsi/passengers',
        icon: 'group'
      },
      routes: {
        title: 'Маршруты',
        linkTo: '/nsi/routes',
        icon: 'add_road'
      }
    }
  },
  settings: {
    title: 'Настройки',
    icon: 'settings',
    linkTo: null,
    access: ['admin'],
    expansionItem: true,
    children: {
      users: {
        title: 'Users',
        linkTo: '/settings/users',
        icon: 'person'
      }
    }
  }
}

