<script setup lang="ts">
import router from '@/router'
import { type Account } from '@/types/account'
import axios from 'axios'
import { onMounted, ref, type Ref } from 'vue'
import { useRoute } from 'vue-router'
import PrimaryButton from '@/components/utilities/PrimaryButton.vue'

const route = useRoute()

const account: Ref<Account | undefined> = ref()

onMounted(() => {
  axios.get(`/api/accounts/${route.params.id}`).then((resp) => {
    if (resp.status === 200) {
      account.value = resp.data
    }
  })
})

function updateAccount() {
  if (account.value) {
    axios.put(`/api/accounts/${account.value.id}`, account.value).then((resp) => {
      if (resp.status === 204) {
        router.push('/accounts')
      }
    })
  }
}
</script>

<template>
  <div class="container mx-auto">
    <form v-if="account" @submit.prevent="updateAccount()">
      <input type="text" class="p-2 rounded-md border-2 border-black" v-model="account.number" />
      <input type="text" class="p-2 rounded-md border-2 border-black" v-model="account.name" />
      <PrimaryButton innerText="Submit" />
    </form>
    {{ account }}
  </div>
</template>
