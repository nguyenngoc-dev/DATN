<template>
    <div class="wrapper ">
        <div id="formContent" class="account">
            <!-- Tabs Titles -->
            <h2 class="active"> Tài Khoản </h2>
            <!-- // <h2 class="inactive underlineHover">Sign Up </h2> -->

            <!-- Icon -->
            <!-- <div class="fadeIn first">
      <img src="http://danielzawadzki.com/codepen/01/icon.svg" id="icon" alt="User Icon" />
    </div> -->

            <!-- Login Form -->
            <div>
                <div class="flex">
                    <input title="Họ" type="text" v-model="user.FirstName" id="login" class="fadeIn second" name="login"
                        placeholder="Họ và tên đệm">
                    <input title="Tên" type="text" v-model="user.LastName" id="password" class="fadeIn third" name="login"
                        placeholder="Tên">
                </div>
                <div class="flex">
                    <input title="Địa chỉ" type="text" v-model="user.Address" id="login" class="fadeIn second" name="login"
                        placeholder="Địa chỉ">
                    <input title="Email" type="text" v-model="user.Email" id="login" class="fadeIn second" name="login"
                        placeholder="Email">
                    <input title="Số điện thoại" type="text" v-model="user.PhoneNumber" id="login" class="fadeIn second"
                        name="login" placeholder="Số điện thoại">
                </div>
                <div class="flex">
                    <input title="Mật khẩu cũ" type="password" v-model="user.Password" id="login" class="fadeIn second"
                        name="login" placeholder="Mật khẩu cũ">
                    <input title="Không điền mặc định lấy mật khẩu cũ" type="password" v-model="newPassword" id="password"
                        class="fadeIn third" name="login" placeholder="Mật khẩu mới">
                </div>
                <input title="Không điền mặc định lấy mật khẩu cũ" type="password" v-model="repeatNewPassword" id="password"
                    class="fadeIn third" name="login" placeholder="Xác nhận mật khẩu mới">
                <input type="submit" @click="onUpdate()" class="fadeIn fourth update" value="Cập nhật">
            </div>

          

        </div>
    </div>
    <BaseToast v-if="isShowToast" @closeToast="onhideToast" @onhideToast="onhideToast" :toastType="toastContent"
        :toastTitle="toastTitle" :isSuccessToast="isSuccessToast" :isErrorToast="isErrorToast" />
</template>
<script>
import { HTTPUsers } from '../js/api';
export default {
    created() {
        // Lấy danh sách sản phẩm từ sessionStorage (nếu đã có)
        let account = JSON.parse(sessionStorage.getItem('account')) || [];
        if (account.length) {
            // gọi api lấy dữ liệu truyền vào th employee
            HTTPUsers.get(`/${account[0]}`).then((response) => {
                this.user = response.data;
            });
        }
    },
    data() {
        return {
            user: {},
            account: JSON.parse(sessionStorage.getItem('account')) || [],
            newPassword: "",
            repeatNewPassword: "",
            isShowToast: false,
            toastContent: "AUTHEN", // nội dung toast message
            toastTitle: "", // Tiêu đề toast,
            isErrorToast: false, // Icon toast lỗi
            isSuccessToast: true, // icon toast thành công
        }
    },
    methods: {
        async onUpdate() {
            console.log('lol')
            let validate = true;
            if (this.newPassword != "") {
                if (this.newPassword != this.repeatNewPassword) {
                    validate = false;
                    this.toastContent = "MATCH"
                    this.isErrorToast = true;
                    this.isShowToast = true;
                    return;
                }
            }
            if (validate) {
                if (this.newPassword != "") {
                    this.user.Password = this.newPassword;
                    let res = await HTTPUsers.put(`/${this.account[0]}`, this.user);
                    this.toastContent = "UPDATEAUTH"
                    this.isErrorToast = false;
                    this.isShowToast = true;
                }
                else {
                    let res = await HTTPUsers.put(`/${this.account[0]}`, this.user);
                    this.toastContent = "UPDATEAUTH"
                    this.isErrorToast = false;
                    this.isShowToast = true;
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

#formContent.account {
    max-width: unset;
    padding: 0 12px;
}

.fourth.update {
    margin-top: 12px;
}
</style>