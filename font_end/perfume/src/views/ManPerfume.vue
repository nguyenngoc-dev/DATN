<template>
   <v-container >
    <v-row no-gutters >
      <v-col cols="4" order="last" v-for="item in items" :key="item">
        <v-sheet class="pa-2 ma-2">
            <CardItem
            :urlImage="item.url"
            :title="item.title"
            :price="item.price"
            ></CardItem>
        </v-sheet>
      </v-col>
    </v-row>
  </v-container>
</template>
<script>
import CardItem from '../components/base/CardItem.vue';
export default {
    components: {
        CardItem
    },
    data() {
        return {
            items: [
                {
                    url: "https://nuochoa95.com/Data/images/san%20pham/Parfums%20de%20Marly/Parfums-De-Marly-Delina-Eau-De-Parfum.jpg",
                    title:"Nước hoa Nam 1",
                    price:"12000000 vnđ"
                },
                {
                    url: "https://nuochoa95.com/Data/images/san%20pham/AFNAN%20PERFUMES/afnan-9am-edp.jpg",
                    title:"Nước hoa Nam 2",
                    price:"12000000 vnđ"
                },
                {
                    url: "https://nuochoa95.com/Data/images/san%20pham/Jean%…Gaultier/jean-paul-gaultier-scandal-le-parfum.jpg",
                    title:"Nước hoa Nam 3",
                    price:"12000000 vnđ"
                }
            ]
        }
    }
}
</script>