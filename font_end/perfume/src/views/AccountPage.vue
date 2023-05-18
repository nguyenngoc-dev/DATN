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
                <div v-if="this.saleOrders.length" class="container">
                    <h1>Thông tin đơn hàng</h1>
                    <table>
                        <thead>
                            <tr>
                                <th>Mã đơn hàng</th>
                                <th>Tên khách hàng</th>
                                <th>Địa chỉ</th>
                                <th>Số điện thoại</th>
                                <th>Tình trạng</th>
                                <th>Tổng tiền</th>
                                <th>Chức năng</th>
                                <th>Hủy đơn</th>

                            </tr>
                        </thead>
                        <tbody>
                            <tr v-for="(orderDetail, index) in orderDetails" :key="index">
                                <td>{{ orderDetail.saleOrder.SaleOrderCode }}</td>
                                <td>{{ orderDetail.saleOrder.FirstName + ' ' + orderDetail.saleOrder.LastName }}</td>
                                <td>{{ orderDetail.saleOrder.CustomerAddress }}</td>
                                <td>{{ orderDetail.saleOrder.CustomerPhone }}</td>
                                <td>{{ formatStatus(orderDetail.saleOrder.Status) }}</td>
                                <td>{{ formatMoney(orderDetail.saleOrder.TotalPrice) }}</td>
                                <td @click="showOrderDetail(orderDetail)">Xem chi tiết</td>
                                <td @click="onShowCancelOrder(orderDetail)">Hủy</td>

                            </tr>
                        </tbody>
                    </table>
                    <div class="order-detail-dialog" v-if="isShowDetailOrder">
                        <div style="display: flex;
                                justify-content: space-between;
                                align-items: center;">
                            <h2 style=" margin: 0;
                                color: black;
                                margin-bottom: 12px;">Chi tiết đơn hàng</h2>
                            <div class="icon-close-container">
                                <div @click="onCloseOrderDetail()" class="icon-close"></div>
                            </div>
                        </div>

                        <table>
                            <thead>
                                <tr>
                                    <th>Mã sản phẩm</th>
                                    <th>Tên sản phẩm</th>
                                    <th>Ảnh sản phẩm</th>
                                    <th>Số lượng</th>
                                    <th>Đơn Giá</th>
                                    <th>Thành tiền</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr v-for="(orderItem, index) in orderItemArray.orderItems" :key="index">
                                    <td>{{ orderItem.product[0].ProductCode }}</td>
                                    <td>{{ orderItem.product[0].ProductName }}</td>
                                    <td> <img :src="orderItem.product[0].ImageUrl" alt=""> </td>
                                    <td>{{ orderItem.orderItem.Quantity }}</td>
                                    <td>{{ formatMoney(orderItem.orderItem.Price) }}</td>
                                    <td>{{ formatMoney(orderItem.orderItem.Price * orderItem.orderItem.Quantity) }}</td>
                                </tr>
                            </tbody>
                            <tfoot>
                                <tr>
                                    <td colspan="5"><strong>Tổng tiền:</strong></td>
                                    <td>{{ formatMoney(orderItemArray.saleOrder.TotalPrice) }}</td>
                                </tr>
                            </tfoot>
                        </table>
                    </div>


                </div>
                <div v-if="this.saleOrders.length == 0" class="order-empty">
                    Bạn chưa có đơn hàng nào!!!
                </div>
            </div>
            <div v-if="isCancel" class="cancel-order">
                <div style="display: flex;
                                justify-content: space-between;
                                align-items: center;">
                    <h2 style=" margin: 0;
                                color: black;
                                margin-bottom: 12px;">Lý do hủy đơn</h2>
                    <div class="icon-close-container">
                        <div @click="onCloseCancelOrder()" class="icon-close"></div>
                    </div>
                </div>
                <textarea rows="4" cols="120"  v-model="cancelSaleOrder.RejectReason"></textarea>
                <button style="margin-top: 16px;" @click="onCancelOrder()" class="add_to_cart_button">
                    Xác nhận hủy
                </button>
            </div>



        </div>
    </div>
    <BaseToast v-if="isShowToast" @closeToast="onhideToast" @onhideToast="onhideToast" :toastType="toastContent"
        :toastTitle="toastTitle" :isSuccessToast="isSuccessToast" :isErrorToast="isErrorToast" />
