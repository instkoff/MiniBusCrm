<template>
  <q-dialog :value="value" @input="handleInput">
    <q-card>
      <q-card-section>
        <div class="text-h6">Создать пользователя</div>
      </q-card-section>

      <q-separator/>

      <q-card-section style="min-width: 70vh" class="scroll">

      <form name="user" @submit.prevent.stop="submitForm"  @reset.prevent.stop="resetForm">
        <q-input
          name="firstName"
          ref="firstName"
          filled
          v-model="user.firstName"
          label="First name *"
          hint="First name"
          lazy-rules
          :rules="[ val => val && val.length > 0 || 'Please type something']"
        />

        <q-input
          name="lastName"
          ref="lastName"
          filled
          v-model="user.lastName"
          label="Last name *"
          hint="Last name"
          lazy-rules
          :rules="[ val => val && val.length > 0 || 'Please type something']"
        />

        <q-input
          name="username"
          ref="username"
          filled
          v-model="user.username"
          label="Username *"
          hint="Username"
          lazy-rules
          :rules="[ val => val && val.length > 3 || 'Username must > 3 letters']"
        />

        <q-input
          name="password"
          ref="password"
          v-model="user.password"
          label="Password *"
          filled
          :type="isPwd ? 'password' : 'text'"
          hint="Password"
          lazy-rules
          :rules="[ val => val && val.length > 3 || 'Username must > 3 letters']"
        >
          <template v-slot:append>
            <q-icon
              :name="isPwd ? 'visibility_off' : 'visibility'"
              class="cursor-pointer"
              @click="isPwd = !isPwd"
            />
          </template>
        </q-input>
        <q-select
          name="role"
          ref="role"
          filled
          v-model="user.role"
          :options="rolesOptions"
          use-input
          hide-selected
          fill-input
          input-debounce="0"
          label="User role"
          @filter="filterFn"
          @input-value="setModel"
          lazy-rules
          :rules="[ val => val && this.userRoles.includes(val) || 'Select role']"
        >
          <template v-slot:no-option>
            <q-item>
              <q-item-section class="text-grey">
                No results
              </q-item-section>
            </q-item>
          </template>
        </q-select>
        <q-card-actions align="right">
          <q-btn label="Сохранить" type="submit" color="primary"/>
          <q-btn label="Сброс" type="reset" color="primary" flat class="q-ml-sm"/>
        </q-card-actions>
      </form>
      </q-card-section>
    </q-card>
  </q-dialog>
</template>

<script>
import { User } from 'src/common/models'
import { userService } from 'src/services/users'

export default {
  name: 'NewUserDialog',
  props: {
    value: {
      type: Boolean,
      default: false
    }
  },
  async mounted () {
    this.userRoles.splice(0, this.userRoles.length, ...await this.getUserRoles())
  },
  data () {
    return {
      user: new User(),
      isPwd: true,
      userRoles: [],
      rolesOptions: this.userRoles
    }
  },
  methods: {
    handleInput (value) {
      this.$emit('input', value)
    },
    async submitForm () {
      this.$refs.firstName.validate()
      this.$refs.lastName.validate()
      this.$refs.username.validate()
      this.$refs.password.validate()
      this.$refs.role.validate()
      const hasError = this.$refs.firstName.hasError || this.$refs.lastName.hasError || this.$refs.username.hasError || this.$refs.password.hasError || this.$refs.role.hasError
      if (hasError) {
        console.log(hasError)
        this.formHasError = true
      } else {
        const result = await userService.createUser(this.user)
        if (result.error) {
          await this.$store.dispatch('alert/error', result.error)
          return
        }
        this.$emit('refresh')
        this.handleInput(false)
        this.user = new User()
      }
    },
    resetForm () {
      this.$refs.firstName.resetValidation()
      this.$refs.lastName.resetValidation()
      this.$refs.username.resetValidation()
      this.$refs.password.resetValidation()
      this.$refs.role.resetValidation()
      this.user = new User()
    },
    async getUserRoles () {
      const result = await userService.getRoles()
      if (result.error) {
        await this.$store.dispatch('alert/error', result.error)
      }
      return result.data.roles
    },
    filterFn (val, update, abort) {
      update(() => {
        const needle = val.toLocaleLowerCase()
        this.rolesOptions = this.userRoles.filter(v => v.toLocaleLowerCase().indexOf(needle) > -1)
      })
    },
    setModel (val) {
      this.user.role = val
    }
  }
}
</script>
