<template>
    <div>
      <h1>Edit Person</h1>
      <form @submit.prevent="updatePerson">
        <label for="name">Name:</label>
        <input type="text" v-model="form.name" id="name" />
  
        <label for="age">Age:</label>
        <input type="number" v-model="form.age" id="age" />
  
        <button type="submit">Update</button>
      </form>
    </div>
  </template>
  
  <script setup>
  import { ref, onMounted } from 'vue';
  import { useRoute, useRouter } from 'vue-router';
  
  const { $apiFetch } = useNuxtApp();
  const route = useRoute();
  const router = useRouter();
  
  // Form data state
  const form = ref({
    name: '',
    age: null,
  });
  
  // Fetch the person's details using useFetch
  const fetchPerson = async () => {
    const data  = await $apiFetch(`/Person/${route.params.id}`);
    form.value = data;
  };
  
  // Update the person data
  const updatePerson = async () => {
    await $apiFetch(`/Person/${route.params.id}`, {
      method: 'PUT',
      body: form.value,
    });
    router.push(`/persons/${route.params.id}`); // Redirect back to the person detail page after update
  };
  
  onMounted(() => {
    fetchPerson();
  });
  </script>
  