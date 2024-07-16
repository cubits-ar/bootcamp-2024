<script setup lang="ts">
import type { UserDto } from '@/models/user-dto'

import { useFetch } from '@vueuse/core'
import { useRouter } from 'vue-router'
import { onMounted, ref } from 'vue'

const router = useRouter()

const userList = ref<UserDto[]>([])

const getUserList = async () => {
  const { data } = await useFetch('https://localhost:5001/api/v1/users')
    .get()
    .json<GetUserListResponse>()
  userList.value = data.value != null ? data.value.userList : []
}

const goToCreate = () => {
  router.push({ name: 'user-create' })
}

const goToUpdate = (userId: number) => {
  router.push({ name: 'user-update', params: { userId: userId } })
}

const goToDelete = (userId: number) => {
  router.push({ name: 'user-delete', params: { userId: userId } })
}

onMounted(async () => {
  await getUserList()
})

interface GetUserListResponse {
  userList: UserDto[]
}
</script>

<template>
  <div class="mb-1">
    <button @click="goToCreate">Create</button>
  </div>
  <table v-if="userList.length > 0">
    <tr>
      <th>#</th>
      <th>Name</th>
      <th></th>
    </tr>
    <tr v-for="user in userList" :key="user.id">
      <td>{{ user.id }}</td>
      <td>{{ user.name }}</td>
      <td>
        <button @click="goToUpdate(user.id)">Update</button>
        <button @click="goToDelete(user.id)">Delete</button>
      </td>
    </tr>
  </table>
</template>

<style scoped>
.mb-1 {
  margin-bottom: 1rem;
}

table {
  font-family: arial, sans-serif;
  border-collapse: collapse;
  width: 100%;
}

td,
th {
  border: 1px solid #dddddd;
  text-align: left;
  padding: 8px;
}

td > button:last-child {
  margin-left: 5px;
}
</style>
