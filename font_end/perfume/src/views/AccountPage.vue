<template>
    <div class="wrapper ">
        <div id="formContent" class="account">
            <!-- Tabs Titles -->
            <h2 class="active" style="cursor: pointer;" @click="isShow(true, false)"> Tài Khoản </h2>
            <h2 class="active" style="cursor: pointer;" @click="isShow(false, true)"> Đơn hàng</h2>
            <!-- // <h2 class="inactive underlineHover">Sign Up </h2> -->

            <!-- Icon -->
            <!-- <div class="fadeIn first">
      <img src="http://danielzawadzki.com/codepen/01/icon.svg" id="icon" alt="User Icon" />
    </div> -->

            <!-- Login Form -->
            <div v-if="isShowAccount">
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
            <div v-if="isShowOrder" class="sale-order-container">
                <div class="container">
                    <h1>Thông tin đơn hàng</h1>
                    <table>
                        <thead>
                            <tr>
                                <th>Ảnh sản phẩm</th>
                                <th>Tên sản phẩm</th>
                                <th>Số lượng</th>
                                <th>Giá tiền</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td><img src="https://nuochoa95.com/Data/images/san%20pham/Parfums%20de%20Marly/Parfums-De-Marly-Delina-Eau-De-Parfum.jpg" alt="Product 1"></td>
                                <td>Áo thun nam</td>
                                <td>2</td>
                                <td>200,000 đồng</td>
                            </tr>
                            <tr>
                                <td><img src="https://nuochoa95.com/Data/images/san%20pham/Parfums%20de%20Marly/Parfums-De-Marly-Delina-Eau-De-Parfum.jpg" alt="Product 2"></td>
                                <td>Quần jean nam</td>
                                <td>1</td>
                                <td>250,000 đồng</td>
                            </tr>
                            <tr>
                                <td><img src="https://nuochoa95.com/Data/images/san%20pham/Parfums%20de%20Marly/Parfums-De-Marly-Delina-Eau-De-Parfum.jpg" alt="Product 3"></td>
                                <td>Giày thể thao nữ</td>
                                <td>1</td>
                                <td>300,000 đồng</td>
                            </tr>
                        </tbody>
                        <tfoot>
                            <tr>
                                <td colspan="3"><strong>Tổng tiền:</strong></td>
                                <td>750,000 đồng</td>
                            </tr>
                        </tfoot>
                    </table>
                    <div class="order-info">
                        <p><strong>Mã đơn hàng:</strong> DH001</p>
                        <p><strong>Ngày đặt hàng:</strong> 05/08/2023</p>
                        <p><strong>Tên khách hàng:</strong> Nguyễn Văn A</p>
                        <p><strong>Tình trạng đơn hàng</strong> Nguyễn Văn A</p>
                        <p><strong>Địa chỉ:</strong> 123 đường ABC, phường XYZ, quận QWE, thành phố HCM</p>
                    </div>
                </div>
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
            isShowAccount: true,
            isShowOrder: false
        }
    },
    methods: {
        isShow(account, order) {
            this.isShowAccount = account;
            this.isShowOrder = order;
        },
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
.sale-order-container .container {
	max-width: 800px;
	margin: 0 auto;
	padding: 20px;
}

.sale-order-container table {
	border-collapse: collapse;
	width: 100%;
}

.sale-order-container th, td {
	text-align: left;
	padding: 8px;
}

.sale-order-container th {
	background-color: #f2f2f2;
}

.sale-order-container img {
	max-width: 100px;
	height: auto;
}

.sale-order-container .order-info p {
	margin-bottom: 10px;
}
</style>