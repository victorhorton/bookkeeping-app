<script setup lang="ts">
import { RouterView } from 'vue-router'
import NavBar from '@/components/utilities/NavBar.vue'
</script>

<template>
  <div>
    <NavBar />
    <RouterView />
  </div>
</template>
