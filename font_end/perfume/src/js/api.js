
import axios from "axios";

export const HTTP = axios.create({
  baseURL: "https://localhost:44314/api/v1/Products",
});

export const HTTPCategorys = axios.create({
  baseURL: "https://localhost:44314/api/v1/Categorys",
});
export const HTTPProductImages = axios.create({
  baseURL: "https://localhost:44314/api/v1/ProductImages",
});
export const HTTPOrders = axios.create({
  baseURL: "https://localhost:44314/api/v1/SaleOrders",
});
export const HTTPUsers = axios.create({
  baseURL: "https://localhost:44314/api/v1/Users",
});
export const HTTPDelivery = axios.create({
  baseURL: "https://localhost:44314/api/v1/Deliveries",
});