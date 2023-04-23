import { createApp } from 'vue'
import router from './router/index.js'
import App from './App.vue'
import BaseLoading from "../src/components/base/BaseLoading.vue";
import VueCarousel from 'vue-carousel';
import BaseToast from "../src/components/base/BaseToast.vue";
// import BaseButton from "../src/components/base/BaseButton.vue";
// import BaseCombobox from "../src/components/base/BaseCombobox.vue";

// app.component("BaseButton", BaseButton);
// app.component("BaseCombobox", BaseCombobox);

const app = createApp(App);
app.component("BaseToast", BaseToast);
app.component("BaseLoading", BaseLoading);
app.use(VueCarousel);
app.use(router).mount("#app");
