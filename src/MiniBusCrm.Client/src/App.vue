<template>
  <div id="q-app">
    <router-view />
  </div>
</template>
<script>
export default {
  name: 'App',
  watch: {
    $route (to, from) {
      // clear alert on location change
      this.$store.dispatch('alert/clear')
      this.$store.dispatch('app/setCurrentPage', to.meta.breadcrumb)
    }
  }
}
</script>
