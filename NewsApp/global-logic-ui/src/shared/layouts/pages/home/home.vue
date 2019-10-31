<template>
  <div>
    <div class="dark-screen"></div>
    <!-- Header -->

      

    <div class="container content">
      <!-- Slider -->

      <div class="slider-wrap">
        <homeSlider :slidesNews='slidesNews'></homeSlider>
      </div>
      <!-- Business -->
      <card :sendedNews='scienceNewsHome' :category="'science'" :title="'Science'" :titleBorder="'c710a2'"></card>
      <!-- Entertainmenet -->
      <card :sendedNews='entertainmentNewsHome' :category="'entertainment'" :title="'Entertainment'" :titleBorder="'ff995e'"></card>
      <!-- Science -->
      <card :sendedNews='businessNewsHome' :category="'business'" :title="'Business'" :titleBorder="'10c7ba'"></card>
    </div>
  </div>
</template>

<script>
import card from './../../../components/card';
import newsService from './../../../services/news.service';
import homeSlider from './../../../components/home-slider';
import {mapGetters} from 'vuex'

export default {
  components: { 
    card,
    homeSlider
  },
  computed: mapGetters(['getNews']),
  data() {
    return {
      isShowSideMenu: false,
      slidesNews: [],
      entertainmentNewsHome: [],
      scienceNewsHome: [],
      businessNewsHome: [],
    };
  },
  beforeCreate() {
    newsService.getTopNews('pageSize=10&').then((res) => {
      let newsCol = 3;
      for (let i = 0; i < newsCol; i++) {
        if (res.data.articles[i].urlToImage) {
          this.slidesNews.push(res.data.articles[i]);
        } else {
          newsCol += 1;
          continue;
        }
      }
    })

    newsService.getData('entertainment', 1).then((res) => {
      let newsCol = 3;
      for (let i = 0; i < newsCol; i++) {
        if (res.data.articles[i].urlToImage) {
          this.entertainmentNewsHome.push(res.data.articles[i]);
        } else {
          newsCol += 1;
          continue;
        }
      }
    })

    newsService.getData('science', 1).then((res) => {
      let newsCol = 3;
      for (let i = 0; i < newsCol; i++) {
        if (res.data.articles[i].urlToImage) {
          this.scienceNewsHome.push(res.data.articles[i]);
        } else {
          newsCol += 1;
          continue;
        }
      }
    })

    newsService.getData('business', 1).then((res) => {
      let newsCol = 3;
      for (let i = 0; i < newsCol; i++) {
        if (res.data.articles[i].urlToImage) {
          this.businessNewsHome.push(res.data.articles[i]);
        } else {
          newsCol += 1;
          continue;
        }
      }
    })
  },
  // methods: mapActions(['getNewsForHomePage']),
  // async mounted () {
  //   this.getNewsForHomePage({limit: 3, category: 'science'})
  // },
  methods: {

    toggleMobileSideMenu() {
      this.isShowSideMenu = !this.isShowSideMenu;
    },
    next() {
      this.$refs.slick.next();
    },
    prev() {
      this.$refs.slick.prev();
    },
    reInit() {
      // Helpful if you have to deal with v-for to update dynamic lists
      this.$refs.slick.reSlick();
    },
  },
};
</script>

<style>
@import "../../../../../node_modules/slick-carousel/slick/slick.css";




/* Slick Slider */
.slick-slider {
  margin-top: 30px;
}
.slick-slider .slick-dots {
  display: none !important;
}
.slick-slider button.slick-prev,
.slick-slider button.slick-next:focus {
  outline: none;
}
.slick-slider button.slick-prev {
  position: absolute;
  top: -49px;
  right: 50px;
  color: transparent;
  background: transparent;
  border: none;
  width: 30px;
}
.slick-slider button.slick-prev::before {
  right: 8px;
  position: absolute;
  content: "";
  width: 10px;
  height: 10px;
  border-left: 2px solid #4e3535;
  border-bottom: 2px solid #4e3535;
  transform: rotate(45deg);
  top: 8px;
}
.slick-slider button.slick-next {
  position: absolute;
  top: -49px;
  right: 15px;
  color: transparent;
  background: transparent;
  border: none;
  width: 30px;
}
.slick-slider button.slick-next::before {
  position: absolute;
  content: "";
  width: 10px;
  height: 10px;
  border-right: 2px solid #4e3535;
  border-bottom: 2px solid #4e3535;
  transform: rotate(-45deg);
  top: 8px;
  left: 8px;
}
</style>

<style scoped>
/* Hide elements for mibile 
Subscribe : class = 'mobile-notify-prompt-wrap'
Dark Screen :  class = 'dark-screen'

Weather Menu : class = 'modile-side-weather-wrap'
*/

