<script setup lang="ts">
import type {UserDto} from "@/models/user-dto";

import {useRoute, useRouter} from "vue-router";
import {useFetch} from "@vueuse/core";
import {onMounted, ref} from "vue";

const route = useRoute();
const router = useRouter();

const form = ref<UpdateUser>({});

const getUser = async () => {
  const {data} = await useFetch(`https://localhost:5001/api/v1/users/${route.params.userId}`).get().json<GetUser>();
  form.value.name = data.value?.user.name
}

const formSubmit = async () => {
  await useFetch(`https://localhost:5001/api/v1/users/${route.params.userId}`).put(form)
  goToList();
}

const goToList = () => {
  router.push({name: 'user-list'})
}

onMounted(async () => {
  await getUser();
})

interface GetUser {
  user: UserDto;
}

interface UpdateUser {
  name?: string;
}
</script>

<template>
  <form @submit.prevent="formSubmit">
    <div class="form-field">
      <label for="name">Name</label>
      <input v-model="form.name" type="text">
    </div>
    <div class="mb-1"></div>
    <div class="button-row">
      <button type="submit">Update</button>
      <button type="button" @click="goToList">Back</button>
    </div>
  </form>
</template>

<style scoped>
.mb-1 {
  margin-bottom: 1rem;
}

div.form-field > label {
  margin-right: 5px
}

.button-row > button:last-child {
  margin-left: 5px;
}
</style>
