<template>
  <button
    :class="{
      btn: true,
      'btn-primary': isprimary,
      'dialog__btn--acept': true,
      'btn-secondary': isSecondary,
      'tooltip':isShowTooltip
    }"
    :name="name"
    :ref="name"
  >
    {{ btnText }}
    <span v-show="isShowTooltip" style="top: 117%;padding: 0;font-weight: 100;width: 160%;left: 25%;" class="tooltiptext"
      >{{tooltipContent}}</span
    >
  </button>
</template>
<script>
export default {
  props: {
    name:String,
    isprimary: {
      type: Boolean,
      default: true,
    },
    isSecondary: {
      type: Boolean,
      default: false,
    },
    btnText: String,
    isShowTooltip: {
       type: Boolean,
      default: false,
    },
    tooltipContent:String

  },
  methods: {
     /**
     * author:Nguyễn Văn Ngọc(2/1/2023)
     * Focus vào button
     */
    onFocus() {
      this.$refs[this.name].focus();
    },
  }
};
</script>
<style scoped>
</style>