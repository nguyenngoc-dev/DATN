<template>
    <div class="product-big-title-area">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="product-bit-title text-center">
                        <h2>Nước hoa nữ</h2>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <div class="single-product-area">
        <div class="zigzag-bottom"></div>
        <div class="container">
            <div class="row">
                <div class="col-md-3 col-sm-6" v-for="(product, index) in products" :key="index">
                    <div class="single-shop-product">
                        <div class="product-upper">
                            <router-link :to="'/detail/' + product.ProductId">
                                <img :src="product.ImageUrl" alt="Lỗi ảnh">
                            </router-link>
                        </div>
                        <h2>
                            <router-link :to="'/detail/' + product.ProductId">
                                {{ product.ProductName }}
                            </router-link>

                        </h2>
                        <div class="product-carousel-price">
                            <ins>{{ product.Price - product.Price * product.Discount / 100 }} vnđ</ins> <del>{{ product.Price }} vnđ</del>
                        </div>

                        <div class="product-option-shop">
                            <button @click="onAddCartItem(product)" class="add_to_cart_button">
                                Thêm vào giỏ
                            </button>
                        </div>
                    </div>
                </div>

            </div>

            <div class="row">
                <div class="col-md-12">
                    <div class="product-pagination text-center">
                        <nav>
                            <paginate :page-count="totalPage" :page-range="3" :margin-pages="1"
                                :click-handler="clickCallback" :prev-text="'Trước'" :next-text="'Sau'"
                                :prev-class="'prev-btn'" :next-class="'next-btn'" :container-class="'pagination'"
                                :page-class="'page-item'" :v-show="this.totalPage">
                            </paginate>
                        </nav>
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

import { Carousel, Slide } from 'vue-carousel';
import { HTTP } from "../js/api.js"
import CardItem from "../components/base/CardItem.vue";
import paginate from "vuejs-paginate/src/components/Paginate.vue";
export default {
    inject: ["store"],
    components: {
        paginate,
        CardItem,
    },
    data() {
        return {
            settings: {
                arrows: true,
                dots: true,
            },
            products: [], // mảng hứng dữ liệu đổ vào bảng
            isShowDialog: false, // Show chi tiết nhân viên
            isShowLoading: false, // Show loading
            textSearch: "", // nội dung ô tìm kiếm
            productImageIdSelected: null,
            productIdSelected: null, // id của nhân viên khi click nút sửa
            productDelete: [],// mảng xóa một nhân viên
            productIdDelete: null, // lấy ra id khi xóa nhân viên
            productIdDuplicate: false, // lấy id nhân viên để nhân bản
            isShowToast: false, //show toast message
            totalPage: 1, // Tổng số trang
            //currentPageSizeText: RESOURCES.PAGINATION[0].text, // Tổng số bản ghi trên một trang text
            currentPageSize: 20, //Tổng số bản ghi trên một trang number
            showListPage: false, // show ra list page size
            currentPageNum: 1, // Trang hiện tại
            itemActive: 0, // set class active cho list item selected
            toastContent: "ADD", // nội dung toast message
            toastTitle: "", // Tiêu đề toast,
            isErrorToast: false, // Icon toast lỗi
            isSuccessToast: true, // icon toast thành công
            pageTotal: 0, // tổng số bản ghi
            //pageSizeList: RESOURCES.PAGINATION, // mảng phân trang
        }
    },
    async created() {
        // Lấy ra 20 bản ghi đầu tiên
        await this.getProductFirst();
    },
    methods: {
        /**
    * author:Nguyễn Văn Ngọc(2/1/2023)
    * Hàm getEmployeesFirst lấy ra số nhân viên trang đầu tiên
    */
        async getProductFirst() {
            try {
                // show loading
                this.isShowLoading = true;
                HTTP.post(`/filter`, this.getFilterParams("", 100, 1)).then((res) => {
                    let productList = res.data.Data.filter(product => {
                        return product.IsActive == true
                    });
                    this.products = productList.filter(product=>{
                        console.log(product.CategoryId)
                        return product.CategoryId == "3623a44e-bfc3-4457-8416-91e5bb3ae14c"
                    });
                    this.totalPage = res.data.TotalPage;
                    this.isShowLoading = false;
                    this.pageTotal = res.data.TotalRecord;
                })
                    .catch(error => {
                        //this.handleExeption(error);
                    })
            } catch (error) {
                //this.handleExeption(error);
            }
        },
        /**
        * author:Nguyễn Văn Ngọc(8/1/2023)
        * Hàm clickCallback phân trang khi người dùng click vào số trang
        */
        clickCallback(pageNum) {
            try {
                this.isShowLoading = true;
                HTTP.post(
                    `/filter`,
                    this.getFilterParams("", this.currentPageSize, pageNum)
                ).then((res) => {
                    this.products = res.data.Data.filter(product => {
                        return product.IsActive == true
                    });
                    this.totalPage = res.data.TotalPage;
                    this.pageTotal = res.data.TotalRecord;
                    this.isShowLoading = false;
                });
                this.textSearch = "";
                this.currentPageNum = pageNum;
            } catch (error) {
                this.handleExeption(error);
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
        onAddCartItem(product) {
            // Lấy danh sách sản phẩm từ sessionStorage (nếu đã có)
            let cartItems = JSON.parse(sessionStorage.getItem('cartItems')) || [];

            // Thêm sản phẩm vào giỏ hàng
            cartItems.push(product);
            // Lưu lại danh sách sản phẩm vào sessionStorage
            sessionStorage.setItem('cartItems', JSON.stringify(cartItems));
            this.isShowToast = true;
            this.store.setCartItems();
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
.pagination {
    list-style: none;
}

.page-item {
    padding: 0 8px;
    margin: 0 4px;
}

.page-item.active {
    border: 1px solid #50b83c;
}

.prev-btn.disabled,
.next-btn.disabled {
    cursor: default !important;
    color: #9e9e9e;
}

.prev-btn.disabled {
    margin-right: 4px;
}

.next-btn.disabled {
    margin-left: 4px;
}
</style>