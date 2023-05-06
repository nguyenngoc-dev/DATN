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
                                        <ins>{{ products.Price - products.Price * products.Discount / 100 }} vnđ</ins> <del>{{ products.Price }} vnđ</del>
                                    </div>
                                    <div class="product-inner-price">
                                        Số lượng còn: {{ products.Quantity  }}
                                    </div>
                                    <div class="product-inner-price">
                                        Số lượng đã bán: {{ products.QuantityPurchased  }}
                                    </div>
                                    <div class="cart">
                                        <div class="quantity">
                                            <input v-model="productQuantity" type="number" size="4"
                                                class="input-text qty text" title="Qty" name="quantity" min="1" step="1">
                                        </div>
                                        <button @click="onAddCartItem(products)" class="add_to_cart_button">Thêm vào
                                            giỏ</button>
                                    </div>


                                    <div role="tabpanel">
                                        <ul class="product-tab" role="tablist">
                                            <li role="presentation" class="active"><a href="#home" aria-controls="home"
                                                    role="tab" data-toggle="tab">Mô rả</a></li>
                                            <li role="presentation"><a href="#profile" aria-controls="profile" role="tab"
                                                    data-toggle="tab">Đánh giá</a></li>
                                        </ul>
                                        <div class="tab-content">
                                            <div role="tabpanel" class="tab-pane fade in active" id="home">
                                                {{ products.DetailDescription }}
                                            </div>
                                            <div role="tabpanel" class="tab-pane fade" id="profile">
                                                <h2>Thông tin</h2>
                                                <div class="submit-review">
                                                    <p><label for="name">Tên</label> <input name="name" type="text"></p>
                                                    <p><label for="email">Email</label> <input name="email" type="email">
                                                    </p>
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
                                                    <p><label for="review">Bình luận</label> <textarea name="review" id=""
                                                            cols="30" rows="10"></textarea></p>
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
                            <swiper :modules="modules"  :autoplay="true" :pagination="{ clickable: true }" :slides-per-view="4">
                                <swiper-slide  v-for="(product, index) in relatedList" :key="index" class ="single-product mr-12 single-shop-product">
                                    <div class="product-f-image">
                                        <router-link :to="'/detail/' + product.ProductId">
                                            <img :src="product.ImageUrl" alt="Lỗi ảnh">
                                        </router-link>
                                        <div class="product-hover">
                                            <a href="" class="add-to-cart-link" @click="onAddCartItem(product)"><i
                                                    class="fas fa-shopping-cart"></i> Thêm vào giỏ</a>
                                            <router-link class="view-details-link" :to="'/detail/' + product.ProductId">
                                                Xem chi tiết
                                            </router-link>
                                        </div>
                                    </div>

                                    <h2> <router-link :to="'/detail/' + product.ProductId">
                                            {{ product.ProductName }}
                                        </router-link></h2>

                                    <div class="product-carousel-price">
                                        <ins>{{ product.Price }} vnđ</ins> <del>{{ product.Price }} vnđ</del>
                                    </div>

                                </swiper-slide>
                            </swiper>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <BaseToast v-if="isShowToast" @closeToast="onhideToast" @onhideToast="onhideToast" :toastType="toastContent"
        :toastTitle="toastTitle" :isSuccessToast="isSuccessToast" :isErrorToast="isErrorToast" />
</template>
<script>
import SwiperClass, { Pagination } from 'Swiper'
import { Swiper, SwiperSlide } from 'vue-awesome-swiper'

// import swiper module styles
import 'swiper/css'
import 'swiper/css/pagination'
import { HTTP, HTTPCategorys, HTTPProductImages } from "../js/api.js"
import CardItem from "../components/base/CardItem.vue";
export default {
    components: {
        CardItem,
        Swiper,
        SwiperSlide
    },
    setup() {
        return {
            modules: [Pagination]
        }
    },
    data() {
        return {
            productQuantity: 1,
            isShowToast: false,
            toastContent: "ADD", // nội dung toast message
            toastTitle: "", // Tiêu đề toast,
            isErrorToast: false, // Icon toast lỗi
            isSuccessToast: true, // icon toast thành công
            isShowDialog: false, // show dialog báo lỗi khi nhập liệu
            relatedList: [],
            productList: [],
            validateError: [], //
            categories: [], //Danh sách phòng ban
            categoryFilter: [], //Danh sách phòng ban tìm kiếm
            products: {}, // object nhân viên
            productImages: {},
            categorySelected: {}, // phòng ban được chọn
            oldEmployee: {},//nhân viên ban 
            errorOject: {},// object chứa lỗi 
            isName: false, // .... tên không hợp lệ
            newEmployeeCode: "",// lấy ra mã nhân viên mỗi lần click thêm mới
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
            productIdUpdate: null,
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
                    for (const property in this.products) {
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
        await this.getProductFirst();
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
        async getProductFirst() {
            try {
                // show loading
                this.isShowLoading = true;
                HTTP.post(`/filter`, this.getFilterParams("", 20, 1)).then((res) => {
                    this.productList = res.data.Data.filter(product => {
                        return product.IsActive == true
                    });
                    this.relatedList = [this.productList[4], this.productList[8], this.productList[10],
                
                    this.productList[2], this.productList[3], this.productList[5]];
                })
                    .catch(error => {
                        //this.handleExeption(error);
                    })
            } catch (error) {
                //this.handleExeption(error);
            }
        },
        onAddCartItem(product) {
            // Lấy danh sách sản phẩm từ sessionStorage (nếu đã có)
            let addsuccess = true;
            let cartItems = JSON.parse(sessionStorage.getItem('cartItems')) || [];
            if(this.productQuantity > product.Quantity) {
                this.isErrorToast = true;
                this.toastContent="OVERFLOW";
                this.isShowToast = true;
                addsuccess = false;
                return;
            }
            if(addsuccess) {
                this.isErrorToast = false;
                this.toastContent="ADD";
                this.isShowToast = true;
                // Thêm sản phẩm vào giỏ hàng
                if (this.productQuantity) {
                for (let i = 0; i < this.productQuantity; i++) {
                    cartItems.push(product);
                }
            }
            // Lưu lại danh sách sản phẩm vào sessionStorage
            sessionStorage.setItem('cartItems', JSON.stringify(cartItems));
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
        /**
            * author:Nguyễn Văn Ngọc(10/1/2023)
            * Hàm getFilterParams(text) lấy ra object để gọi api filter
            *
            */
        getFilterParams(ProductFilter, PageSize, PageNumber) {
            return {
                ProductFilter: ProductFilter,
                PageSize: PageSize,
                PageNumber: PageNumber,
            };
        },
        async getProductImages() {
            try {
                var res = await HTTPProductImages.get();
                this.categoriesproductImages = res.data;
            } catch (error) {
                //this.handleException(error);
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
.mr-12 {
margin-right: 12px;
}
.ml-12 {

}
</style>