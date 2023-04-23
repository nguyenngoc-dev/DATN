<template>
  <div class="footer-top-area">
    <div class="zigzag-bottom"></div>
    <div class="container">
      <div class="row">
        <div class="col-md-3 col-sm-6">
          <div class="footer-about-us">
            <h2>N<span>gocNguyen</span></h2>
            <div class="footer-menu">
              <ul>
                <li><a href="#">Địa chỉ : 21/24 Đình Đông, Lê Chân, Hải Phòng
                    ( đi vào ngõ 24 rẽ phải, nhà số 21 )</a></li>
                <li><a href="#">Điện thoại : 0388007336</a></li>
                <li><a href="#">Zalo : 0968892487</a></li>
                <li><a href="#">Số Giấy Phép ĐKKD : 02C8006806</a></li>
              </ul>
            </div>
            <div class="footer-social">
              <a href="#" target="_blank"><i class="fab fa-facebook"></i></a>
              <a href="#" target="_blank"><i class="fab fa-twitter"></i></a>
              <a href="#" target="_blank"><i class="fab fa-youtube"></i></a>
              <a href="#" target="_blank"><i class="fab fa-linkedin"></i></a>
            </div>
          </div>
        </div>

        <div class="col-md-3 col-sm-6">
          <div class="footer-menu">
            <h2 class="footer-wid-title">Hướng dẫn </h2>
            <ul>
              <li><a href="#">Chính sách bảo mật thông tin</a></li>
              <li><a href="#">Chính sách giao, nhận hàng và kiểm hàng</a></li>
              <li><a href="#">Chính sách bảo hành - Đổi trả</a></li>
              <li><a href="#">Chính sách thanh toán</a></li>

            </ul>
          </div>
        </div>

        <div class="col-md-3 col-sm-6">
          <div class="footer-menu">
            <h2 class="footer-wid-title">Tổng đài hỗ trợ</h2>
            <ul>
              <li><a href="#">Mua hàng: 0388007336</a></li>
              <li><a href="#">CSKH 1: 0969380736</a></li>
              <li><a href="#">CSKH 2: 0971808681
                </a></li>
            </ul>
          </div>
        </div>

        <div class="col-md-3 col-sm-6">
          <div class="footer-newsletter">
            <h2 class="footer-wid-title">Liên hệ</h2>
            <p>Kết nối với chúng tôi</p>
            <div class="newsletter-form">
              <form action="#">
                <input type="email" placeholder="Type your email">
                <input type="submit" value="Đăng kí">
              </form>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div> <!-- End footer top area -->
</template>
<script>
export default {
  data: () => ({
    icons: [
      'fab fa-facebook-f',
      'fab fa-instagram',
      'fab fa-youtube',
      'fab fa-twitter',
    ],
  }),
}
</script>
<style >
@import "../../assets/font/fontawesome-5.15.1/css/all.min.css";
</style>