<template>
    <div class="product-big-title-area">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="product-bit-title text-center">
                        <h2>Thanh toán hóa đơn</h2>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <div class="single-product-area">
        <div class="zigzag-bottom"></div>
        <div class="container">
            <div class="row">

                <div class="col-md-12">
                    <div class="product-content-right">
                        <div class="woocommerce">
                            <div id="login-form-wrap" class="login collapse" method="post">
                                <p class="form-row form-row-first">
                                    <label for="username">Username or email <span class="required">*</span>
                                    </label>
                                    <input type="text" id="username" name="username" class="input-text">
                                </p>
                                <p class="form-row form-row-last">
                                    <label for="password">Password <span class="required">*</span>
                                    </label>
                                    <input type="password" id="password" name="password" class="input-text">
                                </p>
                                <div class="clear"></div>


                                <p class="form-row">
                                    <input type="submit" value="Login" name="login" class="button">
                                    <label class="inline" for="rememberme"><input type="checkbox" value="forever"
                                            id="rememberme" name="rememberme"> Remember me </label>
                                </p>
                                <p class="lost_password">
                                    <a href="#">Lost your password?</a>
                                </p>

                                <div class="clear"></div>
                            </div>
                            <div enctype="multipart/form-data" action="#" class="checkout" method="post" name="checkout">

                                <div id="customer_details" style="align-items: center;" class="col2-set flex">
                                    <div style="flex: 45%; margin-right: 24px;">
                                        <div class="woocommerce-billing-fields">
                                            <h3>Thông tin chi tiết</h3>
                                            <p id="billing_city_field"
                                                class="form-row form-row-wide address-field validate-required"
                                                data-o_class="form-row form-row-wide address-field validate-required">
                                                <label class="" for="billing_city">Mã đơn hàng<abbr title="required"
                                                        class="required">*</abbr>
                                                </label>
                                                <input type="text" v-model="saleOrder.SaleOrderCode" id="billing_city"
                                                    name="billing_city" class="input-text ">
                                            </p>
                                            <p id="billing_first_name_field"
                                                class="form-row form-row-first validate-required">
                                                <label class="" for="billing_first_name">Họ <abbr title="required"
                                                        class="required">*</abbr>
                                                </label>
                                                <input v-model="saleOrder.FirstName" type="text" placeholder=""
                                                    id="billing_first_name" name="billing_first_name" class="input-text ">
                                            </p>

                                            <p id="billing_last_name_field"
                                                class="form-row form-row-last validate-required">
                                                <label class="" for="billing_last_name">Tên <abbr title="required"
                                                        class="required">*</abbr>
                                                </label>
                                                <input v-model="saleOrder.LastName" type="text" placeholder=""
                                                    id="billing_last_name" name="billing_last_name" class="input-text ">
                                            </p>
                                            <div class="clear"></div>
                                            <p id="billing_address_1_field"
                                                class="form-row form-row-wide address-field validate-required">
                                                <label class="" for="billing_address_1">Địa chỉ <abbr title="required"
                                                        class="required">*</abbr>
                                                </label>
                                                <input type="text" v-model="saleOrder.CustomerAddress" placeholder="Address"
                                                    id="billing_address_1" name="billing_address_1" class="input-text ">
                                            </p>
                                            <div class="clear"></div>

                                            <p id="billing_email_field"
                                                class="form-row form-row-first validate-required validate-email">
                                                <label class="" for="billing_email">Email<abbr title="required"
                                                        class="required">*</abbr>
                                                </label>
                                                <input type="text" v-model="user.Email" placeholder="nguyen@gmail.com" id="billing_email"
                                                    name="billing_email" class="input-text ">
                                            </p>

                                            <p id="billing_phone_field"
                                                class="form-row form-row-last validate-required validate-phone">
                                                <label class="" for="billing_phone">Số điện thoại <abbr title="required"
                                                        class="required">*</abbr>
                                                </label>
                                                <input v-model="saleOrder.CustomerPhone" type="text" placeholder="" id="billing_phone" name="billing_phone"
                                                    class="input-text ">
                                            </p>
                                            <div class="clear"></div>

                                        </div>
                                    </div>

                                    <div style="flex: 45%;">
                                        <h3 id="order_review_heading" style="margin-top: 26px;margin-bottom: 13px;">Hóa đơn</h3>
                                        <div id="order_review" style="position: relative;">
                                        </div>

                                        <table class="shop_table">
                                            <thead>
                                                <tr>
                                                    <th class="product-name">Sản phẩm</th>
                                                    <th class="product-total">Tổng</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr class="cart_item">
                                                    <td class="product-name">
                                                        Tổng tiền <strong class="product-quantity"></strong> </td>
                                                    <td class="product-total">
                                                        <span class="amount">{{ TotalPirceCart }} vnđ</span>
                                                    </td>
                                                </tr>
                                            </tbody>
                                            <tfoot>
                                                <tr class="shipping">
                                                    <th>Phí vận chuyển</th>
                                                    <td>
                                                        0
                                                        <input type="hidden" class="shipping_method" value="free_shipping"
                                                            id="shipping_method_0" data-index="0" name="shipping_method[0]">
                                                    </td>
                                                </tr>
                                                <tr class="order-total">
                                                    <th>Thanh toán</th>
                                                    <td><strong><span class="amount">{{ TotalPirceCart }} vnđ
                                                                </span></strong> </td>
                                                </tr>

                                            </tfoot>
                                        </table>
                                        <div id="payment">
                                            <ul class="payment_methods methods">
                                                <li class="payment_method_bacs flex">
                                                    <input type="radio" data-order_button_text="" checked="checked"
                                                        value="bacs" name="payment_method" class="input-radio mr-16"
                                                        id="payment_method_bacs">
                                                    <label for="payment_method_bacs">Thanh toán sau khi nhận hàng</label>
                                                    <!-- <div class="payment_box payment_method_bacs">
                                                        <p>Thực hiện thanh toán của bạn trực tiếp vào tài khoản ngân hàng của chúng tôi. Vui lòng sử dụng ID đơn đặt hàng của bạn làm tham chiếu thanh toán. Đơn đặt hàng của bạn sẽ không được giao cho đến khi tiền trong tài khoản của chúng tôi được thanh toán.</p>
                                                    </div> -->
                                                </li>
                                                <li class="payment_method_cheque flex">
                                                    <input type="radio" data-order_button_text="" value="cheque"
                                                        name="payment_method" class="input-radio mr-16"
                                                        id="payment_method_cheque">
                                                    <label for="payment_method_cheque">Quét mã Qr code </label>
                                                    <div style="display:none;" class="payment_box payment_method_cheque">
                                                    </div>
                                                </li>
                                                <li class="payment_method_paypal flex">
                                                    <input type="radio" data-order_button_text="Proceed to PayPal"
                                                        value="paypal" name="payment_method" class="input-radio mr-16"
                                                        id="payment_method_paypal">
                                                    <label for="payment_method_paypal">PayPal <img
                                                            alt="PayPal Acceptance Mark"
                                                            src="https://www.paypalobjects.com/webstatic/mktg/Logo/AM_mc_vs_ms_ae_UK.png"><a
                                                            title="What is PayPal?"
                                                            onclick="javascript:window.open('https://www.paypal.com/gb/webapps/mpp/paypal-popup','WIPaypal','toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=yes, width=1060, height=700'); return false;"
                                                            class="about_paypal"
                                                            href="https://www.paypal.com/gb/webapps/mpp/paypal-popup">What
                                                            is PayPal?</a>
                                                    </label>
                                                    <div style="display:none;" class="payment_box payment_method_paypal">

                                                    </div>
                                                </li>
                                            </ul>
                                            <div class="form-row place-order">

                                                <input type="submit" @click="onPerchase()" data-value="Place order" value="Thanh toán"
                                                    id="place_order" name="woocommerce_checkout_place_order"
                                                    class="button alt">
                                            </div>

                                            <div class="clear"></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <BaseLoading v-if="isShowLoading" />
    <BaseToast v-if="isShowToast" 
        @closeToast="onhideToast" 
        @onhideToast="onhideToast" 
        :toastType="toastContent"
        :toastTitle="toastTitle" 
        :isSuccessToast="isSuccessToast" 
        :isErrorToast="isErrorToast" />
