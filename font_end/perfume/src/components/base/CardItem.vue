<template>
    <div class="card-item-container"> 
        <router-link to="/cart" class="card-item-container-cart">
            <i class="fas fa-shopping-basket fs-20 "></i>
        </router-link>
        <router-link to="/detail">
            <div class="card-item-img-container">
                <img class="card-item-img" :src="urlImage" alt="Lỗi ảnh">
                <div class="mask"></div>

            </div>
        </router-link>

        <div class="card-item-bottom flex">
            <router-link to="/detail">
                <div class="card-item-title">
                    {{ title }}
                </div>
            </router-link>
            <div class="card-item-price">
                {{ price }} vnđ
            </div>
        </div>
    </div>
</template>
<script>
export default {
    data: () => ({
        show: false,
    }),
    props: {
        urlImage: String,
        title: String,
        price: String
    }
}
</script>
<style>
@import "../../assets/font/fontawesome-5.15.1/css/all.min.css";
</style>