<template>
    <div class="wrapper fadeInDown">
  <div id="formContent">
    <!-- Tabs Titles -->
    <h2 class="active"> Đăng nhập </h2>
   <!-- // <h2 class="inactive underlineHover">Sign Up </h2> -->

    <!-- Icon -->
    <!-- <div class="fadeIn first">
      <img src="http://danielzawadzki.com/codepen/01/icon.svg" id="icon" alt="User Icon" />
    </div> -->

    <!-- Login Form -->
    <div>
      <input type="text" v-model="username" id="login" class="fadeIn second" name="login" placeholder="UserName">
      <input type="password" v-model="password" id="password"  class="fadeIn third" name="login" placeholder="Password">
      <input type="submit" @click="onLogin()" class="fadeIn fourth" value="Đăng nhập">
    </div>

    <!-- Remind Passowrd -->
    <div id="formFooter">
      <a class="underlineHover" href="#">Quên mật khẩu?</a>
    </div>

  </div>
</div>
<BaseToast v-if="isShowToast" 
        @closeToast="onhideToast" 
        @onhideToast="onhideToast" 
        :toastType="toastContent"
        :toastTitle="toastTitle" 
        :isSuccessToast="isSuccessToast" 
        :isErrorToast="isErrorToast" />
</template>
<script>
 import {HTTPUsers} from "../js/api.js";
export default {
  data() {
    return {
      userlist:[],
      username: "",
      password:"",
      isShowToast:false,
      toastContent: "AUTHEN", // nội dung toast message
      toastTitle: "", // Tiêu đề toast,
      isErrorToast: false, // Icon toast lỗi
      isSuccessToast: true, // icon toast thành công
    }
  },
  async created() {
   await this.getUserInfor();
  },
  methods: {
    async getUserInfor() {
      let res = await HTTPUsers.get();
      this.userlist = res.data;
    },

    onLogin() {
      let success = false;
      this.userlist.forEach(item => {
        if(this.username == item.UserName && this.password == item.Password){
          success = true;
          this.toastContent =  "AUTHEN"
          this.isErrorToast = false;
            this.isShowToast = true;
              // Lấy danh sách sản phẩm từ sessionStorage (nếu đã có)
              let account = JSON.parse(sessionStorage.getItem('account')) || [];
              // Thêm sản phẩm vào giỏ hàng
              account.push(item.UserId);
              // Lưu lại danh sách sản phẩm vào sessionStorage
              sessionStorage.setItem('account', JSON.stringify(account));
            if(item.Role == "Admin") {
              setTimeout(() => {
                window.open("http://localhost:8080/");
              }, 1500);
            
            return;
            }
            else {
              setTimeout(() => {
                this.$router.push('/' + this.username);
              }, 1500);
            }
          return;
        }
       
      }); 
      if(!success) {
        this.toastContent ="ERROR"
        this.isErrorToast = true;
        this.isShowToast = true;
      }
      
    },
    /**
     * author:Nguyễn Văn Ngọc(3/1/2023)
     * Hàm onshowToast  hiện Toast thông báo
     */
      onshowToast() {
        this.isShowToast = true;
    },
    /**
     * author:Nguyễn Văn Ngọc(3/1/2023)
     * Hàm onhideToast ẩn  Toast thông báo
     */
    onhideToast() {
        this.isShowToast = false;
    },
  }
}
</script>
<style scoped>
@import "../css/components/login.css";
</style>