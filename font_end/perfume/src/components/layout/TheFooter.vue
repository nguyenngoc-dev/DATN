<template>
  <div class="footer">
     <div class="footer-group-link">
      <v-btn
        v-for="icon in icons"
        :key="icon"
        :class="{'mx-4':true, icon }"
        :icon="icon"
        variant="text"
      ></v-btn>
    </div>

    <v-divider></v-divider>

    <div class="footer-shop-name">
      {{ new Date().getFullYear() }} — <strong>Ngọc Nguyễn Store</strong>
    </div>
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