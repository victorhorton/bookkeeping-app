<script setup lang="ts">
import { onMounted, ref, type Ref } from 'vue'
import axios from 'axios'
import PrimaryButton from '@/components/utilities/PrimaryButton.vue'
import type { Account } from '@/types/account'

const accounts: Ref<Account[]> = ref([])

onMounted(() => {
  axios('/api/Accounts').then((resp) => {
    accounts.value = resp.data
  })
})

function deleteAccount(id: Account['id']) {
  axios.delete(`/api/accounts/${id}`).then((resp) => {
    if (resp.status === 204) {
      const idx = accounts.value.findIndex((account: Account) => account.id === id)
      accounts.value.splice(idx, 1)
    }
  })
}
</script>

<template>
  <div class="container mx-auto">
    <div class="flex justify-end">
      <RouterLink
        to="/accounts/new"
        class="bg-neutral-800 p-2 text-neutral-200 active:text-neutral-300 rounded-md"
        >New Account</RouterLink
      >
    </div>
    <div v-for="account in accounts" :key="account.id" class="flex my-2">
      <div class="flex-1">{{ account.number }}</div>
      <div class="flex-1">{{ account.name }}</div>
      <div class="flex-auto">
        <RouterLink
          :to="`/accounts/edit/${account.id}`"
          class="bg-neutral-800 p-2 text-neutral-200 active:text-neutral-300 rounded-md"
          >Edit</RouterLink
        >
      </div>
      <div class="flex-auto">
        <PrimaryButton @click="deleteAccount(account.id)" inner-text="Delete" />
      </div>
    </div>
  </div>
</template>
