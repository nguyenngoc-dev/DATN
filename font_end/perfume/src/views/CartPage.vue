<template>
        <section >
         <div >
            <div class="row">
                <div class="col-md-12">
                    <div class="product-bit-title text-center">
                        <h2>Giỏ hàng</h2>
                    </div>
                </div>
            </div>
        </div> 
        </section>
        
        <section class="section-content padding-y">
        <div class="container">
        
        <div class="row">
            <main class="col-md-9">
        <div class="card">
        
        <table class="table table-borderless table-shopping-cart">
        <thead class="text-muted">
        <tr class="small text-uppercase">
        <th scope="col">Sản phẩm</th>
        <th scope="col" width="120">Số lượng</th>
        <th scope="col" width="120">Đơn giá</th>
        <th scope="col" width="120">Thành tiền</th>
        <th scope="col" class="text-right" width="200"> </th>
        </tr>
        </thead>
        <tbody>
        <tr v-for="(product, index) in cartResult" :key="index">
            <td>
                <figure class="itemside">
                    <div class="aside"><img :src="product.value.ImageUrl" class="img-sm" /></div>
                    <figcaption class="info">
                        <router-link :to="'/detail/' + product.value.ProductId" class="title text-dark">
                        {{ product.value.ProductName }}
                        </router-link>
                    </figcaption>
                </figure>
            </td>
            <td> 
                <input @change="onChangeQuantity(product,product.count)"  class="form-control" type="number" v-model="product.count" min="1">
                
            </td>
            <td> 
                <div class="price-wrap"> 
                    <var class="price">{{ formatMoney(product.value.Price) }}</var> 
                    
                </div> 
            </td>
            <td> 
                <div class="price-wrap"> 
                    <var class="price">{{ formatMoney(product.value.Price * product.count) }}</var> 
                </div> 
            </td>
            <td class="text-right"> 
            <button data-original-title="Save to Wishlist" title=""  class="btn btn-light mr-2" data-toggle="tooltip"> <i class="fa fa-heart"></i></button> 
            <button @click="removeFromCart(product)"  class="btn btn-light"> Loại bỏ</button>
            </td>
        </tr>

        </tbody>
        </table>
        
        <div class="card-body border-top">
            <div @click="onPerchase"  class="btn btn-primary float-md-right"> 
               Thanh toán<i class="fa fa-chevron-right" style="margin-left: 4px;margin-top: 4px;"></i> </div>
            <router-link to="/" class="btn btn-light"> <i class="fa fa-chevron-left"></i> 
                Quay lại </router-link>
        </div>	
        </div> 
        
        <div class="alert alert-success mt-3">
            <p class="icontext"><i class="icon text-success fa fa-truck"></i> Free Delivery within 1-2 weeks</p>
        </div>
        
            </main>
            <aside class="col-md-3">
                <div class="card mb-3">
                    <div class="card-body">
                    <form>
                        <div class="form-group">
                            <label>Mã giảm giá</label>
                            <div class="input-group">
                                <input type="text" class="form-control" name="" placeholder="Mã" />
                                <span class="input-group-append"> 
                                    <button class="btn btn-primary">Áp mã</button>
                                </span>
                            </div>
                        </div>
                    </form>
                    </div> 
                </div>  
                <div class="card">
                    <div class="card-body">
                            <dl class="dlist-align">
                            <dt>Tổng:</dt>
                            <dd class="text-right">
                                {{ formatMoney(totalPrice) }} 
                            </dd>
                            </dl>
                            <dl class="dlist-align">
                            <dt>Giảm giá</dt>
                            <dd class="text-right">0x</dd>
                            </dl>
                            <dl class="dlist-align">
                            <dt>Phải trả:</dt>
                            <dd class="text-right  h5"><strong> {{ formatMoney(totalPrice) }}</strong></dd>
                            </dl>
                            <hr />
                            <p class="text-center mb-3">
                                <img src="https://therichpost.com/wp-content/uploads/2021/12/payments-1.png" height="26" />
                            </p>
                            
                    </div> 
                </div>  
            </aside> 
        </div>
        
        </div> 
        </section>
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
import {formatMoney} from "../js/common.js"
export default {
    inject: ["store"],
    computed: {
    CartQuantity() {
      let  cartItems =  JSON.parse(sessionStorage.getItem('cartItems')) || [];
      return cartItems.length;
    },
    
    // getCartItems() {
    //     let  cartItems =  JSON.parse(sessionStorage.getItem('cartItems')) || [];
    //     const counts = {};
    //     const unique = [];
    //     for (let item of cartItems) {
    //     if (!counts[item]) {
    //         counts[item] = 1;
    //         unique.push(item);
    //     } else {
    //         counts[item]++;
    //     }
    //     }

    //     const result = unique.map((item) => ({
    //     value: item,
    //     count: counts[item],
    //     }));
    //     console.log(result)
    //     return result;
    // }
  },
  created() {
    this.getCartItems();
    this.TotalPirceCart();
  },
  data() {
    return {
      cartItems: JSON.parse(sessionStorage.getItem('cartItems')) || [],
      cartResult:[],
      isShowToast:false,
        toastContent: "DELETE", // nội dung toast message
        toastTitle: "", // Tiêu đề toast,
        isErrorToast: false, // Icon toast lỗi
        isSuccessToast: true, // icon toast thành công
        totalPrice:0,
        formatMoney
    }
  
  },  
  methods: {
    onChangeQuantity(product,quantity) {
        let result = [];
        let cartItems =  JSON.parse(sessionStorage.getItem('cartItems')) || [];
        console.log(product);
        if(cartItems.length) {
          result = cartItems.filter(item => item.ProductId !== product.value.ProductId
          );
        }
        // Lưu lại danh sách sản phẩm vào sessionStorage
        sessionStorage.setItem('cartItems', JSON.stringify(result));
       
            if(quantity < product.value.Quantity) {
                // Thêm sản phẩm vào giỏ hàng
                if (quantity) {
                for (let i = 0; i < quantity; i++) {
                    result.push(product.value);
                }
            }
            // Lưu lại danh sách sản phẩm vào sessionStorage
            sessionStorage.setItem('cartItems', JSON.stringify(result));
            this.store.setCartItems();
            this.TotalPirceCart();
        }
    },
    TotalPirceCart() {
      let totalPrice = 0;
      let  cartItems =  JSON.parse(sessionStorage.getItem('cartItems')) || [];
      cartItems.forEach(item => {
        totalPrice += item.Price;
      });
      this.totalPrice =  totalPrice;
    },
    onPerchase(){
        let account = JSON.parse(sessionStorage.getItem('account')) || [];
        let cartItems =  JSON.parse(sessionStorage.getItem('cartItems')) || [];
        if(!account.length) {
            this.toastContent ="LOGREQ"
            this.isErrorToast = true;
            this.isShowToast = true;
            setTimeout(() => {
                this.$router.push("/login");
              }, 1500);
           
        }
        else if(!cartItems.length) {
            this.toastContent ="NEEDBUY"
            this.isErrorToast = true;
            this.isShowToast = true;
            setTimeout(() => {
                this.$router.push("/");
              }, 1500);
        }
        else {
            this.$router.push("/order-purchase");
        }
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
    }, 
    ///Xóa sản phẩm khỏi giỏ hàng
    removeFromCart(product) {
      // Xóa sản phẩm khỏi giỏ hàng
      let cartItems = JSON.parse(sessionStorage.getItem('cartItems')) || [];
      let result = [];
      if(cartItems.length) {
          result = cartItems.filter(item => item.ProductId !== product.value.ProductId
          );
        }
        // Lưu lại danh sách sản phẩm vào sessionStorage
        sessionStorage.setItem('cartItems', JSON.stringify(result));
        this.isShowToast = true;
        this.getCartItems();
        this.store.setCartItems();
        this.TotalPirceCart();
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
    },
}
</script>
<style scoped>
@import "../../public/assets/css/all.min.css";
@import "../../public/assets/css/bootstrap.css";
@import "../../public/assets/css/responsive.css";
@import "../../public/assets/css/ui.css";
.product-bit-title {
    background-color: var(--primary-color);
}
</style>