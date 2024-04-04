<script setup lang="ts">
import router from '@/router'
import { type Batch } from '@/types/batch'
import { type Transaction } from '@/types/transaction'
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

function addEntry(transaction: Transaction) {
  transaction.entries.push({
    amount: 0,
    accountId: 1
  })
}

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
      <input
        type="date"
        class="p-2 rounded-md border-2 border-black"
        v-for="transaction in batch.transactions"
        :key="transaction.id"
        v-model="transaction.date"
      />
      <template v-for="transaction in batch.transactions" :key="transaction.id">
        <input
          type="number"
          class="p-2 rounded-md border-2 border-black"
          v-for="entry in transaction.entries"
          :key="entry"
          v-model="entry.amount"
        />
        <PrimaryButton type="button" @click="addEntry(transaction)" innerText="Add Transaction" />
      </template>
      <PrimaryButton innerText="Submit" />
    </form>
    {{ batch }}
  </div>
</template>
