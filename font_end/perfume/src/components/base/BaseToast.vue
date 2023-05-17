<template>
<div
		class="toast"
		:class="{
			'toast--success': isSuccessToast,
			'toast--error':isErrorToast
		}"
	>
		<p class="toast__icon">
			<i class="toast__icon__img"></i>
		</p>
		<div class="toast__content">
			<p class="toast__content__title">
				{{toastTitle}}
			</p>
			<p class="toast__content__text">{{toastContent}}</p>
		</div>
		<div class="toast__action">
			<p class="toast__action_close" @click="$emit('closeToast')">
				<i class="toast__action_close__img"></i>
			</p>
		</div>
	</div>
</template>
<script>
import RESOURCES from "../../js/resouce.js";
export default {
  emits:["closeToast","onhideToast"],
  data() {
	return {
		toastContent:"",// Nội dung toast
	}
  },
  props:{
    toastType:String,
	toastTitle:{
		default:'Thành công!',
		type: String
	},
	isSuccessToast:{
		default:true,
		type: Boolean
	},
	isErrorToast: {
		default:false,
		type: Boolean
	}

  },
  mounted() {
	// eslint-disable-next-line
	 setTimeout(() => {
        this.$emit("onhideToast");
    }, 2000);
  },
  methods: {
	changeToastContent() {
		switch(this.toastType){
			case RESOURCES.FORM_MODE.ADD:
				this.toastContent = RESOURCES.FORM_MESSAGE.SUCCESS.ADD
				break;
			case RESOURCES.FORM_MODE.CANCELSUCESS:
				this.toastContent = RESOURCES.FORM_MESSAGE.SUCCESS.CANCELSUCESS
				break;
			case RESOURCES.FORM_MODE.EDIT:
				this.toastContent = RESOURCES.FORM_MESSAGE.SUCCESS.EDIT
				break;
			case RESOURCES.FORM_MODE.DELETE:
				this.toastContent = RESOURCES.FORM_MESSAGE.SUCCESS.DELETE
				break;
			case RESOURCES.FORM_MODE.ERROR:
				this.toastContent = RESOURCES.FORM_MESSAGE.ERROR.AUTHEN
				break;
			case RESOURCES.FORM_MODE.FAILCANCEL:
				this.toastContent = RESOURCES.FORM_MESSAGE.ERROR.FAILCANCEL
				break;
			case RESOURCES.FORM_MODE.AUTHEN:
				this.toastContent = RESOURCES.FORM_MESSAGE.SUCCESS.AUTHEN
				break;
			case RESOURCES.FORM_MODE.SREGIS:
				this.toastContent = RESOURCES.FORM_MESSAGE.SUCCESS.SREGIS
				break;
			case RESOURCES.FORM_MODE.ORDERSUCCESS:
				this.toastContent = RESOURCES.FORM_MESSAGE.SUCCESS.ORDERSUCCESS
				break;
			case RESOURCES.FORM_MODE.UPDATEAUTH:
				this.toastContent = RESOURCES.FORM_MESSAGE.SUCCESS.UPDATEAUTH
				break;
			case RESOURCES.FORM_MODE.DUPLICATE:
				this.toastContent = RESOURCES.FORM_MESSAGE.ERROR.DUP_AUTHEN
				break
			case RESOURCES.FORM_MODE.REASONCANCEL:
				this.toastContent = RESOURCES.FORM_MESSAGE.ERROR.REASONCANCEL
				break
			case RESOURCES.FORM_MODE.NEEDBUY:
				this.toastContent = RESOURCES.FORM_MESSAGE.ERROR.NEEDBUY
				break;
			case RESOURCES.FORM_MODE.LOGREQ:
				this.toastContent = RESOURCES.FORM_MESSAGE.ERROR.LOGREQ
				break;
			case RESOURCES.FORM_MODE.MATCH:
				this.toastContent = RESOURCES.FORM_MESSAGE.ERROR.MATCH
				break;
			case RESOURCES.FORM_MODE.EMPTY:
				this.toastContent = RESOURCES.FORM_MESSAGE.ERROR.EMPTY
				break;
			case RESOURCES.FORM_MODE.OVERFLOW:
				this.toastContent = RESOURCES.FORM_MESSAGE.ERROR.OVERFLOW
				break;
		}
		
	}
  },
  created() {
	this.changeToastContent()
  }
};
</script>
<style scoped>
</style>