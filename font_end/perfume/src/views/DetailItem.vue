<template>
       <div class="single-product-area">
        <div class="zigzag-bottom"></div>
        <div class="container">
            <div class="row">
                
                <div class="col-md-12">
                    <div class="product-content-right">
                        <div class="row">
                            <div class="col-sm-6">
                                <div class="product-images">
                                    <div class="product-main-img">
                                        <img :src="products.ImageUrl" alt="">
                                    </div>
                                    
                                    <div class="product-gallery">
                                        <img src="../assets/img/anh2.jpg" alt="">
                                        <img src="../assets/img/anh3.jpg" alt="">
                                        
                                    </div>
                                </div>
                            </div>
                            
                            <div class="col-sm-6">
                                <div class="product-inner">
                                    <h2 class="product-name">{{ products.ProductName }}</h2>
                                    <div class="product-inner-price">
                                        <ins>{{ products.Price }}</ins> <del>{{ products.Price }}</del>
                                    </div>    
                                    
                                    <div class="cart">
                                        <div class="quantity">
                                            <input v-model="productQuantity"  type="number" size="4" class="input-text qty text" title="Qty" name="quantity" min="1" step="1">
                                        </div>
                                        <button @click="onAddCartItem(products)" class="add_to_cart_button">Thêm vào giỏ</button>
                                    </div>   
                                    
                                    
                                    <div role="tabpanel">
                                        <ul class="product-tab" role="tablist">
                                            <li role="presentation" class="active"><a href="#home" aria-controls="home" role="tab" data-toggle="tab">Mô rả</a></li>
                                            <li role="presentation"><a href="#profile" aria-controls="profile" role="tab" data-toggle="tab">Đánh giá</a></li>
                                        </ul>
                                        <div class="tab-content">
                                            <div role="tabpanel" class="tab-pane fade in active" id="home">
                                                {{ products.DetailDescription }}
                                            </div>
                                            <div role="tabpanel" class="tab-pane fade" id="profile">
                                                <h2>Thông tin</h2>
                                                <div class="submit-review">
                                                    <p><label for="name">Tên</label> <input name="name" type="text"></p>
                                                    <p><label for="email">Email</label> <input name="email" type="email"></p>
                                                    <div class="rating-chooser">
                                                        <p>Đánh giá</p>

                                                        <div class="rating-wrap-post">
                                                            <i class="fas fa-star"></i>
                                                            <i class="fas fa-star"></i>
                                                            <i class="fas fa-star"></i>
                                                            <i class="fas fa-star"></i>
                                                            <i class="fas fa-star"></i>
                                                        </div>
                                                    </div>
                                                    <p><label for="review">Bình luận</label> <textarea name="review" id="" cols="30" rows="10"></textarea></p>
                                                    <p><input type="submit" value="Gửi"></p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    
                                </div>
                            </div>
                        </div>
                        
                        
                        <div class="related-products-wrapper">
                            <h2 class="related-products-title">Sản phẩm liên quan</h2>
                            <div class="related-products-carousel">
                                <div class="single-product">
                                    <div class="product-f-image">
                                        <img src="img/product-1.jpg" alt="">
                                        <div class="product-hover">
                                            <a href="" class="add-to-cart-link"><i class="fa fa-shopping-cart"></i> Add to cart</a>
                                            <a href="" class="view-details-link"><i class="fa fa-link"></i> See details</a>
                                        </div>
                                    </div>

                                    <h2><a href="">Sony Smart TV - 2015</a></h2>

                                    <div class="product-carousel-price">
                                        <ins>$700.00</ins> <del>$100.00</del>
                                    </div> 
                                </div>
                                <div class="single-product">
                                    <div class="product-f-image">
                                        <img src="img/product-2.jpg" alt="">
                                        <div class="product-hover">
                                            <a href="" class="add-to-cart-link"><i class="fa fa-shopping-cart"></i> Add to cart</a>
                                            <a href="" class="view-details-link"><i class="fa fa-link"></i> See details</a>
                                        </div>
                                    </div>

                                    <h2><a href="">Apple new mac book 2015 March :P</a></h2>
                                    <div class="product-carousel-price">
                                        <ins>$899.00</ins> <del>$999.00</del>
                                    </div> 
                                </div>
                                <div class="single-product">
                                    <div class="product-f-image">
                                        <img src="img/product-3.jpg" alt="">
                                        <div class="product-hover">
                                            <a href="" class="add-to-cart-link"><i class="fa fa-shopping-cart"></i> Add to cart</a>
                                            <a href="" class="view-details-link"><i class="fa fa-link"></i> See details</a>
                                        </div>
                                    </div>

                                    <h2><a href="">Apple new i phone 6</a></h2>

                                    <div class="product-carousel-price">
                                        <ins>$400.00</ins> <del>$425.00</del>
                                    </div>                                 
                                </div>
                                <div class="single-product">
                                    <div class="product-f-image">
                                        <img src="img/product-4.jpg" alt="">
                                        <div class="product-hover">
                                            <a href="" class="add-to-cart-link"><i class="fa fa-shopping-cart"></i> Add to cart</a>
                                            <a href="" class="view-details-link"><i class="fa fa-link"></i> See details</a>
                                        </div>
                                    </div>

                                    <h2><a href="">Sony playstation microsoft</a></h2>

                                    <div class="product-carousel-price">
                                        <ins>$200.00</ins> <del>$225.00</del>
                                    </div>                            
                                </div>
                                <div class="single-product">
                                    <div class="product-f-image">
                                        <img src="img/product-5.jpg" alt="">
                                        <div class="product-hover">
                                            <a href="" class="add-to-cart-link"><i class="fa fa-shopping-cart"></i> Add to cart</a>
                                            <a href="" class="view-details-link"><i class="fa fa-link"></i> See details</a>
                                        </div>
                                    </div>

                                    <h2><a href="">Sony Smart Air Condtion</a></h2>

                                    <div class="product-carousel-price">
                                        <ins>$1200.00</ins> <del>$1355.00</del>
                                    </div>                                 
                                </div>
                                <div class="single-product">
                                    <div class="product-f-image">
                                        <img src="img/product-6.jpg" alt="">
                                        <div class="product-hover">
                                            <a href="" class="add-to-cart-link"><i class="fa fa-shopping-cart"></i> Add to cart</a>
                                            <a href="" class="view-details-link"><i class="fa fa-link"></i> See details</a>
                                        </div>
                                    </div>

                                    <h2><a href="">Samsung gallaxy note 4</a></h2>

                                    <div class="product-carousel-price">
                                        <ins>$400.00</ins>
                                    </div>                            
                                </div>                                    
                            </div>
                        </div>
                    </div>                    
                </div>
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
import "https://code.jquery.com/jquery.min.js";
import "http://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js";
import "../js/owl.carousel.min.js";
import "../js/jquery.sticky.js";
import "../js/jquery.easing.1.3.min.js";
import "../js/main.js";
import "../js/bxslider.min.js";
import "../js/script.slider.js";
import { Carousel, Slide } from 'vue-carousel';
import { HTTP,HTTPCategorys,HTTPProductImages } from "../js/api.js"
import CardItem from "../components/base/CardItem.vue";
import paginate from "vuejs-paginate/src/components/Paginate.vue";
export default {
    components: {
        paginate,
        CardItem,
    },
    data() {
    return {
        productQuantity:1,
    isShowToast:false,
    toastContent: "ADD", // nội dung toast message
    toastTitle: "", // Tiêu đề toast,
    isErrorToast: false, // Icon toast lỗi
    isSuccessToast: true, // icon toast thành công
    isShowDialog: false, // show dialog báo lỗi khi nhập liệu
      validateError: [], //
      categories: [], //Danh sách phòng ban
      categoryFilter: [], //Danh sách phòng ban tìm kiếm
      products: {}, // object nhân viên
      productImages:{},
      categorySelected: {}, // phòng ban được chọn
      oldEmployee:{},//nhân viên ban 
      errorOject:{},// object chứa lỗi 
      isName: false, // .... tên không hợp lệ
      newEmployeeCode:"",// lấy ra mã nhân viên mỗi lần click thêm mới
      isSaveAndAdd: false, // check xem có phải thêm và cất hay k
      isIndentityDate: false,
      isUnit: false,
      isDuplicateCode: false, // mã bị trùng
      titleLossData: "", // Thông báo khi nhập liệu sai
      errorCodeMessage: "", // thông báo lỗi của mã nhân viên
      isNotice: true, // có phải dialog cảnh báo
      isQuestion: false, // có phải dialog cảnh báo thay đổi dữ liệu
      questionMessage: "",
      itemActive: null, // set class active cho list item selected
      showBtnCancel: false, // show nút không ở dialog
      showBtnChangeVal: false, // show nút thay đổi ở dialog khi click vào x
      productIdUpdate:null,
    };
  },
  async created() {
    this.productIdUpdate = this.$route.params.id;
    // lấy dữ liệu phòng ban đẩy vào combobox
    this.getDepartment();
    await this.getProductImages();
    // Truyền dữ liệu vào input khi Sửa
    if (this.productIdUpdate || this.isDuplicate) {
      try {
        // gọi api lấy dữ liệu truyền vào th employee
        HTTP.get(`/${this.productIdUpdate}`).then((response) => {
          this.products = response.data;
          for(const property in this.products) {
            this.oldEmployee[property] = this.products[property]
          }
          // Lấy ra department được chọn
          const categorySelected = this.categories.find(
            (category) =>
            category.CategoryId === this.products?.CategoryId
          );
          this.products.CategoryName = categorySelected.CategoryName;
        });
      } catch (error) {
        console.log(error);
        this.handleException(error);
      }
    }
    // click vào thêm mới hoặc nhân bản thì  gọi api lấy mã nhân viên mới để truyền vào input Mã nhân viên
    if (this.isAdd || this.isDuplicate) {
       this.getNewEmCode();
    }
  },
    methods: {
        async getEmpById() {
      try {
        const res = await HTTP.get(`/${this.productIdUpdate}`);
        this.products = res.data;
      } catch (error) {
        //this.handleException(error);
      }
    },
    /**
     * author:Nguyễn Văn Ngọc(3/1/2023)
     * Hàm getDepartment Lấy ra dữ liệu của phòng ban truyền vào combobox
     */

    async getDepartment() {
      try {
        var res = await HTTPCategorys.get();
        this.categories = res.data;
        this.categoryFilter = res.data;
      } catch (error) {
        //this.handleException(error);
      }
    },
    async getProductImages() {
        try {
        var res = await HTTPProductImages.get();
        this.categoriesproductImages = res.data;
      } catch (error) {
        //this.handleException(error);
      }
    },
    onAddCartItem(product) {
            // Lấy danh sách sản phẩm từ sessionStorage (nếu đã có)
            let cartItems = JSON.parse(sessionStorage.getItem('cartItems')) || [];

            // Thêm sản phẩm vào giỏ hàng
            if(this.productQuantity) {
                for(let i = 0; i < this.productQuantity; i++) {
                    cartItems.push(product);
                }
            }
            
            
            // Lưu lại danh sách sản phẩm vào sessionStorage
            sessionStorage.setItem('cartItems', JSON.stringify(cartItems));
            this.isShowToast = true;
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
        onChangeQuantity() {
            console.log("alo",this.productQuantity)
        }
    }

}
</script>