<template>
<!-- Phân trang --> 
<div class="home grid">
    <div class="home-container flex row">
        <div class="col l-3 m-4 c-6 mb-24">
             <CardItem
            :urlImage="'https://nuochoa95.com/Data/images/san%20pham/Jimmy%20Choo/I-Want-Choo-Forever.jpg'"
            :title="'Nước hoa nam'"
            :price="'20000'"
        />
        </div>
        <div class="col l-3 m-4 c-6 mb-24">
             <CardItem
            :urlImage="'https://nuochoa95.com/Data/images/san%20pham/Jimmy%20Choo/I-Want-Choo-Forever.jpg'"
            :title="'Nước hoa nam'"
            :price="'20000'"
        />
        </div>
        <div class="col l-3 m-4 c-6 mb-24">
             <CardItem
            :urlImage="'https://nuochoa95.com/Data/images/san%20pham/Jimmy%20Choo/I-Want-Choo-Forever.jpg'"
            :title="'Nước hoa nam'"
            :price="'20000'"
        />
        </div>
        <div class="col l-3 m-4 c-6 mb-24">
             <CardItem
            :urlImage="'https://nuochoa95.com/Data/images/san%20pham/Jimmy%20Choo/I-Want-Choo-Forever.jpg'"
            :title="'Nước hoa nam'"
            :price="'20000'"
        />
        </div>
        <div class="col l-3 m-4 c-6 mb-24">
             <CardItem
            :urlImage="'https://nuochoa95.com/Data/images/san%20pham/Jimmy%20Choo/I-Want-Choo-Forever.jpg'"
            :title="'Nước hoa nam'"
            :price="'20000'"
        />
        </div>
    
        
    </div>
    
    
     <paginate
            :page-count="totalPage"
            :page-range="3"
            :margin-pages="1"
            :click-handler="clickCallback"
            :prev-text="'Trước'"
            :next-text="'Sau'"
            :prev-class="'prev-btn'"
            :next-class="'next-btn'"
            :container-class="'pagination'"
            :page-class="'page-item'"
            :v-show="this.totalPage"
          >
    </paginate>
    <BaseLoading v-if="false" />
</div>
       
</template>
<script>
import {HTTP} from "../js/api.js"
import CardItem from "../components/base/CardItem.vue";
import paginate from "vuejs-paginate/src/components/Paginate.vue";
export default {
    components: {
    paginate,
    CardItem
  },
    data() {
        return {
            products: [], // mảng hứng dữ liệu đổ vào bảng
            isShowDialog: false, // Show chi tiết nhân viên
            isShowLoading: false, // Show loading
            textSearch: "", // nội dung ô tìm kiếm
            productImageIdSelected:null,
            productIdSelected: null, // id của nhân viên khi click nút sửa
            productDelete:[],// mảng xóa một nhân viên
            productIdDelete: null, // lấy ra id khi xóa nhân viên
            productIdDuplicate: false, // lấy id nhân viên để nhân bản
            isShowToast: false, //show toast message
            totalPage: 1, // Tổng số trang
            //currentPageSizeText: RESOURCES.PAGINATION[0].text, // Tổng số bản ghi trên một trang text
            currentPageSize: 20, //Tổng số bản ghi trên một trang number
            showListPage: false, // show ra list page size
            currentPageNum: 1, // Trang hiện tại
            itemActive: 0, // set class active cho list item selected
            //toastContent: RESOURCES.FORM_MODE.DELETE, // nội dung toast message
            //toastTitle: RESOURCES.NOTIFICATION_TITLE.SUCCESS, // Tiêu đề toast,
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
        HTTP.post(`/filter`, this.getFilterParams("", 20, 1)).then((res) => {
          this.products = res.data.Data.filter(product => {
          return product.IsActive == true
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
    }

}
</script>
<style>
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
.prev-btn.disabled{
  margin-right: 4px;
}
.next-btn.disabled {
  margin-left: 4px;
}
</style>