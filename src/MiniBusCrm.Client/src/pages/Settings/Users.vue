<template>
  <q-page padding>
    <div class="row justify-center">
      <q-table
        :class="usersList.length > 0 ? 'sticky-header' : 'empty-table'"
        title="Users"
        :data="usersList"
        :columns="columns"
        :visible-columns="visibleColumns"
        row-key="id"
        no-data-label="Нет данных"
        no-results-label="Ничего не нашлось"
        selection="single"
        :selected.sync="selectedUser"
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
            <q-btn flat :disable="!dataReady" label="Добавить" icon="add" @click="createUserBtnClick"/>
            <q-btn flat :disable="!dataReady || selectedUser.length === 0" label="Править" icon="edit" />
            <q-btn flat :disable="!dataReady || selectedUser.length === 0" label="Удалить" icon="remove" @click="deleteUserBtnClick" />
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
    </div>
    <new-user-dialog v-model="newUserOpenDialog" @refresh="updateUsers"/>
  </q-page>
</template>

<script>
import { userService } from 'src/services/users'
import { mapGetters } from 'vuex'
import { date } from 'quasar'
import NewUserDialog from 'components/NewUserDialog'

export default {
  name: 'Users',
  components: { NewUserDialog },
  async mounted () {
    await this.getUsersList()
    this.dataReady = true
  },
  data () {
    return {
      usersList: [],
      selectedUser: [],
      dataReady: false,
      newUserOpenDialog: false,
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
            return row.firstName + ' ' + row.lastName
          },
          sortable: true
        },
        {
          name: 'date',
          label: 'Дата создания',
          align: 'center',
          field: 'createDate',
          format: val => date.formatDate(val, 'DD.MM.YYYY HH:mm:ss'),
          sortable: true
        },
        {
          name: 'username',
          label: 'Имя пользователя',
          align: 'left',
          field: 'username',
          sortable: false
        },
        {
          name: 'role',
          label: 'Роль',
          align: 'left',
          field: 'role',
          sortable: true
        }
      ],
      visibleColumns: ['username', 'role', 'fio', 'date']
    }
  },
  methods: {
    async getUsersList () {
      const result = await userService.getAllUsers()
      if (result.error) {
        await this.$store.dispatch('alert/error', result.error)
        return
      }
      this.usersList.splice(0, this.usersList.length, ...result.data.data)
    },
    onRowClick (evt, row) {
      if (this.selectedUser.length > 0 && row.id === this.selectedUser[0].id) {
        this.selectedUser.pop()
        return
      }
      this.selectedUser.pop()
      this.selectedUser.push(row)
    },
    async deleteUserBtnClick () {
      const result = await userService.deleteUser(this.selectedUser[0].id)
      if (result.error) {
        await this.$store.dispatch('alert/error', result.error)
      }
      await this.getUsersList()
    },
    async createUserBtnClick () {
      this.newUserOpenDialog = true
    },
    async updateUsers () {
      await this.getUsersList()
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
