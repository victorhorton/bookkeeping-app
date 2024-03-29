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
    <div v-for="batch in batches" :key="batch.id">{{ batch }}</div>
  </div>
</template>
