<template>
  <q-page padding>
    <bus-driver-table/>
  </q-page>
</template>

<script>
import BusDriverTable from 'components/BusDriversTable'
export default {
  name: 'BusDrivers',
  components: { BusDriverTable }
}
</script>
