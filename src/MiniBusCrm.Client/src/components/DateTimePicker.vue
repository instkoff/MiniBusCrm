<template>
  <q-input dense :value="value" @input="handleInput" :placeholder="label">
    <template v-slot:prepend>
      <q-icon name="event" class="cursor-pointer">
        <q-popup-proxy transition-show="scale" transition-hide="scale">
          <q-date dense :value="value" @input="handleInput" mask="YYYY-MM-DD HH:mm:ss">
            <div class="row items-center justify-end">
              <q-btn dense v-close-popup label="Закрыть" color="primary" flat />
            </div>
          </q-date>
        </q-popup-proxy>
      </q-icon>
    </template>
    <template v-slot:append>
      <q-icon name="access_time" class="cursor-pointer">
        <q-popup-proxy transition-show="scale" transition-hide="scale">
          <q-time dense :value="value" @input="handleInput" mask="YYYY-MM-DD HH:mm:ss" format24h>
            <div class="row items-center justify-end">
              <q-btn dense v-close-popup label="Закрыть" color="primary" flat />
            </div>
          </q-time>
        </q-popup-proxy>
      </q-icon>
    </template>
  </q-input>
</template>

<script>
export default {
  name: 'DateTimePicker',
  props: {
    label: {
      type: String,
      required: true
    },
    value: {
      type: String
    }
  },
  data () {
    return {}
  },
  methods: {
    handleInput (value) {
      this.$emit('input', value)
    }
  }
}
</script>
