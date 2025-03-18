<template>
      <NuxtLoadingIndicator />
      <NuxtPage />
</template>

<script setup>
// No setup logic needed here unless you're adding global state or logic
</script>

<style scoped>
/* Simple styles for navigation */
nav {
  background-color: #333;
  color: white;
  padding: 10px;
}

nav ul {
  list-style: none;
  display: flex;
  gap: 15px;
}

nav a {
  color: white;
  text-decoration: none;
}

nav a:hover {
  text-decoration: underline;
}

div {
  padding: 20px;
}
</style>
