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
import RESOURCES from "../../js/base/resouce.js";
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
			case RESOURCES.FORM_MODE.EDIT:
				this.toastContent = RESOURCES.FORM_MESSAGE.SUCCESS.EDIT
				break;
			case RESOURCES.FORM_MODE.DELETE:
				this.toastContent = RESOURCES.FORM_MESSAGE.SUCCESS.DELETE
				break;
			case RESOURCES.FORM_MODE.ERROR:
				this.toastContent = RESOURCES.FORM_MESSAGE.ERROR.ERRORSERVER
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