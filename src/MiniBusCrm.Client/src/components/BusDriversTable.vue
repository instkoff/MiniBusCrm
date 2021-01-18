<template>
    <div class="row justify-center">
      <q-table
        :class="driverList.length > 0 ? 'sticky-header' : 'empty-table'"
        title="Users"
        :data="driverList"
        :columns="columns"
        :visible-columns="visibleColumns"
        row-key="id"
        no-data-label="Нет данных"
        no-results-label="Ничего не нашлось"
        selection="single"
        :selected.sync="selectedDriver"
        :loading="!dataReady"
        :filter="filter"
        flat
        dense
        bordered
        binary-state-sort
        @row-click="onRowClick"
      >
        <template v-slot:top>
          <q-btn-group flat class="fit">
            <q-btn flat :disable="!dataReady" label="Добавить" icon="add" @click="createDriverBtnClick"/>
            <q-btn flat :disable="!dataReady || driverList.length === 0" label="Править" icon="edit" />
            <q-btn flat :disable="!dataReady || driverList.length === 0" label="Удалить" icon="remove" @click="deleteDriverBtnClick" />
            <q-space />
            <q-input dense debounce="300" color="primary" v-model="filter">
              <template v-slot:append>
                <q-icon name="search" />
              </template>
            </q-input>
          </q-btn-group>
        </template>
        <template v-slot:no-data="{ icon, message }">
          <div class="full-width row flex-center text-primary q-gutter-sm">
            <q-icon size="2em" name="sentiment_dissatisfied" />
            <div>
              {{ message }}
            </div>
            <div v-if="alert.message" class="q-pa-md text-negative">{{alert.message}}</div>
          </div>
        </template>
      </q-table>
      <new-driver-dialog v-model="newDriverOpenDialog" @refresh="updateDrivers"/>
    </div>
</template>

<script>
import { busDriversService } from 'src/services/bus-drivers'
import { date } from 'quasar'
import { mapGetters } from 'vuex'
import NewDriverDialog from 'components/NewDriverDialog'

export default {
  name: 'BusDriverTable',
  components: { NewDriverDialog },
  async mounted () {
    await this.getDriverList()
    this.dataReady = true
  },
  data () {
    return {
      driverList: [],
      selectedDriver: [],
      dataReady: false,
      newDriverOpenDialog: false,
      filter: '',
      columns: [
        {
          name: 'id',
          field: 'id'
        },
        {
          name: 'fio',
          label: 'ФИО',
          align: 'left',
          field: row => {
            return row.surname + ' ' + row.name + ' ' + row.patronymic
          },
          sortable: true
        },
        {
          name: 'document',
          label: 'Номер ВУ',
          align: 'left',
          field: row => {
            return row.documentSerialNumber + ' ' + row.documentNumber
          },
          sortable: false
        },
        {
          name: 'phone',
          label: 'Телефон',
          align: 'left',
          field: 'phoneNumber',
          sortable: false
        },
        {
          name: 'date',
          label: 'Дата создания',
          align: 'center',
          field: 'createDate',
          format: val => date.formatDate(val, 'DD.MM.YYYY HH:mm:ss'),
          sortable: true
        }
      ],
      visibleColumns: ['fio', 'document', 'phone', 'date']
    }
  },
  methods: {
    async getDriverList () {
      const result = await busDriversService.getAll()
      console.log(result)
      if (result.error) {
        await this.$store.dispatch('alert/error', result.error)
        return
      }
      this.driverList.splice(0, this.driverList.length, ...result.data)
    },
    onRowClick (evt, row) {
      if (this.selectedDriver.length > 0 && row.id === this.selectedDriver[0].id) {
        this.selectedDriver.pop()
        return
      }
      this.selectedDriver.pop()
      this.selectedDriver.push(row)
    },
    async deleteDriverBtnClick () {
      const result = await busDriversService.deleteDriver(this.selectedDriver[0].id)
      if (result.error) {
        await this.$store.dispatch('alert/error', result.error)
      }
      await this.getDriverList()
    },
    async createDriverBtnClick () {
      this.newDriverOpenDialog = true
    },
    async updateDrivers () {
      await this.getDriverList()
    }
  },
  computed: {
    ...mapGetters('alert', ['alert'])
  }
}
</script>
<style lang="sass">
.sticky-header
  width: 50%
  height: fit-content

  .q-table__top,
  .q-table__bottom,
  thead tr:first-child th
    background-color: $grey-3

  thead tr th
    position: sticky
    z-index: 1
  thead tr:first-child th
    top: 0

  &.q-table--loading thead tr:last-child th
    top: 48px

.empty-table
  width: 50%
  .q-table__top,
  thead tr:first-child th
    background-color: $grey-3
</style>
