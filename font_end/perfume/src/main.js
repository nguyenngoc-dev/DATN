import { createApp } from 'vue'
import router from './router/index.js'
import App from './App.vue'
import 'vuetify/styles'
import { createVuetify } from 'vuetify'
import * as components from 'vuetify/components'
import * as directives from 'vuetify/directives'

const vuetify = createVuetify({
  components,
  directives,
})


const app = createApp(App);
app.use(vuetify);
app.use(router).mount("#app");