</template>
<script>
import "https://code.jquery.com/jquery.min.js";
import "http://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js";
import "../js/owl.carousel.min.js";
import "../js/jquery.sticky.js";
import "../js/jquery.easing.1.3.min.js";
import "../js/main.js";
import "../js/bxslider.min.js";
import "../js/script.slider.js";
import { Carousel, Slide } from 'vue-carousel';
import { HTTP, HTTPOrders,HTTPDelivery,HTTPUsers,HTTPOrderItem } from "../js/api.js"
import { Suspense } from "vue";
import {formatMoney} from "../js/common.js"


export default {
    inject: ["store"],
    async created() {
        await this.getNewEmCode();
        this.getCartItems();
        await this.getUserInfor();
    },
    computed: {
        CartQuantity() {
            let cartItems = JSON.parse(sessionStorage.getItem('cartItems')) || [];
            return cartItems.length;
        },
        TotalPirceCart() {
            let totalPrice = 0;
            let cartItems = JSON.parse(sessionStorage.getItem('cartItems')) || [];
            cartItems.forEach(item => {
                totalPrice += item.Price;
            });
            return totalPrice;
        }
    },
    data() {
        return {
            saleOrder: {
                SaleOrderId: this.getNewId(),
                SaleOrderCode: "",
                CustomerAddress: "",
                CustomerPhone: "",
                UserId: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                FirstName: "",
                LastName: "",
                DeliveryId: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                status: 0,
                TotalPrice: 0,
                user:{},
                formatMoney
            },
            orderItem:{
                    CreatedDate: "2023-05-08T14:01:05.931Z",
                    ModifiedDate: "2023-05-08T14:01:05.931Z",
                    OrderItemId: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                    ProductId: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                    SaleOrderId: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                    Quantity: 0,
                    Price: 0
            },
            delivery: {},
            user: JSON.parse(sessionStorage.getItem('account')) || [],
            isShowToast:false,
            toastContent: "AUTHEN", // nội dung toast message
            toastTitle: "", // Tiêu đề toast,
            isErrorToast: false, // Icon toast lỗi
            isSuccessToast: true, // icon toast thành công
            cartResult:[],
            isShowLoading:false,
        }
    },
    methods: {
        getNewId() {
            const myGuid = 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
                const r = Math.random() * 16 | 0;
                const v = c == 'x' ? r : (r & 0x3 | 0x8);
                return v.toString(16);
            });
        },
        async getNewEmCode() {
            const response = await HTTPOrders.get(`/new-sale-order-code`);
            this.saleOrder.SaleOrderCode = response.data;
            //this.newEmployeeCode = response.data;
        },
        async onPerchase() {
            let me = this;
            if(!this.validate()) {
                this.toastContent ="EMPTY"
                this.isErrorToast = true;
                this.isShowToast = true;
                return;
            } 
            else {
                this.isShowLoading = true;
                this.saleOrder.DeliveryId = await this.getNewDeliveryId();
                this.saleOrder.UserId = this.getUserId();
                this.saleOrder.TotalPrice = this.TotalPirceCart;
                try{
                    const res = await HTTPOrders.post('',this.saleOrder);
                    if(res.data && this.cartResult.length) {
                        this.cartResult.forEach(item => {
                            item.value.Quantity = item.value.Quantity - item.count;
                            item.value.QuantityPurchased = item.count; 
                            HTTP.put(`/${item.value.ProductId}`,item.value) 
                            me.orderItem.ProductId = item.value.ProductId;
                            me.orderItem.SaleOrderId = res.data;
                            me.orderItem.Quantity = item.count;
                            me.orderItem.Price = item.value.Price;
                            HTTPOrderItem.post("",me.orderItem);
                                
                        });
                    }
                    this.isShowLoading = false;
                    this.toastContent =  "ORDERSUCCESS"
                    this.isErrorToast = false;
                    this.isShowToast = true;
                    // Lấy danh sách sản phẩm từ sessionStorage (nếu đã có)
                    let  cartItems =  JSON.parse(sessionStorage.getItem('cartItems')) || [];
                    // Lưu lại danh sách sản phẩm vào sessionStorage
                    if(cartItems.length) {
                        sessionStorage.removeItem('cartItems')
                    }
                    this.store.setCartItems();
                    setTimeout(() => {
                        this.$router.push('/');
                    }, 1500);
                }
                catch(ex) {
                    console.log(ex)
                }
            }

        },
       async getNewDeliveryId() {
            const response = await HTTPDelivery.get(`/new-delivery-code`);
            let deliveryCode = response.data;
            let delivery = {
                DeliveryId: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                DeliveryCode: deliveryCode,
                DeliveryName: "Nguyễn Văn Ngọc",
                Status: 0
            }
            let res = await HTTPDelivery.post(``, delivery);
            return res.data;
            
        },
        getUserId() {
             // Lấy danh sách sản phẩm từ sessionStorage (nếu đã có)
             let account = JSON.parse(sessionStorage.getItem('account')) || [];
              // Lưu lại danh sách sản phẩm vào sessionStorage
              if(account.length) {
                return account[0];
              }
        },
        async getUserInfor() {
            let account = JSON.parse(sessionStorage.getItem('account')) || [];
            if(account.length) {
                HTTPUsers.get(`/${account[0]}`).then((res) => {
                this.user = res.data;
                this.saleOrder.CustomerAddress = this.user.Address;
                this.saleOrder.FirstName = this.user.FirstName;
                this.saleOrder.LastName = this.user.LastName;
                this.saleOrder.CustomerPhone = this.user.PhoneNumber;


                })
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
           ///custom lại mảng giỏ hàng
        getCartItems() {
            let  cartItems =  JSON.parse(sessionStorage.getItem('cartItems')) || [];
            const counts = {};
            const unique = [];
            for (let item of cartItems) {
            if (!counts[item.ProductId]) {
                counts[item.ProductId] = 1;
                unique.push(item);
            } else {
                counts[item.ProductId]++;
            }
            }

            const result = unique.map((item) => ({
            value: item,
            count: counts[item.ProductId],
            }));
            this.cartResult =  result;
            console.log(this.cartResult)
        }, 
        validate() {
            let success = true;
            if(this.saleOrder.SaleOrderCode == ""|| this.saleOrder.FirstName == "" || this.saleOrder.LastName ==""
            || this.saleOrder.CustomerAddress== "" || this.saleOrder.CustomerPhone == "") {
                success = false;
            }
            console.log(this.saleOrder)
            return success;
        }

    }
}
</script>
<style scoped>
.mr-16 {
    margin-right: 16px;
}
#customer_details input[type="text"]:focus-visible {
    border: 1px solid green;
    outline: none;
}
input[type="submit"]:hover, button[type="submit"]:hover {
    background-color: var(--focus-color);
}
</style>