<template>
  <div class="maincontent-area">
    <div class="zigzag-bottom"></div>
    <div class="container">
      <div class="row">
        <div class="col-md-12">
          
          <div class="latest-product">
            <h2 class="section-title">Sản phẩm mới nhất</h2>
            <div class="product-carousel">
              <div class="container"> 
            <div class="row">
              <div class="single-product single-shop-product homepage col-md-3 col-sm-6" v-for="(product, index) in products" :key="index">
                <div class="product-f-image product-upper">
                  <router-link :to="'/detail/' + product.ProductId">
                                <img :src="product.ImageUrl" alt="Lỗi ảnh">
                            </router-link>
                  <div class="product-hover">
                    <a href="#" class="add-to-cart-link" @click="onAddCartItem(product)">
                      <i class="fas fa-shopping-cart"></i> Thêm vào giỏ</a>
                        <router-link  class="view-details-link" :to="'/detail/' + product.ProductId">
                              Xem chi tiết
                        </router-link>
                  </div>
                </div>

                <h2> <router-link :to="'/detail/' + product.ProductId">
                                {{ product.ProductName }}
                            </router-link></h2>

                <div class="product-carousel-price">
                  <ins>{{ formatMoney(product.Price) }} </ins> <span style="color: red;"><del>{{ formatMoney(product.Price + product.Price * product.Discount / 100) }}</del></span>
                </div>
              </div>
             </div>
             </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div> <!-- End main content area -->

  <div class="product-widget-area">
    <div class="container">
      <div class="row">
        <div class="col-md-4">
          <div class="single-product-widget" >
            <h2 class="product-wid-title">Sản phẩm bán chạy</h2>
            <div class="single-wid-product" v-for="(product, index) in topSales" :key="index">
              <router-link :to="'/detail/' + product.ProductId">
                <img :src="product.ImageUrl" alt="" class="product-thumb">
              </router-link>              
              <h2><router-link :to="'/detail/' + product.ProductId">
                {{ product.ProductName }}
              </router-link></h2>
              <div class="product-wid-rating">
                <i class="fas fa-star"></i>
                <i class="fas fa-star"></i>
                <i class="fas fa-star"></i>
                <i class="fas fa-star"></i>
                <i class="fas fa-star"></i>
              </div>
              <div class="product-wid-price">
                <ins>{{ formatMoney(product.Price) }} </ins> <span style="color: red;"><del>{{ formatMoney(product.Price + product.Price * product.Discount / 100) }}</del></span>
              </div>
            </div>
          </div>
        </div>
        <div class="col-md-4">
          <div class="single-product-widget" >
            <h2 class="product-wid-title">Đã xem gần đây</h2>
            <div class="single-wid-product" v-for="(product, index) in recentList" :key="index">
              <router-link :to="'/detail/' + product.ProductId">
                <img :src="product.ImageUrl" alt="" class="product-thumb">
              </router-link>
              <h2><router-link :to="'/detail/' + product.ProductId">
                                {{ product.ProductName }}
                            </router-link></h2>
              <div class="product-wid-rating">
                <i class="fas fa-star"></i>
                <i class="fas fa-star"></i>
                <i class="fas fa-star"></i>
                <i class="fas fa-star"></i>
                <i class="fas fa-star"></i>
              </div>
              <div class="product-wid-price">
                <ins>{{ formatMoney(product.Price) }} </ins> <span style="color: red;"><del>{{ formatMoney(product.Price + product.Price * product.Discount / 100) }}</del></span>
              </div>
            </div>
          </div>
        </div>
        <div class="col-md-4">
          <div class="single-product-widget" >
            <h2 class="product-wid-title">Sản phẩm mới<i></i></h2>
            <div class="single-wid-product" v-for="(product, index) in newProduct" :key="index">
              <router-link :to="'/detail/' + product.ProductId">
                <img :src="product.ImageUrl" alt="" class="product-thumb">
              </router-link>
              <h2 style="max-width: 100%; overflow: hidden;"><router-link :to="'/detail/' + product.ProductId">
                                {{ product.ProductName }}
                            </router-link></h2>
              <div class="product-wid-rating">
                <i class="fas fa-star"></i>
                <i class="fas fa-star"></i>
                <i class="fas fa-star"></i>
                <i class="fas fa-star"></i>
                <i class="fas fa-star"></i>
              </div>
              <div class="product-wid-price">
                <ins>{{ formatMoney(product.Price) }} </ins> <span style="color: red;"><del>{{ formatMoney(product.Price + product.Price * product.Discount / 100) }}</del></span>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div> <!-- End product widget area -->

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
import { HTTP } from "../js/api.js"
import CardItem from "../components/base/CardItem.vue";
import paginate from "vuejs-paginate/src/components/Paginate.vue";
import {formatMoney} from "../js/common.js"

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
      topSales:[],
      recentList:[],
      newProduct:[],
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
      formatMoney
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
        HTTP.post(`/filter`, this.getFilterParams("", 20, 1)).then((res) => {
          this.products = res.data.Data.filter(product => {
            return product.IsActive == true
          });
          this.topSales = [this.products[5],this.products[6],this.products[7]];
          this.recentList = [this.products[4],this.products[8],this.products[10]];
          this.newProduct = [this.products[3],this.products[4],this.products[2]]
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
.product-f-image.product-upper {
  height: 89%;
}
.single-shop-product.homepage {
  height: auto;
}
</style>