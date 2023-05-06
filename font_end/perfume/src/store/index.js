import { reactive, readonly} from 'vue';

const state = reactive({
    account: JSON.parse(sessionStorage.getItem('account')) || [],
    cartItems:JSON.parse(sessionStorage.getItem('cartItems')) || []
})

const clearAccount = () => {
    state.account = [];
}
const setAccount = () => {
    state.account = JSON.parse(sessionStorage.getItem('account')) || [];
}
const setCartItems = () => {
    state.cartItems = JSON.parse(sessionStorage.getItem('cartItems')) || [];
}
const clearCartItems = () => {
    state.cartItems = [];
}

export default {state: readonly(state), clearAccount,setAccount,clearCartItems,setCartItems};