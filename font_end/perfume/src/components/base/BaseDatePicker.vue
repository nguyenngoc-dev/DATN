<template>
  <DatePicker
    style="min-width: 166px;padding: 0px;border: 0px;"
    class="textfield__input "
    :enable-time-picker="false"
    v-model="date"
    :disabled-dates="disabledDate"
    @update:modelValue="changeDateValue"
    :config="options"
    locale="vi"
    now-button-label="Hôm nay"
    text-input
    :ref="dateName"
    auto-apply
    close-on-scroll
    show-now-button
    :format="formatDate"
    :day-names="['T2', 'T3', 'T4', 'T5', 'T6', 'T7', 'CN']"
  >
    <template #dp-input="{ value }">
      <div class="date-picker__wrapper">
        <input
          :class="{
            'textfield__input':true, 
            'modal-textfield__input': true,
            'textfield--error-input': isErrorInput}"
          style="min-width: 166px; width: 166px;position:relative"
          type="text"
          placeholder="DD/MM/YYYY"
          :ref="name"
          :name="name"
          :value="value"
          autocomplete="off"
          :tabindex="tabIndex"
          @blur="blurInputValue"
          @input="onInputValue"
        />
        <p class="text-error">{{ errorMsg}}</p>

        <p class="date-picker__icon">
          <i></i>
        </p>
      </div>
    </template>

  </DatePicker>
</template>
<script>
import {inputValidation,formatDate} from "../../js/base/common.js"
import DatePicker from '@vuepic/vue-datepicker';
import '@vuepic/vue-datepicker/dist/main.css';

export default {
  name: "BaseDatePicker",
  emits: ["errorInputMessage","update:modelValue"],
  components: {
    DatePicker
  },
  data() {

    return {
      date: this.modelValue,
      options: {
        format: "DD/MM/YYYY",
        useCurrent: false,
      },
    };
  },
  props: {
    isErrorInput:Boolean,
    name: {
      type: String,
    },
    errorMsg: {
      type: String,
    },
    rules: {
      type: Array,
      default: new Array(0),
    },
    tabIndex : Number,
    modelValue: [String,Date],
    dateName:String
  },
  methods: {
    /**
     * Truyền sự kiện date thay đổi
     * Author : Nguyễn Văn Ngọc (05/1/2023)
     */
    changeDateValue(date) {
      this.$emit("update:modelValue", date, this.name);
      this.$refs[this.dateName].closeMenu();
    },
    /**
     * Check vaidate theo rules truyền vào
     * Author : Nguyễn Văn Ngọc (05/1/2023)
     */
    checkValidate() {
      if (this.rules.length > 0) {
        var msgErrorInput =  inputValidation(
          this.rules,
          this.name,
          this.modelValue
        );
        this.$emit("errorInputMessage", this.name, msgErrorInput);
      }
    },
    /**
     * Xử lý khi blur input
     * Author : Nguyễn Văn Ngọc (05/1/2023)
     */
    blurInputValue(event){
       if(this.isValidDate(event)){
        const newDate = new Date(event.target.value.split('/').reverse().join('-'));
        this.$emit('update:modelValue',newDate, this.name);
       }else{
        this.date= null;
        this.$refs[this.name] = "";
        this.$emit('update:modelValue',undefined, this.name);
       }
      //  this.$refs[this.dateName].closeMenu();
    }, 
    /**
     * Xử lý khi nhập input
     * Author : Nguyễn Văn Ngọc (05/1/2023)
     */
    onInputValue(event) {
      if(this.isValidDate(event)){
        const newDate = new Date(event.target.value.split('/').reverse().join('-'));
        this.$emit('update:modelValue',newDate, this.name);
        }
    },
      /**
     * Check date hợp lệ
     * Author : Nguyễn Văn Ngọc (05/1/2023)
     */
    isValidDate(event) {
      var propertyName = this.dateName;
      var value = event.target.value;
      const dateRegex =/^([1-9]|[0-2][0-9]|3[0-1])\/([1-9]|0[1-9]|1[0-2])\/[1-2][0-9][0-9][0-9]$/;
      return dateRegex.test(value)
    },
     /**
     * Disable ngày lớn hơn ngày hiện tại
     * Author: Nguyễn Văn Ngọc (10/2/2023)
     */

    disabledDate(time) {
      return time.getTime() > Date.now();
    },
       /**
     * author:Nguyễn Văn Ngọc(2/1/2023)
     * Focus vào ô input
     */
    onFocus() {
      this.$refs[this.name].focus();
    },
  },
  watch: {
    /**
     * Truyền modelValue thay đổi
     * Author : Nguyễn Văn Ngọc (05/1/2023)
     */
    modelValue: function () {
      this.date = this.modelValue;
    },
    // date: {
    //   handler: function() {
    //     this.$emit("update:modelValue", this.date, this.name);
    //   },
    //   immediate:true
    // }
  },
  computed: {
    /**
     * Format date
     * Author : Nguyễn Văn Ngọc (05/1/2023)
     */
    formatDate() {
      return formatDate(this.modelValue);
    },

  },
};
</script>
<style scoped>
@import "../../css/components/datepicker.css";
</style>
