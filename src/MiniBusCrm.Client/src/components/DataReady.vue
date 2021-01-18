<template>
  <div>
    <span v-if="alert.message" :class="alert.textColor">{{alert.message}}</span>
    <q-spinner class="fixed-center" v-if="!state" color="primary" size="3em" :thickness="10" />
  </div>
</template>

<script>
import { mapGetters } from 'vuex'

export default {
  name: 'DataReady',
  props: {
    state: {
      type: Boolean,
      default: false
    }
  },
  computed: {
    ...mapGetters('alert', ['alert'])
  }
}
</script>
