<script setup lang="ts">
import { onMounted, ref, type Ref } from 'vue'
import axios from 'axios'

const batches: Ref<any> = ref([])

onMounted(() => {
  axios('/api/Batches').then((resp) => {
    batches.value = resp.data
  })
})
</script>

<template>
  <div class="container mx-auto">
    <div v-for="batch in batches" :key="batch.id" class="flex">
      <div class="flex-1">{{ batch.id }}</div>
      <div class="flex-1">{{ batch.name }}</div>
      <div class="flex-1">{{ batch.status }}</div>
    </div>
  </div>
</template>
