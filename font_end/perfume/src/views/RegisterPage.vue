<template>
    <div class="wrapper fadeInDown">
  <div id="formContent">
    <!-- Tabs Titles -->
    <h2 class="active"> Đăng ký </h2>
   <!-- // <h2 class="inactive underlineHover">Sign Up </h2> -->

    <!-- Icon -->
    <!-- <div class="fadeIn first">
      <img src="http://danielzawadzki.com/codepen/01/icon.svg" id="icon" alt="User Icon" />
    </div> -->

    <!-- Login Form -->
    <div>
        <input required  autocomplete="off" type="text" v-model="username"  id="password" class="fadeIn third" name="login" placeholder="Username">
      <input required  type="text" v-model="email" id="login" class="fadeIn second" name="login" placeholder="Email">
      <input required  autocomplete="off" type="password" v-model="password" id="password" class="fadeIn third" name="login" placeholder="Password">
      <input required type="password" v-model="repeatPassword" id="password" class="fadeIn third" name="login" placeholder="Repeat password">
      <input required type="submit" @click="onRegister()" class="fadeIn fourth" value="Đăng Ký">
    </div>

    <!-- Remind Passowrd -->
    <!-- <div id="formFooter">
      <a class="underlineHover" href="#">Quên mật khẩu?</a>
    </div> -->

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
      user:{},
      username: "",
      password:"",
      email:"",
      repeatPassword:"",
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

    onRegister() {
      let success = true;
      if(this.username.trim() == "" || this.password.trim() == "" || this.email.trim() == "" || this.repeatPassword.trim() == "") {
        success = false;
        this.toastContent ="EMPTY"
        this.isErrorToast = true;
        this.isShowToast = true;
        return;
      } 
      if(this.repeatPassword !== this.password) {
        success = false;
        this.toastContent ="MATCH"
        this.isErrorToast = true;
        this.isShowToast = true;
        return;
      }
      this.userlist.forEach(item => {
        if(this.username == item.UserName && this.password == item.Password){
          success = false;
          this.toastContent ="DUPLICATE"
          this.isErrorToast = true;
          this.isShowToast = true;
          return;
        }
      }); 
     
      if(success){
         this.user = {
            UserName: this.username,
            Password: this.password,
            FirstName: "string",
            LastName: "string",
            Address: "string",
            Role: "Customer",
            Email: this.email,
            PhoneNumber: "string"
          }
          let res = HTTPUsers.post("", this.user);
          if(res) {
            this.toastContent ="SREGIS"
            this.isErrorToast = false;
            this.isShowToast = true;
            // Lấy danh sách sản phẩm từ sessionStorage (nếu đã có)
              let account = JSON.parse(sessionStorage.getItem('account')) || [];
              // Thêm sản phẩm vào giỏ hàng
              account.push(this.username);
              // Lưu lại danh sách sản phẩm vào sessionStorage
              sessionStorage.setItem('account', JSON.stringify(account));
            setTimeout(() => {
                this.$router.push('/');
            }, 1500);
          }
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