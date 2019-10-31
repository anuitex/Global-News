<template>
  <div class="header-wrap">
    <div class="header-content">
      <div class="top-menu-wrap">
        <div class="container">
          <b-navbar class="top-menu" toggleable="md" type="dark" variant="info">
            <b-nav class="mobile-top-menu">
              <b-navbar-toggle target="nav-collapse" @click="toggleMobileSideMenu()"></b-navbar-toggle>
              <b-nav-item class="mobile-logo-wrap" @click="goToHomePage()">
                <img src="../../../assets/images/logo.svg" alt="logo" />
              </b-nav-item>
              <b-nav-item class="mobnile-search-wrap">
                <font-awesome-icon icon="search" class="fa-lg" />
              </b-nav-item>
            </b-nav>

            <div
              id="nav-collapse"
              class="showTest"
              v-bind:class="{ sideMenuActive: isShowSideMenu }"
            >
              <div class="sub-wrap">
                <b-navbar-nav class="wide-menu">
                  <b-nav-item class="close-link-wrap">
                    <div class="close-wrap" @click="toggleMobileSideMenu()">
                      <a href="#"></a>
                    </div>
                  </b-nav-item>
                  <b-nav-item href="#" class="logo-wrap" @click="goToHomePage()">
                    <img src="../../../assets/images/logo.svg" alt="logo" />
                  </b-nav-item>
                  <b-nav-item href="#" class="current-date">
                    <span>{{currentDate.day}} {{currentDate.month}}, {{currentDate.year}}</span>
                    <span>{{currentDate.weekDay}}</span>
                  </b-nav-item>
                  <b-nav-item href="#" class="converter-wrap" @click="toggleConverterModal()">
                    <span>
                      <span>Currency Converter</span>
                      <font-awesome-icon icon="caret-down" />
                    </span>

                    <converterDesctop :isShowConverter="isShowConverter"></converterDesctop>
                  </b-nav-item>
                  <b-nav-item href="#" class="weather-wrap">
                    <span class="weather-content" @click="toggleWeatherModal()">
                      <span class="weather-icon">
                        <img :src="currentWeatherImg" alt />
                      </span>

                      <span class="weather-value">
                        {{ temp }}
                        <span class="celsius-value">&#8451;</span>
                      </span>
                      <span class="weather-dropdown-arrow">
                        <font-awesome-icon icon="caret-down" />
                      </span>

                      <div class="location-name">
                        <p>{{ location }}</p>
                      </div>
                    </span>
                    <weatherDesctop
                      :weatherData="weatherData"
                      @closeWeatherModal="closeWeatherModal"
                      :isShowWeatherModal="isShowWeatherModal"
                    ></weatherDesctop>
                  </b-nav-item>
                  <li class="nav-item search-wrap">
                    <div>
                      <a href="#">
                        <input class="search-input" />
                        <span class="icon-wrap">
                          <font-awesome-icon icon="search" class="fa-lg" />
                        </span>
                      </a>
                    </div>
                    <div class="bell active" @click="showSubscribeFullFun()">
                      <a href="#">
                        <font-awesome-icon icon="bell" class="fa-lg" />
                      </a>
                    </div>
                    <subscribeDesctop :showSubscribeFull="showSubscribeFull"></subscribeDesctop>
                  </li>
                </b-navbar-nav>
                <b-navbar-nav class="mobile-side-menu">
                  <b-nav-item class="close-link-wrap">
                    <div class="close-wrap" @click="toggleMobileSideMenu()">
                      <a class="close-button" href="#"></a>
                    </div>
                  </b-nav-item>
                  <b-nav-item href="#" class="wrap">
                    <div class="top-side-wrap">
                      <span class="sub-item">
                        Currency Converter
                        <font-awesome-icon icon="caret-down" />
                      </span>
                      <span class="sub-item">
                        Weather
                        <font-awesome-icon icon="caret-down" />
                      </span>
                    </div>
                  </b-nav-item>
                  <b-nav-item href="#">
                    <div class="bottom-side-wrap">
                      <div class="sub-item date">
                        <span>October 8, 2019</span>
                        <span>Tuesday</span>
                      </div>
                      <div class="sub-item">
                        <button>Subscribe Us</button>
                      </div>
                    </div>
                  </b-nav-item>
                </b-navbar-nav>
              </div>
            </div>
          </b-navbar>

          <moreWeather></moreWeather>
        </div>
      </div>

      <navigationDesctop></navigationDesctop>
    </div>
  </div>
