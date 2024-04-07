<script setup lang="ts">
import router from '@/router'
import { type Account } from '@/types/account'
import { type Batch } from '@/types/batch'
import { type Company } from '@/types/company'
import { type Transaction } from '@/types/transaction'
import type { Entry, NewEntry } from '@/types/entry'
import axios from 'axios'
import { computed, nextTick, onMounted, ref, type Ref } from 'vue'
import { useRoute } from 'vue-router'
import PrimaryButton from '@/components/utilities/PrimaryButton.vue'

const route = useRoute()

const batch: Ref<Batch | undefined> = ref()
const accounts: Ref<Account[]> = ref(new Array<Account>())
const companies: Ref<Company[]> = ref(new Array<Company>())

onMounted(() => {
  axios.get(`/api/batches/${route.params.id}`).then((resp) => {
    if (resp.status === 200) {
      batch.value = resp.data
    }
  })
  axios.get('/api/accounts').then((resp) => {
    if (resp.status === 200) {
      accounts.value = resp.data
    }
  })
  axios.get('/api/companies').then((resp) => {
    if (resp.status === 200) {
      companies.value = resp.data
    }
  })
})

function entryTransaction(entry: Entry | NewEntry): Transaction {
  let entryTransaction: Transaction = {
    id: 100,
    date: new Date(),
    companyId: 1,
    entries: []
  }

  if (batch.value) {
    const foundTransaction = batch.value.transactions.find((transaction) => {
      return transaction.entries.includes(entry)
    })

    if (foundTransaction) {
      entryTransaction = foundTransaction
    }
  }

  return entryTransaction
}

async function newEntry() {
  if (batch.value) {
    batch.value.transactions[batch.value.transactions.length - 1].entries.push({
      amount: 0,
      accountId: 1
    })

    await nextTick()

    document.getElementById(`entry-${formattedEntries.value.length - 1}-account`)?.focus()
  }
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

const formattedEntries = computed(() => {
  if (batch.value === undefined) {
    return []
  } else {
    return batch.value.transactions
      .map((transaction) => {
        return transaction.entries
      })
      .flat()
  }
})
</script>

<template>
  <div class="container mx-auto">
    <form v-if="batch" @submit.prevent="updateBatch()">
      <input type="text" class="p-2 rounded-md border-2 border-black" v-model="batch.name" />

      <div
        v-for="(entry, idx) in formattedEntries"
        :key="entry.id ? entry.id : new Date().getTime()"
        class="flex"
      >
        <select
          :id="`entry-${idx}-account`"
          class="p-2 rounded-md border-2 border-black"
          v-model="entry.accountId"
        >
          <option v-for="account in accounts" :key="account.id" :value="account.id">
            {{ account.number }} {{ account.name }}
          </option>
        </select>
        <select
          class="p-2 rounded-md border-2 border-black"
          v-model="entryTransaction(entry).companyId"
        >
          <option v-for="company in companies" :key="company.id" :value="company.id">
            {{ company.name }}
          </option>
        </select>
        <input type="number" class="p-2 rounded-md border-2 border-black" v-model="entry.amount" />
        <input
          type="date"
          class="p-2 rounded-md border-2 border-black"
          v-model="entryTransaction(entry).date"
          @keyup.tab="newEntry()"
        />
      </div>
      <PrimaryButton innerText="Submit" />
    </form>
    {{ batch }}
  </div>
</template>
