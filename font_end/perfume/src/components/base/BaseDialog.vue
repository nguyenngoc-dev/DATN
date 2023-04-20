<template>
  <div id="dialog--warring" class="dialog">
    <div class="flex w-full" style="justify-content: center; height: 100%">
      <div class="dialog__content">
        <div :class="{ flex: true, 'dialog-content__header': true }">
          <span  class="dialog-header__title">{{
            dialogHeader
          }}</span>
          <div
           
            @click="$emit('onHideDialog')"
            class="icon w-h-24 dialog__btn--acept dialog__header-icon"
          ></div>
        </div>
        <div
          :class="{
            'dialog-content__container': true,
            
          }"
        >
          <li class="flex dialog-mgs">
            <div
              v-if="isQuestion"
              class=" icon-question"
            ></div>
            {{ questionMessage }}
            <div
              v-if="isNotice"
              class=" icon-dialog-notice"
            ></div>
            {{ errorMessage }}
            <div
              v-if="isDelete"
              :class="{'icon-warning-dialog':isDelete,'icon-question':isQuestion}"
            ></div>
            {{ dialogTitle }}
          </li>
        </div>
        <div
          :class="{
            'flex':true,
            'dialog-content__footer': isNotice,
            'dialog-warring-footer': isDelete,
            'space-beetween':showBtnChangeVal
          }"
            
        >
          <button
            v-if="showBtnCancel"
            @click="$emit('onHideDialog')"
            id="btn-dialog-delete--close"
            class="btn btn-secondary btn-dialog--close"
            style="margin-right:8px"
          >
            {{btnCancelText}}
          </button>
          <div class="dialog-warring-footer-end">
          <button
            v-if="showBtnChangeVal"
            @click="$emit('onHideEmpDetail')"
            id="btn-dialog-delete--close"
            class="btn btn-secondary btn-dialog--close"
            
          >
            Không
          </button>
           <button
            style="margin-left:8px"
            v-if="showBtnChangeVal"
            @click="$emit('onSaveBtn')"
            id="btn-dialog-delete--close"
            class="btn btn-primary btn-dialog--close"
          >
           có
          </button>
          </div>
          <button
            v-if="isDelete "
            @click="$emit('onBtnAccept')"
            id="btn-delete-yes"
            class="btn btn-primary btn-delete"
          >
            Có
          </button>
          <button
            v-if="isNotice"
            @click="$emit('onHideDialog')"
            class="btn btn-primary dialog__btn--acept"
          >
            Đồng ý
          </button>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  emits: ["onHideDialog", "onBtnAccept","onHideEmpDetail","onSaveBtn"],
  props: {
    errorMessage: String,
    dialogTitle: String,
    questionMessage: String,
    btnCancelText:String,
    dialogHeader:String,
    isNotice: {
      default: false,
      type: Boolean,
    },
    isDelete: {
      default: true,
      type: Boolean,
    },
    isQuestion: {
      default: false,
      type: Boolean,
    },
    showBtnCancel: {
      default:true,
      type:Boolean
    },
    showBtnChangeVal: {
      default:false,
      type:Boolean
    }
  },
  data() {
    return {
      isShowDialog: true,
    };
  },
  method: {},
};
</script>
<style scoped>
</style>