</template>

<script>
import weatherDesctop from "./../../components/weather";
import subscribeDesctop from "./../../components/subscribe";
import navigationDesctop from "./../../components/navigation";
import converterDesctop from "./../../components/converter";
import moreWeather from "./../../components/more-weather";

export default {
  name: "HeaderDesctop",
  props: ["weatherData"],
  components: {
    weatherDesctop,
    subscribeDesctop,
    navigationDesctop,
    converterDesctop,
    moreWeather
  },
  data() {
    return {
      isShowSideMenu: false,
      isShowWeatherModal: false,
      isShowConverter: false,
      showSubscribeFull: false,
      temp: "",
      location: "",
      currentWeatherImg: "",
      weekdays: [
        "Sunday",
        "Monday",
        "Tuesday",
        "Wednesday",
        "Thursday",
        "Friday",
        "Saturday"
      ],
      months: [
        "January",
        "February",
        "March",
        "April",
        "May",
        "June",
        "July",
        "August",
        "September",
        "October",
        "November",
        "December"
      ],
      date: "",
      currentDate: {
        day: "",
        weekDay: "",
        month: "",
        year: ""
      }
    };
  },
  methods: {
    toggleMobileSideMenu() {
      this.isShowSideMenu = !this.isShowSideMenu;
    },

    toggleWeatherModal() {
      this.isShowWeatherModal = !this.isShowWeatherModal;
    },

    toggleConverterModal() {
      this.isShowConverter = !this.isShowConverter;
    },

    closeWeatherModal() {
      this.isShowWeatherModal = false;
    },

    showSubscribeFullFun() {
      this.showSubscribeFull = !this.showSubscribeFull;
    },

    goToHomePage() {
      this.$router.push({ name: "Home" });
    }
  },
  mounted() {
    if (this.weatherData) {
      this.temp = this.weatherData.main.temp;
      this.temp = this.temp + "";
      this.temp = this.temp.split(".")[0];
      this.location = this.weatherData.name;
      this.currentWeatherImg = `http://openweathermap.org/img/wn/${this.weatherData.weather[0].icon}@2x.png`;
    }

    this.date = new Date();
    this.currentDate.day = this.date.getDate();
    this.currentDate.weekDay = this.weekdays[this.date.getDay()];
    this.currentDate.month = this.months[this.date.getMonth()];
    this.currentDate.year = this.date.getFullYear();
  },
  watch: {
    weatherData: function() {
      this.temp = this.weatherData.main.temp;
      this.temp = this.temp + "";
      this.temp = this.temp.split(".")[0];
      this.location = this.weatherData.name;
      this.currentWeatherImg = `http://openweathermap.org/img/wn/${this.weatherData.weather[0].icon}@2x.png`;
    }
  },
  create() {}
};
</script>

<style>
@import "./../../../assets/css/fonts.css";
</style>

