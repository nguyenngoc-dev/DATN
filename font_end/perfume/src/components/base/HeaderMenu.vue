<template>
<div class="header-menu container">
    <div class="header-menu-left">
        <router-link to="/" class="header-menu-left-item">
            <i class="fas fa-home fs-16"></i>
        </router-link>
        <router-link to="/man" class="header-menu-left-item">
            Nước hoa nam
        </router-link>
        <router-link to="/women" class="header-menu-left-item">
            Nước hoa nữ
        </router-link>
        <router-link to="/unisex" class="header-menu-left-item">
            Nước hoa unisex
        </router-link>
        <router-link to="/news" class="header-menu-left-item">
            Tin tức
        </router-link>
        <router-link to="/contact" class="header-menu-left-item">
           Liên hệ
        </router-link>
    </div>
    <div class="header-menu-right">
        <router-link  to="/register" class="header-menu-right-signin">
            <i class="fas fa-user-cog"></i>
            <span> Đăng kí</span>
        </router-link>
        <router-link  to="/login" class="header-menu-right-login">
            <i class="fas fa-sign-in-alt"></i>
            <span> Đăng nhập</span>
        </router-link>
    </div>
</div>

</template>
<script>
export default {

}
</script>
<style>
@import "../../assets/font/fontawesome-5.15.1/css/all.min.css";
</style>