export default defineNuxtPlugin(() => {
  const config = useRuntimeConfig();
  
  const apiFetch = $fetch.create({    
    baseURL: config.public.baseURL,
    onRequest({ options }) {
      options.credentials = 'include';
    },
    onRequestError() {
      // Handle the request errors
    },
    onResponse({ response }) {
      return response._data;
    },
    onResponseError({ response }) {
      if (response.status === 401) {
        console.error('error');
      }
    }
  });
  return {
    provide: {
      apiFetch
    }
  };
});
