<template>
    <div>
      <h1>Create Person</h1>
      <form @submit.prevent="createPerson">
        <label for="name">Name:</label>
        <input type="text" v-model="form.name" id="name" />
  
        <label for="age">Age:</label>
        <input type="number" v-model="form.age" id="age" />
  
        <button type="submit">Create</button>
      </form>
    </div>
  </template>
  
  <script setup>
  import { ref } from 'vue';
  import { useRouter } from 'vue-router';
  const { $apiFetch } = useNuxtApp();
  
  // Form data state
  const form = ref({
    name: '',
    age: null,
  });
  
  const router = useRouter();
  
  // Create a new person
  const createPerson = async () => {
    await $apiFetch('/Person', {
      method: 'POST',
      body: form.value,
    });
    router.push('/persons'); // Redirect to persons list after creation
  };
  </script>
   
  