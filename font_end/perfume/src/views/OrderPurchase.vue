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
                            <form id="login-form-wrap" class="login collapse" method="post">
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
                            </form>
                            <form enctype="multipart/form-data" action="#" class="checkout" method="post" name="checkout">

                                <div id="customer_details" style="align-items: center;" class="col2-set flex">
                                    <div style="flex: 45%; margin-right: 24px;">
                                        <div class="woocommerce-billing-fields">
                                            <h3>Thông tin chi tiết</h3>


                                            <p id="billing_first_name_field"
                                                class="form-row form-row-first validate-required">
                                                <label class="" for="billing_first_name">Tên <abbr title="required"
                                                        class="required">*</abbr>
                                                </label>
                                                <input type="text" value="" placeholder="" id="billing_first_name"
                                                    name="billing_first_name" class="input-text ">
                                            </p>

                                            <p id="billing_last_name_field"
                                                class="form-row form-row-last validate-required">
                                                <label class="" for="billing_last_name">Họ <abbr title="required"
                                                        class="required">*</abbr>
                                                </label>
                                                <input type="text" value="" placeholder="" id="billing_last_name"
                                                    name="billing_last_name" class="input-text ">
                                            </p>
                                            <div class="clear"></div>



                                            <p id="billing_address_1_field"
                                                class="form-row form-row-wide address-field validate-required">
                                                <label class="" for="billing_address_1">Địa chỉ <abbr title="required"
                                                        class="required">*</abbr>
                                                </label>
                                                <input type="text" value="" placeholder="Address" id="billing_address_1"
                                                    name="billing_address_1" class="input-text ">
                                            </p>

                                            <p id="billing_city_field"
                                                class="form-row form-row-wide address-field validate-required"
                                                data-o_class="form-row form-row-wide address-field validate-required">
                                                <label class="" for="billing_city">Số nhà<abbr title="required"
                                                        class="required">*</abbr>
                                                </label>
                                                <input type="text" value="" placeholder="15" id="billing_city"
                                                    name="billing_city" class="input-text ">
                                            </p>

                                            <div class="clear"></div>

                                            <p id="billing_email_field"
                                                class="form-row form-row-first validate-required validate-email">
                                                <label class="" for="billing_email">Email<abbr title="required"
                                                        class="required">*</abbr>
                                                </label>
                                                <input type="text" value="" placeholder="nguyen@gmail.com"
                                                    id="billing_email" name="billing_email" class="input-text ">
                                            </p>

                                            <p id="billing_phone_field"
                                                class="form-row form-row-last validate-required validate-phone">
                                                <label class="" for="billing_phone">Số điện thoại <abbr title="required"
                                                        class="required">*</abbr>
                                                </label>
                                                <input type="text" value="" placeholder="" id="billing_phone"
                                                    name="billing_phone" class="input-text ">
                                            </p>
                                            <div class="clear"></div>


                                            <div class="create-account">
                                                <p id="account_password_field" class="form-row validate-required">
                                                    <label class="" for="account_password">Mật khẩu của bạn <abbr
                                                            title="required" class="required">*</abbr>
                                                    </label>
                                                    <input type="password" value="" placeholder="Password"
                                                        id="account_password" name="account_password" class="input-text">
                                                </p>
                                                <div class="clear"></div>
                                            </div>

                                        </div>
                                    </div>

                                    <div style="flex: 45%;">
                                        <h3 id="order_review_heading" style="margin-top: -128px;">Hóa đơn</h3>
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
                                                    <td><strong><span class="amount">{{ TotalPirceCart }} vnđ</span></strong> </td>
                                                </tr>

                                            </tfoot>
                                        </table>


                                        <div id="payment">
                                            <ul class="payment_methods methods">
                                                <li class="payment_method_bacs flex">
                                                    <input type="radio" data-order_button_text="" checked="checked"
                                                        value="bacs" name="payment_method" class="input-radio mr-16"
                                                        id="payment_method_bacs">
                                                    <label for="payment_method_bacs">Chuyển khoản trực tiếp</label>
                                                    <!-- <div class="payment_box payment_method_bacs">
                                                        <p>Thực hiện thanh toán của bạn trực tiếp vào tài khoản ngân hàng của chúng tôi. Vui lòng sử dụng ID đơn đặt hàng của bạn làm tham chiếu thanh toán. Đơn đặt hàng của bạn sẽ không được giao cho đến khi tiền trong tài khoản của chúng tôi được thanh toán.</p>
                                                    </div> -->
                                                </li>
                                                <li class="payment_method_cheque flex">
                                                    <input  type="radio" data-order_button_text="" value="cheque"
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

                                            <input type="submit" data-value="Place order" value="Thanh toán"
                                                id="place_order" name="woocommerce_checkout_place_order"
                                                class="button alt">


                                        </div>

                                        <div class="clear"></div>

                                    </div>
                                </div>
                            </div>


                        </form>

                    </div>
                </div>
            </div>
        </div>
    </div>
</div></template>
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
import { HTTP } from "../js/api.js"
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
}
</script>
<style scoped>
.mr-16 {
    margin-right: 16px;
}
</style>