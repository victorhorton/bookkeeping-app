<script setup lang="ts">
import { RouterLink } from 'vue-router'
</script>

<template>
  <nav class="flex justify-center gap-4 bg-neutral-800 p-2 text-neutral-200">
    <RouterLink to="/" class="active:text-neutral-300 px-1 rounded-md">Home</RouterLink>
    <RouterLink to="/batches" class="active:text-neutral-300 px-1 rounded-md">Batches</RouterLink>
    <RouterLink to="/accounts" class="active:text-neutral-300 px-1 rounded-md">Accounts</RouterLink>
    <RouterLink to="/companies" class="active:text-neutral-300 px-1 rounded-md"
      >Companies</RouterLink
    >
  </nav>
</template>