</template>
<script>
import { HTTPUsers, HTTPOrders, HTTPOrderItem, HTTP } from '../js/api';
import { formatMoney } from "../js/common.js"

export default {
    async created() {
        // Lấy danh sách sản phẩm từ sessionStorage (nếu đã có)
        let account = JSON.parse(sessionStorage.getItem('account')) || [];
        if (account.length) {
            // gọi api lấy dữ liệu truyền vào th employee
            const res = await HTTPUsers.get(`/${account[0]}`);
            this.user = res.data;

            const response = await HTTPOrders.get()
            let saleOrder = response.data;
            this.saleOrders = saleOrder.filter(item => item.UserId == account[0])
            this.saleOrders.forEach(item => {
                this.orderDetails.push({ saleOrder: item, orderItems: [] });
            })
            if (this.saleOrders.length) {
                const res = await HTTPOrderItem.get();
                let orderItem = res.data;
                orderItem.forEach(item => {
                    for (let i = 0; i < this.saleOrders.length; i++) {
                        if (item.SaleOrderId == this.saleOrders[i].SaleOrderId) {
                            this.orderItems.push(item);
                        }
                    }
                });
                this.orderDetails.forEach(orderDetail => {
                    this.orderItems.forEach(orderItem => {
                        if (orderDetail.saleOrder.SaleOrderId == orderItem.SaleOrderId) {
                            orderDetail.orderItems.push({ orderItem: orderItem, product: [] })
                        }
                    })
                })
                if (this.orderItems.length) {
                    for (let i = 0; i < this.orderItems.length; i++) {
                        const response = await HTTP.get(`/${this.orderItems[i].ProductId}`);
                        this.products.push(response.data)
                    }
                    //     const response = await HTTP.get();
                    //     let product = response.data;
                    //     this.products = product.filter(item => {
                    //     for(let i = 0; i< this.orderItems.length;i++) {
                    //         item.ProductId == this.orderItems[i].ProductId
                    //     }
                    //    })
                }
                this.orderDetails.forEach(orderDetail => {
                    orderDetail.orderItems.forEach(orderItem => {
                        this.products.forEach(product => {
                            if (orderItem.orderItem.ProductId == product.ProductId) {
                                orderItem.product.push(product)
                            }
                        })
                    })

                });

            }
        }
    },
    data() {
        return {
            user: {},
            account: {},
            cancelSaleOrder:{
                CancelReason:""
            },
            saleOrders: [],
            orderItems: [],
            products: [],
            orderDetails: [],
            orderItemArray: [],
            account: JSON.parse(sessionStorage.getItem('account')) || [],
            newPassword: "",
            repeatNewPassword: "",
            isShowToast: false,
            toastContent: "AUTHEN", // nội dung toast message
            toastTitle: "", // Tiêu đề toast,
            isErrorToast: false, // Icon toast lỗi
            isSuccessToast: true, // icon toast thành công
            isShowAccount: true,
            isShowOrder: false,
            isShowDetailOrder: false,
            formatMoney,
            isCancel: false,
        }
    },
    methods: {
        async onCancelOrder() {
            let isCancel = true;
            if(!this.cancelSaleOrder.RejectReason) {
                this.toastContent = "REASONCANCEL"
                this.isErrorToast = true;
                this.isShowToast = true;
                isCancel = false;
                return;
            }
            if(isCancel) {
                this.isShowLoading = true;
                this.cancelSaleOrder.Status = 3;
                const response =  await HTTPOrders.put(`/${this.cancelSaleOrder.SaleOrderId}`, this.cancelSaleOrder);
                const res = await HTTPOrderItem.get();

                let orderItem = res.data;
                let orderItems=[];
                orderItem.forEach(item => {
                    if (item.SaleOrderId == this.cancelSaleOrder.SaleOrderId) {
                        orderItems.push(item);
                    }
                });
                if (orderItems.length) {
                    for (let i = 0; i < orderItems.length; i++) {
                        const response = await HTTP.get(`/${orderItems[i].ProductId}`);
                        let updateProduct = response.data;
                        if(updateProduct) {
                            updateProduct.Quantity = updateProduct.Quantity + orderItems[i].Quantity;
                            updateProduct.QuantityPurchased = updateProduct.QuantityPurchased - orderItems[i].Quantity;
                            let formData = new FormData();
                            for(const product in updateProduct) {
                                formData.append(product, updateProduct[product]);
                            }
                            const response = await HTTP.put(`/${updateProduct.ProductId}`,formData);

                        }
                    }
                }

                this.toastContent = "CANCELSUCESS"
                this.isErrorToast = false;
                this.isShowToast = true;
                this.isShowLoading = false;
                this.isCancel = false;

            }


        },
        onCloseCancelOrder() {
            this.isCancel = false;
        },
        onShowCancelOrder(orderDetail) {
            if(orderDetail.saleOrder.Status == 0) {
                this.cancelSaleOrder = orderDetail.saleOrder;
                this.isCancel = true;
            }
            else {
                this.toastContent = "FAILCANCEL"
                this.isErrorToast = true;
                this.isShowToast = true;
            }
        },
        onCloseOrderDetail() {
            this.isShowDetailOrder = false;

        },
        showOrderDetail(OrderDetail) {
            this.isShowDetailOrder = true;
            this.orderItemArray = OrderDetail;
        },
        formatStatus(status) {
            if (status == 1) {
                return "Đang giao hàng"
            }
            else if (status == 2) {
                return "Giao thành công"
            }
            else if (status == 3) {
                return "Đơn hàng bị hủy"
            }
            else {
                return "Đang chuẩn bị hàng"
            }
        },
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
    min-height: 400px;
    max-width: 1060px;
    margin: 0 auto;
    padding: 20px;
}

.sale-order-container table {
    border-collapse: collapse;
    width: 100%;
}

.sale-order-container th,
td {
    border: 1px solid #ddd;
    padding: 8px;
}

.sale-order-container th {
    padding-top: 12px;
    padding-bottom: 12px;
    color: white;
    background-color: var(--primary-color);
    text-align: center;
}

.sale-order-container tr {
    cursor: pointer;
    min-height: 40px;
}

.sale-order-container tr::nth-child(even) {
    background-color: #f2f2f2;
}

.sale-order-container tr:hover {
    background-color: #ddd;
}

.sale-order-container img {
    max-width: 100px;
    height: auto;
}

.sale-order-container .order-info p {
    margin-bottom: 10px;
}

.order-empty {
    min-height: 200px;
    margin-top: 100px;
    font-size: 20px;
}
.cancel-order {
    position: fixed;
    background: white;
    padding: 20px;
    left: 50%;
    top: 50%;
    transform: translate(-50%, -50%);
    width: 1000px;
    min-width: 700px;
    border-radius: 5px;
    border: 1px solid #ccc;
    z-index: 1000;
}
.order-detail-dialog {
    position: fixed;
    background: white;
    padding: 20px;
    left: 50%;
    top: 50%;
    transform: translate(-50%, -50%);
    min-width: 700px;
    border-radius: 5px;
    border: 1px solid #ccc;
    z-index: 1000;
}

.order-detail-dialog .icon-close-container {
    display: flex;
    justify-content: flex-end;
    margin-bottom: 12px;
}
</style>