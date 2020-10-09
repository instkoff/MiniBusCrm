
<template>
  <q-layout view="hHh lpR fFf">

    <q-header elevated class="bg-grey-3 text-black">
      <q-toolbar>
        <q-btn dense flat round icon="menu" @click="changeDrawerState" />

        <q-toolbar-title>
          <q-avatar>
            <img src="minibus-logo.svg">
          </q-avatar>
          MiniBus Crm
        </q-toolbar-title>
      </q-toolbar>
    </q-header>

    <q-drawer
      v-model="leftDrawerOpen"
      :width = "200"
      show-if-above
      elevated
      behavior="desktop"
      content-class="bg-grey-1"
    >
      <q-list>
        <q-item-label
          header
          class="text-black"
        >
          Основное
        </q-item-label>
        <EssentialLink
          v-for="link in mainMenuLinks"
          :key="link.title"
          v-bind="link"
        />
        <q-separator></q-separator>
        <q-item-label
          header
          class="text-black"
        >
          НСИ
        </q-item-label>
        <EssentialLink
          v-for="link in nsiLinks"
          :key="link.title"
          v-bind="link"
        />
      </q-list>
    </q-drawer>
    <q-page-container>
      <router-view />
    </q-page-container>
  </q-layout>
</template>

<script>
import EssentialLink from 'components/EssentialLink.vue'
import { mainMenuLinks, nsiLinks } from 'src/common/const'

export default {
  name: 'MainLayout',
  components: { EssentialLink },
  data () {
    return {
      mainMenuLinks: mainMenuLinks,
      nsiLinks: nsiLinks
    }
  },
  computed: {
    leftDrawerOpen: {
      get () {
        return this.$store.state.app.leftDrawerOpen
      },
      set (val) {
        this.$store.dispatch('app/setDrawerState', val)
      }
    }
  },
  methods: {
    changeDrawerState () {
      this.$store.dispatch('app/changeDrawerState')
    }
  }
}
</script>
