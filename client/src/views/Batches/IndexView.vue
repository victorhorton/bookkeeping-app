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

function deleteBatch(id: Batch['id']) {
  axios.delete(`/api/batches/${id}`).then((resp) => {
    if (resp.status === 204) {
      const idx = batches.value.findIndex((batch: Batch) => batch.id === id)
      batches.value.splice(idx, 1)
    }
  })
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
      <div class="flex-auto">
        <PrimaryButton @click="postBatch(batch)" inner-text="Post Batch" />
      </div>
      <div class="flex-1">{{ batch.id }}</div>
      <div class="flex-1">{{ batch.name }}</div>
      <div class="flex-1">{{ batch.status }}</div>
      <div class="flex-auto">
        <PrimaryButton @click="deleteBatch(batch.id)" inner-text="Delete Batch" />
      </div>
    </div>
  </div>
</template>
