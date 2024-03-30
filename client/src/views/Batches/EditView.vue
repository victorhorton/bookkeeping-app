<script setup lang="ts">
import router from '@/router'
import { type Batch } from '@/types/batch'
import axios from 'axios'
import { onMounted, ref, type Ref } from 'vue'
import { useRoute } from 'vue-router'
import PrimaryButton from '@/components/utilities/PrimaryButton.vue'

const route = useRoute()

const batch: Ref<Batch | undefined> = ref()

onMounted(() => {
  axios.get(`/api/batches/${route.params.id}`).then((resp) => {
    if (resp.status === 200) {
      batch.value = resp.data
    }
  })
})

function updateBatch() {
  if (batch.value) {
    axios.put(`/api/batches/${batch.value.id}`, batch.value).then((resp) => {
      if (resp.status === 204) {
        router.push('/batches')
      }
    })
  }
}
</script>

<template>
  <div class="container mx-auto">
    <form v-if="batch" @submit.prevent="updateBatch()">
      <input type="text" class="p-2 rounded-md border-2 border-black" v-model="batch.name" />
      <PrimaryButton innerText="Submit" />
    </form>
    {{ batch }}
  </div>
</template>
