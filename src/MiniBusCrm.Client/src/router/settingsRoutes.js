import { linksInfo } from 'src/common/const'

export const nsiRoutes = {
  buses: {
    name: 'buses',
    path: 'buses',
    component: () => import('pages/Nsi/Buses.vue'),
    meta: {
      breadcrumb: [
        linksInfo.nsiRoutes,
        linksInfo.nsiRoutes.children.buses
      ]
    }
  },
  busDrivers: {
    name: 'busDrivers',
    path: 'bus-drivers',
    component: () => import('pages/nsi/BusDrivers.vue'),
    meta: {
      breadcrumb: [
        linksInfo.nsiRoutes,
        linksInfo.nsiRoutes.children.busDrivers
      ]
    }
  },
  passengers: {
    name: 'passengers',
    path: 'passengers',
    component: () => import('pages/nsi/Passengers.vue'),
    meta: {
      breadcrumb: [
        linksInfo.nsiRoutes,
        linksInfo.nsiRoutes.children.passengers
      ]
    }
  },
  routes: {
    name: 'routes',
    path: 'routes',
    component: () => import('pages/nsi/Routes.vue'),
    meta: {
      breadcrumb: [
        linksInfo.nsiRoutes,
        linksInfo.nsiRoutes.children.routes
      ]
    }
  },
  [Symbol.iterator] () {
    let index = 0
    const properties = Object.keys(this)
    let Done = false
    return {
      next: () => {
        Done = (index >= properties.length)
        const obj = {
          done: Done,
          value: this[properties[index]],
          key: properties[index]
        }
        index++
        return obj
      }
    }
  }
}

export const settingsRoutes = {
  usersSettings: {
    name: 'users',
    path: 'users',
    component: () => import('pages/Settings/Users.vue'),
    meta: {
      breadcrumb: [
        linksInfo.settings,
        linksInfo.settings.children.users
      ]
    }
  },
  [Symbol.iterator] () {
    let index = 0
    const properties = Object.keys(this)
    let Done = false
    return {
      next: () => {
        Done = (index >= properties.length)
        const obj = {
          done: Done,
          value: this[properties[index]],
          key: properties[index]
        }
        index++
        return obj
      }
    }
  }
}
