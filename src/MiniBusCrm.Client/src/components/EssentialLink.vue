<template>
  <q-item v-if="!expansionItem" clickable :to="linkTo">
    <q-item-section v-if="icon" avatar>
      <q-icon :name="icon" />
    </q-item-section>

    <q-item-section>
      <q-item-label>{{ title }}</q-item-label>
    </q-item-section>
  </q-item>

  <q-expansion-item v-else-if="expansionItem" :label="title" :icon="icon">
    <q-item :inset-level="1" dense v-for="(value, key, index) in children" clickable :key="index" :to="value.linkTo">
      <q-item-section>
        <q-item-label style="font-size: 14px">{{ value.title }}</q-item-label>
      </q-item-section>
    </q-item>
  </q-expansion-item>
</template>

<script>
export default {
  name: 'EssentialLink',
  props: {
    title: {
      type: String
    },
    linkTo: {
      type: String,
      default: '#'
    },
    icon: {
      type: String,
      default: ''
    },
    expansionItem: {
      type: Boolean,
      default: false
    },
    children: {
      type: Object,
      default: () => { return {} }
    }
  }
}
</script>
