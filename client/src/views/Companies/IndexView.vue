<script setup lang="ts">
import { onMounted, ref, type Ref } from 'vue'
import axios from 'axios'
import PrimaryButton from '@/components/utilities/PrimaryButton.vue'
import type { Company } from '@/types/company'

const companies: Ref<Company[]> = ref([])

onMounted(() => {
  axios('/api/Companies').then((resp) => {
    companies.value = resp.data
  })
})

function deleteCompany(id: Company['id']) {
  axios.delete(`/api/companies/${id}`).then((resp) => {
    if (resp.status === 204) {
      const idx = companies.value.findIndex((company: Company) => company.id === id)
      companies.value.splice(idx, 1)
    }
  })
}
</script>

<template>
  <div class="container mx-auto">
    <div class="flex justify-end">
      <RouterLink
        to="/companies/new"
        class="bg-neutral-800 p-2 text-neutral-200 active:text-neutral-300 px-2 my-2 rounded-md"
        >New Company</RouterLink
      >
    </div>
    <div v-for="company in companies" :key="company.id" class="flex my-2">
      <div class="flex-1">{{ company.name }}</div>
      <div class="flex-1">{{ company.code }}</div>
      <div class="flex-auto">
        <PrimaryButton @click="deleteCompany(company.id)" inner-text="Delete Company" />
      </div>
    </div>
  </div>
</template>
