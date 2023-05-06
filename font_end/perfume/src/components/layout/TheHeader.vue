<template>
  <div class="header-area">
    <div class="container">
      <div class="row">
        <div class="col-md-8">
          <div class="user-menu">
            <ul>
              <li  v-if ="isShowRegister"><router-link to="/account">
                <i class="fas fa-user"></i> Tài Khoản
              </router-link></li>
              <li v-if ="isShowRegister"><router-link to="/register">
                  <i class="fas fa-user-cog"></i> Đăng kí
                </router-link>
              </li>
              <li v-if ="isShowRegister"> <router-link to="/login">
                  <i class="fas fa-sign-in-alt"></i> Đăng nhập
                </router-link>
              </li>
              <li @click="onLogout" v-if ="isShowRegister" style="cursor: pointer; color: rgb(138, 141, 143);">
                  <i class="fas fa-sign-in-alt"></i> Đăng xuất
              </li> 
            </ul>
          </div>
        </div>

        <div class="col-md-4">
          <div class="header-right">
            <ul class="list-unstyled list-inline">
              <li class="dropdown dropdown-small">
                <a data-toggle="dropdown" data-hover="dropdown" class="dropdown-toggle" href="#"><span
                    class="key">Tiền tệ :</span><span class="value">USD </span><b class="caret"></b></a>
                <ul class="dropdown-menu">
                  <li><a href="#">USD</a></li>
                  <li><a href="#">INR</a></li>
                  <li><a href="#">GBP</a></li>
                </ul>
              </li>

              <li class="dropdown dropdown-small">
                <a data-toggle="dropdown" data-hover="dropdown" class="dropdown-toggle" href="#"><span
                    class="key">Ngôn ngữ :</span><span class="value">English </span><b class="caret"></b></a>
                <ul class="dropdown-menu">
                  <li><a href="#">English</a></li>
                  <li><a href="#">French</a></li>
                  <li><a href="#">German</a></li>
                </ul>
              </li>
            </ul>
          </div>
        </div>
      </div>
    </div>
  </div> <!-- End header area -->
  <div class="site-branding-area">
    <div class="container">
      <div class="row">
        <div class="col-sm-4 col-6">
          <div class="logo">
              <router-link to="/">
                <img src="../../assets/img/logo1.png" width="100">
              </router-link>
          </div>
        </div>
        <div class="header-top-between col-sm-4">
        <input class="header-top-search" placeholder="Tìm kiếm sản phẩm..." v-model="textSearch" @keyup.enter="onSearch">
        <div class="icon-search"></div>
        <i class="fa-solid fa-magnifying-glass"></i>
      </div>
        <div class="col-sm-4 col-6">
          <div class="shopping-item">
            <router-link to="/cart">Giỏ hàng - <span class="cart-amunt">{{ TotalPirceCart }} vnđ</span> <i class="fas fa-shopping-cart"></i> <span
                class="product-count">{{ CartQuantity }}</span></router-link>
          </div>
        </div>
      </div>
    </div>
  </div> <!-- End site branding area -->

  <div class="mainmenu-area">
    <div class="container">
      <div class="row">
        <div class="navbar-header">
          <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
            <span class="sr-only">Toggle navigation</span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
          </button>
        </div>
        <div class="navbar-collapse collapse">
          <ul class="nav navbar-nav">
            <li><router-link class="navbar-nav-link" to="/">Trang chủ</router-link></li>
            <li><router-link class="navbar-nav-link" to="/man">Nước hoa Nam</router-link></li>
            <li><router-link class="navbar-nav-link" to="/women">Nước hoa nữ</router-link></li>
            <li><router-link class="navbar-nav-link" to="/unisex">Nước hoa unisex</router-link></li>
            <li><router-link class="navbar-nav-link" to="/cart">Giỏ hàng</router-link></li>
            <li><router-link class="navbar-nav-link" to="/news">Tin tức</router-link></li>
            <li><router-link class="navbar-nav-link" to="/contact">Liên hệ</router-link></li>
          </ul>
        </div>
      </div>
    </div>
  </div> <!-- End mainmenu area -->
</template>
<script>
import "https://code.jquery.com/jquery.min.js";
import "http://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js";
import "../../js/jquery.sticky.js";
import "../../js/main.js"
export default {
  computed: {
    CartQuantity() {
      let  cartItems =  JSON.parse(sessionStorage.getItem('cartItems')) || [];
      return cartItems.length;
    },
    TotalPirceCart() {
      let totalPrice = 0;
      let  cartItems =  JSON.parse(sessionStorage.getItem('cartItems')) || [];
      cartItems.forEach(item => {
        totalPrice += item.Price;
      });
      return totalPrice;
    }
  },
  data() {
    return {
      cartItems: JSON.parse(sessionStorage.getItem('cartItems')) || [],
      textSearch:'',
      isShowLogout: false,
      isShowRegister:true
    }
  },
  methods: {
    onSearch() {
      
    },
    onLogout() {

      // Lấy danh sách sản phẩm từ sessionStorage (nếu đã có)
      let account = JSON.parse(sessionStorage.getItem('account')) || [];
      // Thêm sản phẩm vào giỏ hàng
      if(account.length) {
        sessionStorage.removeItem('account');
      }
      let cartItems = JSON.parse(sessionStorage.getItem('cartItems')) || [];
      if(cartItems.length) {
        sessionStorage.removeItem('cartItems');
      }
      this.showRegister();
      this.showLogout();
      this.$router.push('/login');
      
    },
    showRegister() {
      let account = JSON.parse(sessionStorage.getItem('account')) || [];
      if(!account.length) {
        this.isShowRegister = true;
      }
      else {
        this.isShowRegister = false;
      }
    },
    showLogout() {
      let account = JSON.parse(sessionStorage.getItem('account')) || [];
      if(account.length) {
        this.isShowLogout = true
      }
      else {
        this.isShowLogout = false
      }
  },
  
  
}}
</script>
<style >@import "../../assets/font/fontawesome-5.15.1/css/all.min.css";</style>