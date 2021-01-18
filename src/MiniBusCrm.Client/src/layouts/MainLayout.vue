<template>
  <q-layout view="hHh Lpr lFf">
    <q-header>
      <div class="row no-wrap shadow-1">
        <q-toolbar class="bg-grey-3">
          <q-btn color="white" text-color="black"
                 flat
                 dense
                 round
                 icon="menu"
                 aria-label="Menu"
                 @click="changeDrawerState"
          />
          <q-toolbar-title class="text-black flex items-center">
            <q-icon name="img:icons/rusal_on_white_32.png" class="q-mr-md"/>
            MiniBus Crm
            <q-separator vertical class="q-ml-md"></q-separator>
            <q-breadcrumbs gutter="xs" class="q-ml-md">
              <q-breadcrumbs-el v-for="(bc, index) in currentPage" :key="index">
                <template>
                  <q-icon class="q-mr-xs" size="21px" v-if="bc.icon" :name="bc.icon"></q-icon>
                  <span v-if="bc.linkTo">
                    <router-link style="text-decoration: none;" active-class="text-primary" exact-active-class="text-black" :to="bc.linkTo">
                      {{bc.title}}
                    </router-link>
                  </span>
                  <span v-else>{{bc.title}}</span>
                </template>
              </q-breadcrumbs-el>
            </q-breadcrumbs>
          </q-toolbar-title>
        </q-toolbar>
      </div>
    </q-header>
    <q-drawer
      v-model="leftDrawerOpen"
      :width = "200"
      show-if-above
      bordered
      content-class="bg-grey-1"
    >
      <q-list>
        <q-item-label header class="text-grey-8"> Menu </q-item-label>
        <EssentialLink
          v-for="(link, index) in essentialLinks"
          :key="index"
          v-bind="link"
        />
        <q-item-label header class="text-grey-8"> Вы вошли как: </q-item-label>
        <q-separator/>
          <q-expansion-item v-if="currentUser"
                            :label="currentUser.username"
                            icon="perm_identity"
          >
            <q-card>
              <q-card-section>
                <div class="text-subtitle2" style="font-size: 16px">{{currentUser.firstName}} {{currentUser.lastName}}</div>
              </q-card-section>
              <q-separator />

              <q-card-actions align="right">
                <q-btn @click="userExit" size="md" label="Выход" flat></q-btn>
              </q-card-actions>
            </q-card>
          </q-expansion-item>
        <q-separator></q-separator>
      </q-list>
    </q-drawer>
    <q-page-container>
      <router-view />
    </q-page-container>
  </q-layout>
</template>

<script>
import EssentialLink from 'components/EssentialLink.vue'
import { linksInfo } from 'src/common/const'
import { mapGetters } from 'vuex'

export default {
  name: 'MainLayout',
  components: { EssentialLink },
  mounted () {
    this.essentialLinks = Object.fromEntries(
      Object.entries(linksInfo).filter(([key, value]) => {
        return value.access.includes(this.currentUser.username)
      })
    )
  },
  data () {
    return {
      essentialLinks: []
    }
  },
  computed: {
    ...mapGetters('app', ['currentPage']),
    ...mapGetters('authentication', ['currentUser']),

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
    },
    userExit () {
      this.$store.dispatch('authentication/logout')
      location.reload()
    }
  }
}
</script>
