<template>
  <q-dialog v-model="prompt" persistent>
    <q-card style="min-width: 350px">
      <q-card-section>
        <div align="center" class="text-h6"><q-icon class="q-pa-none" name="img:icons/rusal-logo-x-150.png"></q-icon>Login</div>
      </q-card-section>

      <q-card-section class="q-pt-none">
        <q-form @submit="onSubmit">
        <q-input dense autofocus v-model="username" name="username" :rules="[val => !!val || 'Field is required']" label="Username" />
        <q-input dense v-model="password" name="password" label="Password" :type="isPwd ? 'password' : 'text'" :rules="[val => !!val || 'Field is required']">
          <template v-slot:append>
            <q-icon
              :name="isPwd ? 'visibility_off' : 'visibility'"
              class="cursor-pointer"
              @click="isPwd = !isPwd"
            />
          </template>
        </q-input>
          <div align="center">
            <q-btn flat label="Вход" type="submit" color="primary"/>
          </div>
        </q-form>
      </q-card-section>
      <q-card-section v-if="alert.message" class="q-pt-none">
        <div align="center" class="text-negative">{{alert.message}}</div>
      </q-card-section>
    </q-card>
  </q-dialog>
</template>

<script>
export default {
  name: 'Login',
  created () {
    this.$store.dispatch('authentication/logout')
  },
  data () {
    return {
      username: '',
      password: '',
      isPwd: true,
      prompt: true
    }
  },
  computed: {
    alert () {
      return this.$store.state.alert
    }
  },
  methods: {
    async onSubmit () {
      this.submitted = true
      const { username, password } = this
      if (username && password) {
        await this.$store.dispatch('authentication/login', { username, password })
      }
    }
  }
}
</script>
