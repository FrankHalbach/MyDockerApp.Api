<template>
  <div>
    <h1>Persons List</h1>
    <div>
      <nuxt-link to="/persons/create">Create New Person</nuxt-link>
    </div>
    <ul>
      <li v-for="person in persons" :key="person.id">
        <nuxt-link :to="`/persons/${person.id}`">{{ person.name }}</nuxt-link>
        <nuxt-link :to="`/persons/${person.id}/edit`">Edit</nuxt-link>
        <button @click="deletePerson(person.id)">Delete</button>
      </li>
    </ul>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue';

// Persons data state
const persons = ref([]);
const { $apiFetch } = useNuxtApp();
// Fetch persons using useFetch
const fetchPersons = async () => {
  const person  = await $apiFetch('/Person');  
  persons.value = person;  
};

onMounted(() => {
  fetchPersons();
  console.log(persons.value);
});

// Delete person
const deletePerson = async (id) => {
  const confirmDelete = confirm('Are you sure you want to delete this person?');
  if (confirmDelete) {
    await $apiFetch(`/Person/${id}`, {
      method: 'DELETE',
    });
    fetchPersons();  // Refresh the list
  }
};
</script>