/* Notify */
.mobile-notify-prompt-wrap .text-wrap p {
  color: #eaeaea;
}
.mobile-notify-prompt-wrap .text-wrap p.dropdown {
  font-size: 22px;
  font-family: initial;
  margin-right: 10px;
  font-weight: bold;
}
.mobile-notify-prompt-wrap .send-email-wrap {
  display: inline-flex;
  flex-direction: column;
  margin-top: 10px;
}
.mobile-notify-prompt-wrap .button-wrap {
  margin-top: 23px;
}
.mobile-notify-prompt-wrap .email-wrap span {
  color: #eaeaea;
  display: block;
  width: 100%;
  border-bottom: 1px solid;
  text-align: start;
}
.mobile-notify-prompt-wrap .button-wrap button {
  width: 242px;
  height: 48px;
  background-color: #f8c61a;
  border: none;
  font-size: 16px;
  font-weight: bold;
  text-transform: uppercase;
  letter-spacing: 1px;
}
.mobile-notify-prompt-wrap .button-wrap button:hover {
  background-color: #ffe076;
}
.mobile-notify-prompt-wrap {
  /* display: none; */
  padding-bottom: 45px;
  border: 1px solid;
  background-color: #052962;
  z-index: 999;
}
.mobile-notify-prompt-wrap .close-wrap {
  position: relative;
}
.mobile-notify-prompt-wrap .close-wrap a {
  width: 18px;
  height: 18px;
  display: inline-block;
  position: absolute;
  top: 24px;
  right: 23px;
}
.mobile-notify-prompt-wrap .close-wrap a::before {
  position: absolute;
  content: "";
  width: 15px;
  height: 1px;
  background-color: white;
  top: 8px;
  right: 2px;
  transform: rotate(45deg);
}
.mobile-notify-prompt-wrap .close-wrap a::after {
  position: absolute;
  content: "";
  width: 15px;
  height: 1px;
  background-color: white;
  top: 8px;
  right: 2px;
  transform: rotate(-45deg);
}

.mobile-notify-prompt-wrap .wropdown-arrow {
  margin-left: 10px;
  font-size: 20px;
  font-size: 14px;
}
.mobile-notify-prompt-wrap .text-wrap p {
  color: #eaeaea;
  margin-bottom: 2px;
}
.mobile-notify-prompt-wrap .send-email-wrap {
  display: inline-flex;
  flex-direction: column;
  margin-top: 10px;
}
.mobile-notify-prompt-wrap .button-wrap {
  margin-top: 10px;
}
.mobile-notify-prompt-wrap .email-wrap span {
  color: #eaeaea;
  display: block;
  width: 100%;
  border-bottom: 1px solid;
  text-align: start;
}
.mobile-notify-prompt-wrap .button-wrap button {
  height: 32px;
  background-color: #f8c61a;
  border: none;
  font-size: 16px;
  font-weight: bold;
  text-transform: uppercase;
  letter-spacing: 1px;
}
.mobile-notify-prompt-wrap .button-wrap button:hover {
  background-color: #ffe076;
}

/* Weater Details */

</style>

<style scoped>

/* Common */
@media (min-width: 1140px) {
  .container {
    max-width: 1638px !important;
  }
}
@media (max-width: 1139px) {
  .container {
    max-width: 814px !important;
  }
}
</style>

<style>
/* Common */
.dark-screen {
  position: absolute;
  bottom: 0;
  top: 0;
  left: 0;
  right: 0;
  background-color: rgba(0, 0, 0, 0.5);
  background: rgba(0, 0, 0, 0.5);
  color: rgba(0, 0, 0, 0.5);
  z-index: 999999;
  display: none;
}

/* Common for Business, Entertainment, Science */
.elem-wrap {
  max-width: 526px;
}
.elem-wrap img {
  width: 100%;
}
.description-wrap {
  padding: 19px 0 10px 0;
  border-bottom: 2px solid #b3abab;
}
.creator-info {
  display: flex;
  justify-content: space-between;
  padding-top: 15px;
}
.description-wrap span {
  font-size: 16px;
  font-weight: bold;
}
.card-deck {
  margin-top: 30px;
}
.card-text {
  padding: 19px 0 10px 0;
  border-bottom: 2px solid #b3abab;
}
/* .card-footer {
  padding: 15px 0 0 0 !important;
  background-color: unset !important;
  display: flex;
  justify-content: space-between;
} */

/* .new-card {
  margin: 0 auto !important;
  max-width: 526px !important;
  border: none !important;
} */
/* .new-card img {
  width: 100%;
} */

/* .new-card .card-body {
  padding: 0 !important;
} */

