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
    <form>
      <input type="text" id="login" class="fadeIn second" name="login" placeholder="Email">
      <input type="text" id="password" class="fadeIn third" name="login" placeholder="Password">
      <input type="submit" class="fadeIn fourth" value="Đăng nhập">
    </form>

    <!-- Remind Passowrd -->
    <div id="formFooter">
      <a class="underlineHover" href="#">Quên mật khẩu?</a>
    </div>

  </div>
</div>
</template>
<script>

export default {

}
</script>
<style scoped>
@import "../css/components/login.css";
</style>