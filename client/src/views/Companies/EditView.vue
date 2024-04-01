<script setup lang="ts">
import router from '@/router'
import { type Company } from '@/types/company'
import axios from 'axios'
import { onMounted, ref, type Ref } from 'vue'
import { useRoute } from 'vue-router'
import PrimaryButton from '@/components/utilities/PrimaryButton.vue'

const route = useRoute()

const company: Ref<Company | undefined> = ref()

onMounted(() => {
  axios.get(`/api/companies/${route.params.id}`).then((resp) => {
    if (resp.status === 200) {
      company.value = resp.data
    }
  })
})

function updateCompany() {
  if (company.value) {
    axios.put(`/api/companies/${company.value.id}`, company.value).then((resp) => {
      if (resp.status === 204) {
        router.push('/companies')
      }
    })
  }
}
</script>

<template>
  <div class="container mx-auto">
    <form v-if="company" @submit.prevent="updateCompany()">
      <input type="text" class="p-2 rounded-md border-2 border-black" v-model="company.name" />
      <input type="text" class="p-2 rounded-md border-2 border-black" v-model="company.code" />
      <PrimaryButton innerText="Submit" />
    </form>
    {{ company }}
  </div>
</template>
