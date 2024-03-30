<template>
  <button
    class="bg-neutral-800 active:bg-neutral-900 p-2 text-neutral-200 active:text-neutral-300 px-2 my-2 rounded-md"
  >
    {{ innerText }}
  </button>
</template>

<script setup lang="ts">
defineProps({
  innerText: String
})
</script>
