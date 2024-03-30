<script setup lang="ts">
import { onMounted, ref, type Ref } from 'vue'
import axios from 'axios'
import PrimaryButton from '@/components/utilities/PrimaryButton.vue'
import type { Batch } from '@/types/batch'

const batches: Ref<any> = ref([])

onMounted(() => {
  axios('/api/Batches').then((resp) => {
    batches.value = resp.data
  })
})

function postBatch(batch: Batch) {
  batch.status = 1
  axios.put(`/api/batches/${batch.id}`, batch)
}
</script>

<template>
  <div class="container mx-auto">
    <div class="flex justify-end">
      <RouterLink
        to="/batches/new"
        class="bg-neutral-800 p-2 text-neutral-200 active:text-neutral-300 px-2 my-2 rounded-md"
        >New Batch</RouterLink
      >
    </div>
    <div v-for="batch in batches" :key="batch.id" class="flex my-2">
      <div class="flex-1">{{ batch.id }}</div>
      <div class="flex-1">{{ batch.name }}</div>
      <div class="flex-1">{{ batch.status }}</div>
      <div class="flex-auto">
        <PrimaryButton @click="postBatch(batch)" inner-text="Post Batch" />
      </div>
    </div>
  </div>
</template>