<style scoped>
/* Header */
.sideMenuActive {
  visibility: visible !important;
  width: 82% !important;
  transition: all 0.2s;
}
#nav-collapse {
  width: 0;
  margin: 0 auto;
}
#nav-collapse .sub-wrap .mobile-side-menu .nav-item .top-side-wrap {
  display: flex;
  flex-direction: column;
}
#nav-collapse .sub-wrap .mobile-side-menu .nav-item a .top-side-wrap .sub-item {
  display: flex;
  justify-content: space-between;
  padding: 0 15px;
  margin-top: 20px;
}
#nav-collapse
  .sub-wrap
  .mobile-side-menu
  .nav-item
  a
  .top-side-wrap
  .sub-item
  svg {
  color: rgb(248, 198, 26);
}
#nav-collapse .sub-wrap .mobile-side-menu .nav-item a .bottom-side-wrap {
  padding-bottom: 20px;
}
#nav-collapse
  .sub-wrap
  .mobile-side-menu
  .nav-item
  a
  .bottom-side-wrap
  .sub-item.date {
  padding-bottom: 35px;
}
#nav-collapse
  .sub-wrap
  .mobile-side-menu
  .nav-item
  a
  .bottom-side-wrap
  .sub-item {
  display: flex;
  flex-direction: column;
  padding: 0 15px;
}
#nav-collapse .sub-wrap .mobile-side-menu .nav-item a .bottom-side-wrap button {
  text-transform: none;
  background: #f8c61a;
  border: none;
  height: 30px;
  color: #052962;
  text-transform: uppercase;
  font-weight: bold;
  font-size: 13px;
  letter-spacing: 1px;
}
#nav-collapse
  .sub-wrap
  .mobile-side-menu
  .nav-item
  a
  .bottom-side-wrap
  button:hover {
  background: #ffe076;
}
.top-menu-wrap #nav-collapse .close-link-wrap {
  display: none;
  position: absolute;
}
.top-menu-wrap #nav-collapse .close-wrap a {
  position: absolute;
  width: 30px !important;
  height: 30px;
  top: -44px;
  right: 30px;
}
.top-menu-wrap #nav-collapse .close-wrap a::after {
  position: absolute;
  content: "";
  width: 30px;
  height: 2px;
  background-color: rgb(248, 198, 26);
  top: 14px;
  right: 0px;
  transform: rotate(-45deg);
}
.top-menu-wrap #nav-collapse .close-wrap a::before {
  position: absolute;
  content: "";
  width: 30px;
  height: 2px;
  background-color: rgb(248, 198, 26);
  top: 14px;
  right: 0px;
  transform: rotate(45deg);
}
.top-menu-wrap .mobile-top-menu {
  display: none;
  width: 100%;
  justify-content: space-between;
  align-items: center;
}
.top-menu-wrap .mobile-top-menu .navbar-toggler {
  border: none;
}
.top-menu-wrap .mobile-top-menu .mobnile-search-wrap svg {
  color: rgb(248, 198, 26);
}
.top-menu-wrap .mobile-top-menu .mobile-logo-wrap a {
  padding: 0;
}
.top-menu-wrap .mobile-top-menu .mobile-logo-wrap img {
  width: 90px;
}
#nav-collapse .sub-wrap {
  width: 100%;
}
#nav-collapse .sub-wrap .wide-menu {
  font-family: "Poppins-Regular";
  height: 100px;
}
#nav-collapse .sub-wrap .wide-menu .converter-wrap {
  position: relative;
}

#nav-collapse .sub-wrap .wide-menu .search-wrap .bell.active {
  height: 100%;
  width: 100%;
  transform: rotate(0deg);
  animation-name: rotate-bell;
  animation-delay: 0.5s;
  animation-duration: 1s;
  animation-iteration-count: 1;
  animation-direction: alternate;
  transform-origin: 50% 0%;
  animation-timing-function: ease-in-out;
}

#nav-collapse .sub-wrap .wide-menu .search-wrap {
  display: flex;
}

#nav-collapse .sub-wrap .wide-menu .search-wrap a {
  position: relative;
}

#nav-collapse .sub-wrap .wide-menu .search-wrap a .icon-wrap {
  position: absolute;
  right: 0;
}

#nav-collapse .sub-wrap .wide-menu .search-wrap .search-input {
  background: transparent;
  color: white;
  border: none;
}

#nav-collapse .sub-wrap .mobile-side-menu {
  display: none;
}
#nav-collapse .sub-wrap .mobile-side-menu .nav-item.wrap {
  border-top: 1px solid #6d6d6d;
}

.top-menu-wrap {
  background-color: #052962;
}
.top-menu-wrap .navbar-nav {
  width: 100%;
  display: flex;
  justify-content: space-between;
  align-items: center;
}
.top-menu-wrap .wide-menu li a svg {
  margin: 0 15px;
  color: rgb(248, 198, 26);
}
.top-menu-wrap .wide-menu li.weather-wrap {
  position: relative;
  display: flex;
  flex-direction: column;
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
  padding: 0;
}
.top-menu-wrap .navbar-brand {
  padding: 0;
}
.top-menu-wrap .wide-menu .current-date a {
  display: flex;
  flex-direction: column;
}

