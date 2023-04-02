<template>
  <div class="header ">
    <div class="header-top container">
      <router-link to="/" class="header-top-left">
        <img class="header-top-left-img" src="../../assets/img/logo1.png" alt="">
      </router-link >
      <div class="header-top-between">
        <input class="header-top-search" placeholder="Tìm kiếm sản phẩm...">
        <div class="icon-search"></div>
        <i class="fa-solid fa-magnifying-glass"></i>
      </div>
      <div class="header-top-right">
        <div class="header-top-right-first">
          <div class="header-top-right-first-right">
            <i class="fas fa-phone fs-20 "></i>
          </div>
          <div class="header-top-right-first-left">
            <div class="header-top-right-first-left-text">
              Hotline tư vấn
              <br>
              <span style="color:var(--primary-color)"><strong>0333168440</strong> </span>
            </div>
            <div class="header-top-right-first-left-content">

            </div>
          </div>
        </div>
        <div class="header-top-right-first">
          <router-link to="/cart" class="header-top-right-first-right">
            <i class="fas fa-shopping-basket fs-20 "></i>
          </router-link>
          <div class="header-top-right-first-left">
            <div class="header-top-right-first-left-text">
              Giỏ hàng
            </div>
            <div class="header-top-right-first-left-content">
              Có <span style="color:var(--primary-color)"><strong>0</strong></span> Sản phẩm
            </div>
          </div>
        </div>
      </div>
    </div>
    <HeaderMenu></HeaderMenu>
   
  </div>
</template> 
<script>
import HeaderMenu from '../base/HeaderMenu.vue';
export default {
components: {
  HeaderMenu,
},
name:"TheHeader",
}
</script>
<style scoped>
@import "../../assets/font/fontawesome-5.15.1/css/all.min.css";
</style>