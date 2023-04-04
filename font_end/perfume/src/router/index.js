import { createRouter, createWebHistory } from "vue-router";
import ManPerfume from "../views/ManPerfume.vue"


const routes = [
  { path: "/man", component: ManPerfume },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;