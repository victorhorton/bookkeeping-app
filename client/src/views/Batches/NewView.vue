<script setup lang="ts">
import router from '@/router'
import { type NewBatch } from '@/types/batch'
import axios from 'axios'
import { ref, type Ref } from 'vue'

const batch: Ref<NewBatch> = ref({
  name: '',
  status: 0
})

function createNewBatch() {
  axios.post('/api/batches', batch.value).then((resp) => {
    if (resp.status === 200) {
      router.push('/batches')
    }
  })
}
</script>

<template>
  <div class="container mx-auto">
    <form @submit.prevent="createNewBatch()">
      <input type="text" class="p-2 rounded-md border-2 border-black" v-model="batch.name" />
      <PrimaryButton innerText="Submit" />
    </form>
    {{ batch }}
  </div>
</template>
