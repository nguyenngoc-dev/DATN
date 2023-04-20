import { createApp } from 'vue'
import router from './router/index.js'
import App from './App.vue'
import 'vuetify/styles'
import { createVuetify } from 'vuetify'
import * as components from 'vuetify/components'
import * as directives from 'vuetify/directives'
import BaseLoading from "../src/components/base/BaseLoading.vue";
// import BaseToast from "../src/components/base/BaseToast.vue";
// import BaseButton from "../src/components/base/BaseButton.vue";
// import BaseCombobox from "../src/components/base/BaseCombobox.vue";

// app.component("BaseToast", BaseToast);
// app.component("BaseButton", BaseButton);
// app.component("BaseCombobox", BaseCombobox);
const vuetify = createVuetify({
  components,
  directives,
})


const app = createApp(App);
app.component("BaseLoading", BaseLoading);
app.use(vuetify);
app.use(router).mount("#app");
