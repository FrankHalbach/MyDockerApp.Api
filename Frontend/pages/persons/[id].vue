<template>
    <div>
      <h1>{{ person.name }}</h1>
      <p>Age: {{ person.age }}</p>
      <nuxt-link :to="`/persons/${person.id}/edit`">Edit</nuxt-link>
      <NuxtPage /> <!-- This renders the child route (edit.vue) -->
    </div>
  </template>
  
  <script setup>
  import { ref, onMounted } from 'vue';
  import { useRoute } from 'vue-router';
  const { $apiFetch } = useNuxtApp();
  
  const route = useRoute();
  const person = ref({});
  
  // Fetch person details using useFetch
  const fetchPerson = async () => {
    const data = await $apiFetch(`/Person/${route.params.id}`);
    person.value = data;
  };
  
  onMounted(() => {
    fetchPerson();
  });
  </script>
  