<script setup lang="ts">
import router from '@/router'
import { type NewCompany } from '@/types/company'
import axios from 'axios'
import { ref, type Ref } from 'vue'
import PrimaryButton from '@/components/utilities/PrimaryButton.vue'

const company: Ref<NewCompany> = ref({
  name: '',
  code: ''
})

function createNewCompany() {
  axios.post('/api/companies', company.value).then((resp) => {
    if (resp.status === 200) {
      router.push('/companies')
    }
  })
}
</script>

<template>
  <div class="container mx-auto">
    <form @submit.prevent="createNewCompany()">
      <input type="text" class="p-2 rounded-md border-2 border-black" v-model="company.name" />
      <input type="text" class="p-2 rounded-md border-2 border-black" v-model="company.code" />
      <PrimaryButton innerText="Submit" />
    </form>
    {{ company }}
  </div>
</template>
