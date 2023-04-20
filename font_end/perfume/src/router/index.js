import { createRouter, createWebHistory } from "vue-router";
import ManPerfume from "../views/ManPerfume.vue"
import HomePage from "../views/HomePage.vue"
import CartPage from "../views/CartPage.vue"
import WomenPage from "../views/WomenPage.vue"
import UnisexPage from "../views/UnisexPage.vue"
import LoginPage from "../views/LoginPage.vue"
import RegisterPage from "../views/RegisterPage.vue"
import NewsPage from "../views/NewsPage.vue"
import ContactPage from "../views/ContactPage.vue"
import DetailItem from "../views/DetailItem.vue"


const routes = [
  { path: "/man", component: ManPerfume },
  { path: "/", component: HomePage },
  { path: "/cart", component: CartPage },
  { path: "/women", component: WomenPage },
  { path: "/unisex", component: UnisexPage },
  { path: "/login", component: LoginPage },
  { path: "/register", component: RegisterPage },
  { path: "/news", component: NewsPage },
  { path: "/contact", component: ContactPage },
  { path: "/detail", component: DetailItem },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;