/* Business */
.business-wrap {
  margin-top: 60px;
  text-align: start;
}
.business-wrap .title-wrap {
  border-left: 5px solid #c710a2;
}
.business-wrap .title-wrap .title-text {
  display: block;
  font-size: 32px;
  font-family: "Poppins";
  font-weight: bold;
  text-transform: uppercase;
  letter-spacing: 10px;
  padding: 6px 30px;
}

/* Entertainment */
.entertainment-wrap {
  margin-top: 60px;
  text-align: start;
}
.entertainment-wrap .title-wrap {
  border-left: 5px solid #ff995e;
}
/* Science */
.science-wrap {
  margin-top: 60px;
  text-align: start;
}
.science-wrap .title-wrap {
  border-left: 5px solid #10c7ba;
}
.science-wrap .title-wrap .title-text {
  display: block;
  font-size: 32px;
  font-family: "Poppins";
  font-weight: bold;
  text-transform: uppercase;
  letter-spacing: 10px;
  padding: 6px 30px;
}
/* Header */
.bottom-menu-wrap {
  height: 120px;
  display: flex;
  align-items: center;
}
.top-menu-wrap {
  background-color: #052962;
}
.bottom-menu {
  background-color: unset !important;
  justify-content: center !important;
}
.bottom-menu li a a {
  color: #3f3f3f;
  font-size: 26px;
  font-weight: bold;
  text-decoration: none;
}
.bottom-menu li a:hover {
  color: #f8c61a !important;
}
.top-menu-wrap .navbar-nav {
  width: 100%;
  display: flex;
  justify-content: space-between;
  align-items: center;
}
.top-menu-wrap .wide-menu li.weather-wrap {
  position: relative;
  display: flex;
  flex-direction: column;
}
.top-menu-wrap .wide-menu li.weather-wrap .weather-dropdown-arrow {
  position: absolute;
  top: 25px;
  right: -46px;
}
.top-menu-wrap .navbar-nav .wide-menu li.weather-wrap p {
  margin-bottom: 0;
}
.top-menu-wrap .navbar-nav li .nav-link {
  padding: 0 !important;
}
.top-menu-wrap .navbar-nav li a span {
  color: #f9f9f9;
}
.top-menu-wrap .navbar-nav li a {
  color: #f9f9f9;
}
.top-menu-wrap .navbar-nav li .nav-item {
  color: #f9f9f9;
}
.top-menu-wrap .navbar {
  background-color: #052962 !important;
  padding: 9px 0;
}
.top-menu-wrap .navbar-brand {
  padding: 0;
}
.top-menu-wrap .wide-menu .current-date a {
  display: flex;
  flex-direction: column;
}
.top-menu-wrap .weather-value {
  font-family: "Semibold";
  font-size: 28px;
}
.top-menu-wrap .weather-value .celsius-value {
  font-size: 20px;
  position: absolute;
}
@media (max-width: 1199px) {
  .bottom-menu ul li a span {
    font-size: 23px;
  }
}
@media (max-width: 991px) {
  .bottom-menu ul li a span {
    font-size: 17px;
  }

  /* .bottom-menu li a a{
    font-size:12px !important;
  } */
}
</style>

<style scoped>
/* Footer */
footer {
  background-color: #052962;
  margin-top: 72px;
}
footer .content-wrap {
  width: 100%;
  height: 100%;
  display: flex;
  justify-content: space-between;
}
footer .left-item,
footer .right-item {
  margin: auto 0;
}
footer .center-item {
  display: flex;
}
footer .center-item .text {
  color: white;
  display: flex;
  align-items: flex-end;
  padding-bottom: 5px;
  font-size: 10px;
}
/* footer .right-item button {
  width: 98% !important;
  width: 185px !important;
  height: 35px;
  font-size: 12px;
} */
footer .right-item button:hover {
  background-color: #ffe076 !important;
}

footer .right-item button {
  width: 242px;
  height: 48px;
  background-color: #f8c61a;
  color: #052962;
  font-size: 16px;
  text-transform: uppercase;
  font-weight: 900;
  border: none;
  letter-spacing: 1px;
}
@media (max-width: 1199px) {
  footer .right-item button {
    width: 232px !important;
    height: 44px;
  }
}
@media (max-width: 991px) {
  footer .right-item button {
    width: 222px !important;
    height: 40px;
    font-size: 14px;
  }
}
@media (min-width: 768px) {
  footer .container.content {
    height: 100px;
  }
}
@media (max-width: 767px) {
  footer {
    margin-top: 0px;
  }
  footer img {
    width: 100px;
  }
  footer .content-wrap {
    flex-direction: column;
    height: unset !important;
  }
  footer .content-wrap .center-item {
    margin: 0 auto;
  }
  footer .content-wrap :nth-child(2) {
    order: 3;
  }
  footer .content-wrap .left-item {
    padding: 20px 0;
  }
  footer .content-wrap .center-item {
    padding: 20px 0;
  }
}
</style>
