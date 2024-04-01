<script setup lang="ts">
import router from '@/router'
import { type NewAccount } from '@/types/account'
import axios from 'axios'
import { ref, type Ref } from 'vue'
import PrimaryButton from '@/components/utilities/PrimaryButton.vue'

const account: Ref<NewAccount> = ref({
  number: '',
  name: ''
})

function createNewAccount() {
  axios.post('/api/accounts', account.value).then((resp) => {
    if (resp.status === 200) {
      router.push('/accounts')
    }
  })
}
</script>

<template>
  <div class="container mx-auto">
    <form @submit.prevent="createNewAccount()">
      <input type="text" class="p-2 rounded-md border-2 border-black" v-model="account.number" />
      <input type="text" class="p-2 rounded-md border-2 border-black" v-model="account.name" />
      <PrimaryButton innerText="Submit" />
    </form>
    {{ account }}
  </div>
</template>
