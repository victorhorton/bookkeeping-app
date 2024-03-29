<script setup lang="ts">
import { onMounted, ref } from 'vue'
import axios from 'axios'

const batches = ref([])

onMounted(() => {
  axios('/api/Batches').then((resp) => {
    batches.value = resp.data
  })
})
</script>

<template>
  <div>{{ batches }}</div>
</template>
