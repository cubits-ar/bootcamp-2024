<script setup lang="ts">
import { useFetch } from '@vueuse/core'
import { useRouter } from 'vue-router'
import { ref } from 'vue'

const router = useRouter()

const form = ref<CreateUser>({})

const formSubmit = async () => {
  await useFetch('https://localhost:5001/api/v1/users').post(form)
  goToList()
}

const goToList = () => {
  router.push({ name: 'user-list' })
}

interface CreateUser {
  name?: string
}
</script>

<template>
  <form @submit.prevent="formSubmit">
    <div class="form-field">
      <label for="name">Name</label>
      <input v-model="form.name" type="text" />
    </div>
    <div class="mb-1"></div>
    <div class="button-row">
      <button type="submit">Create</button>
      <button type="button" @click="goToList">Back</button>
    </div>
  </form>
</template>

<style scoped>
.mb-1 {
  margin-bottom: 1rem;
}

div.form-field > label {
  margin-right: 5px;
}

.button-row > button:last-child {
  margin-left: 5px;
}
</style>