.nav-item .nav-link .weather-content {
  position: relative;
}
.nav-item .nav-link .weather-content .weather-icon img {
  width: 70px;
}

.top-menu-wrap .wide-menu li.weather-wrap .weather-dropdown-arrow {
  position: absolute;
  top: 12px;
  right: -55px;
}

.top-menu-wrap .wide-menu li.weather-wrap .location-name {
  text-align: end;
}

.top-menu-wrap .weather-value {
  font-family: "Semibold";
  font-size: 28px;
}
.top-menu-wrap .weather-value .celsius-value {
  font-size: 20px;
  position: absolute;
  top: -10px;
}

@media (max-width: 767px) {
  .bottom-menu-wrap {
    height: unset !important;
  }
  .bottom-menu {
    padding: 10px 0;
  }
  .top-menu-wrap .mobile-top-menu {
    display: flex;
  }
  #nav-collapse .sub-wrap {
    padding-top: 58px;
    height: 100%;
  }
  #nav-collapse .sub-wrap .wide-menu {
    display: none;
  }
  #nav-collapse .sub-wrap .mobile-side-menu {
    display: flex;
    height: 100%;
  }
  #nav-collapse .sub-wrap .mobile-side-menu .nav-item {
    display: flex;
    width: 100%;
    font-family: "Poppins-Regular";
  }
  #nav-collapse .sub-wrap .mobile-side-menu .nav-item a {
    width: 100%;
  }
  .top-menu-wrap #nav-collapse .close-link-wrap {
    display: block;
  }
  #nav-collapse .navbar-nav :nth-child(3) {
    order: 7;
  }
  #nav-collapse .navbar-nav svg.fa-caret-down {
    transform: rotate(-90deg);
  }
  #nav-collapse .weather-dropdown-arrow {
    position: unset;
  }
  .top-menu-wrap .top-menu {
    position: unset;
  }
  #nav-collapse .weather-content .wide-menu {
    display: flex;
  }
  #nav-collapse .navbar-nav {
    align-items: flex-start;
  }
}
@media (max-width: 1199px) {
  .bottom-menu-wrap .bottom-menu li a {
    font-size: 22px;
  }
}
@media (max-width: 1139px) {
  #nav-collapse .sub-wrap .wide-menu {
    font-size: 12px;
  }
  /* .bottom-menu-wrap .bottom-menu li a {
    font-size: 12px;
  } */
}

@media (max-width: 991px) {
  .bottom-menu-wrap .bottom-menu li a {
    font-size: 15px !important;
  }
  .carousel-caption .slide-title span {
    font-size: 28px;
  }
  .top-menu-wrap .navbar-collapse .search-wrap a svg {
    margin: 0 10px;
  }
  .top-menu-wrap #nav-collapse .search-wrap {
    margin-left: 30px !important;
  }
}
@media (max-width: 767px) {
  .bottom-menu-wrap .bottom-menu {
    flex-wrap: unset;
  }
  .bottom-menu-wrap .box-menu {
    overflow: scroll !important;
    display: flex;
  }
}

@keyframes rotate-bell {
  0% {
    transform: rotate(0deg);
  }
  25% {
    transform: rotate(30deg);
  }
  75% {
    transform: rotate(-10deg);
  }
  100% {
    transform: rotate(0deg);
  }
}

@media (min-width: 768px) {
  .modile-side-weather-wrap {
    display: none;
  }
  #nav-collapse {
    width: 100%;
  }
}
@media (max-width: 767px) {
  #nav-collapse {
    visibility: hidden;
    position: absolute;
    background: #052962;
    z-index: 9999;
    top: 0px;
    left: 0;
    bottom: 0;
  }
}

@media (min-width: 1140px) {
  .container {
    max-width: 1638px !important;
  }
}
@media (max-width: 1139px) {
  .container {
    max-width: 814px !important;
  }
  #nav-collapse .sub-wrap .wide-menu .search-wrap {
    margin-left: 20px;
  }
}
</style>