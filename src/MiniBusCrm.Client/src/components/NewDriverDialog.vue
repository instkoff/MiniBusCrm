<template>
  <q-dialog :value="value" @input="handleInput">
    <q-card>
      <q-card-section>
        <div class="text-h6">Добавить водителя</div>
      </q-card-section>

      <q-separator/>

      <q-card-section style="min-width: 70vh" class="scroll">

        <form name="BusDriver" @submit.prevent.stop="submitForm"  @reset.prevent.stop="resetForm">
          <q-input
            name="name"
            ref="name"
            filled
            v-model="driver.name"
            label="Имя *"
            hint="Имя"
            lazy-rules
            :rules="[ val => val && val.length > 0 || 'Пожалуйста введите что то']"
          />

          <q-input
            name="surname"
            ref="surname"
            filled
            v-model="driver.surname"
            label="Фамилия *"
            hint="Фамилия"
            lazy-rules
            :rules="[ val => val && val.length > 0 || 'Пожалуйста введите что то']"
          />

          <q-input
            name="patronymic"
            ref="patronymic"
            filled
            v-model="driver.patronymic"
            label="Отчество *"
            hint="Отчество"
            lazy-rules
            :rules="[ val => val && val.length > 0 || 'Пожалуйста введите что то']"
          />

          <q-input
            name="documentSerialNumber"
            ref="documentSerialNumber"
            v-model="driver.documentSerialNumber"
            label="Серия документа *"
            hint="Серия документа"
            filled
            lazy-rules
            :rules="[ val => val && val.length > 0 || 'Пожалуйста введите что то']"
          />
          <q-input
            name="documentNumber"
            ref="documentNumber"
            v-model="driver.documentNumber"
            label="Номер документа *"
            hint="Номер документа"
            filled
            lazy-rules
            :rules="[ val => val && val.length > 0 || 'Пожалуйста введите что то']"
          />
          <q-input
            name="phoneNumber"
            ref="phoneNumber"
            v-model="driver.phoneNumber"
            label="Номер телефона *"
            hint="Номер телефона"
            filled
            lazy-rules
            :rules="[ val => val && val.length > 0 || 'Пожалуйста введите что то']"
          />
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
import { BusDriver } from 'src/common/models'
import { busDriversService } from 'src/services/bus-drivers'

export default {
  name: 'NewDriverDialog',
  props: {
    value: {
      type: Boolean,
      default: false
    }
  },
  data () {
    return {
      driver: new BusDriver()
    }
  },
  methods: {
    handleInput (value) {
      this.$emit('input', value)
    },
    async submitForm () {
      this.$refs.name.validate()
      this.$refs.surname.validate()
      this.$refs.patronymic.validate()
      this.$refs.documentSerialNumber.validate()
      this.$refs.documentNumber.validate()
      this.$refs.phoneNumber.validate()
      const hasError = this.$refs.name.hasError || this.$refs.surname.hasError || this.$refs.patronymic.hasError || this.$refs.documentSerialNumber.hasError || this.$refs.documentNumber.hasError || this.$refs.phoneNumber.hasError
      if (hasError) {
        console.log(hasError)
        this.formHasError = true
      } else {
        const result = await busDriversService.create(this.driver)
        if (result.error) {
          await this.$store.dispatch('alert/error', result.error)
          return
        }
        this.$emit('refresh')
        this.handleInput(false)
        this.user = new BusDriver()
      }
    },
    resetForm () {
      this.$refs.name.resetValidation()
      this.$refs.surname.resetValidation()
      this.$refs.patronymic.resetValidation()
      this.$refs.documentSerialNumber.resetValidation()
      this.$refs.documentNumber.resetValidation()
      this.$refs.phoneNumber.resetValidation()
      this.user = new BusDriver()
    }
  }
}
</script>
