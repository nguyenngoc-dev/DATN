<template>

    <div>
      <v-btn
        v-for="icon in icons"
        :key="icon"
        :class="{'mx-4':true, icon }"
        :icon="icon"
        variant="text"
      ></v-btn>
    </div>

    <v-divider></v-divider>

    <div>
      {{ new Date().getFullYear() }} — <strong>Vuetify</strong>
    </div>
</template>
<script>
export default {
  data: () => ({
      icons: [
        'fab fa-facebook-f',
        'fab fa-instagram',
        'fab fa-youtube',
        'fab fa-twitter',
      ],
    }),
}
</script>