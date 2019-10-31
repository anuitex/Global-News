<template>
  <div class="component-wrap">
    <div class="weather-dark-screen">
      <div class="weather-details-wrap" v-if="isShowMoreWeather">

        <div class="close-wrap" @click="closeMoreWeather()">
          <a href="#"></a>
        </div>
        <div class="left-side">
          <div class="temp-info-wrap">
            <div class="temp-value-wrap info-elem">
              <p>
                <span class="cwitch">Show weather in :</span>
                <span class="temp-symbol">
                  <span class="switch-mode">F</span>
                  <span class="switch-mode active">&#8451;</span>
                </span>
              </p>
              <p>Place : {{ weatherData.sys.country }}</p>
            </div>
            <div class="show-info-wrap info-elem">
              <p>
                Min Temperature :
                <span class="temp-value">
                  {{ weatherData.main.temp_min }}
                  <span class="temp-val-symbol"></span>
                </span>
              </p>
              <p>
                Max Temperature :
                <span class="temp-value">
                  {{ weatherData.main.temp_max }}
                  <span class="temp-val-symbol"></span>
                </span>
              </p>
              <p>
                Temperature :
                <span class="temp-value">
                  {{ weatherData.main.temp }}
                  <span class="temp-val-symbol"></span>
                </span>
              </p>
            </div>
            <div class="additional-info info-elem">
              <p class>
                Humidity :
                <span class="value">{{ weatherData.main.humidity }}</span>
              </p>
              <p class>
                Wind Speed :
                <span class="value">{{ weatherData.wind.speed }}</span>
              </p>
            </div>
          </div>
        </div>
        <div class="right-side">
          <div class="wrap">
            <span class="icon-wrap">
              <img :src="weatherImg" alt />
            </span>
            <span>{{ weatherData.weather[0].description }}</span>
          </div>
        </div>
      </div>

      <div class="bg-close" v-if="!isWeatherMap && isShowMoreWeather" @click="closeMoreWeather()"></div>
    </div>
  </div>
</template>

<script>
export default {
  props: ["isShowMoreWeather", "weatherData", "isWeatherMap"],
  name: "moreWeather",
  data() {
    return {
      weatherImg: ""
    };
  },
  mounted() {
    if (this.weatherData) {
      this.weatherData.main.temp = this.weatherData.main.temp + "";
      this.weatherData.main.temp = this.weatherData.main.temp.split(".")[0];
      this.weatherData.main.temp_max = this.weatherData.main.temp_max + "";
      this.weatherData.main.temp_max = this.weatherData.main.temp_max.split(
        "."
      )[0];
      this.weatherData.main.temp_min = this.weatherData.main.temp_min + "";
      this.weatherData.main.temp_min = this.weatherData.main.temp_min.split(
        "."
      )[0];
      this.weatherImg = `http://openweathermap.org/img/wn/${this.weatherData.weather[0].icon}@2x.png`;
    }
  },
  methods: {
    closeMoreWeather() {
      this.$emit("closeMoreWeather", false);
    }
  },
  watch: {
    weatherData: function() {
      this.weatherData.main.temp = this.weatherData.main.temp + '';
      this.weatherData.main.temp = this.weatherData.main.temp.split(".")[0];
      this.weatherData.main.temp_max = this.weatherData.main.temp_max + '';
      this.weatherData.main.temp_max = this.weatherData.main.temp_max.split(".")[0];
      this.weatherData.main.temp_min = this.weatherData.main.temp_min + '';
      this.weatherData.main.temp_min = this.weatherData.main.temp_min.split(".")[0];
      this.weatherImg = `http://openweathermap.org/img/wn/${this.weatherData.weather[0].icon}@2x.png`;
    }
  }
};
</script>

<style scoped>
.weather-dark-screen {
  left: 50%;
  top: 50%;
  position: fixed;
  z-index: 999999;
  transform: translate(-50%, -50%);
}
.weather-details-wrap {
  display: flex;
  width: 602px;
  background-color: #052962;
  z-index: 1000;
  padding: 0 50px;
}

.weather-details-wrap .right-side {
  position: absolute;
  right: 11%;
  top: 35%;
  font-size: 24px;
  font-weight: bold;
}
.weather-details-wrap .right-side .wrap span {
  margin: 10px 0;
}
.weather-details-wrap .right-side .wrap {
  display: flex;
  flex-direction: column;
}
.weather-details-wrap .right-side {
  color: #f9f9f9;
}
.weather-details-wrap .right-side .icon-wrap img {
  width: 130px;
}
.temp-info-wrap .additional-info {
  text-align: start;
}
.temp-info-wrap .info-elem {
  margin-top: 40px;
}
.weather-details-wrap .show-info-wrap {
  text-align: start;
}
.weather-details-wrap .show-info-wrap .temp-val-symbol {
  position: relative;
  margin-left: 5px;
}
.weather-details-wrap .show-info-wrap .temp-val-symbol::before {
  content: "";
  width: 7px;
  height: 7px;
  position: absolute;
  border: 1px solid #a09f9f;
  border-radius: 10px;
}
.weather-details-wrap .temp-symbol span {
  margin: 0 5px;
}

.weather-details-wrap .temp-symbol .switch-mode.active {
  color: #f8c61a;
}

.weather-details-wrap .temp-symbol {
  position: relative;
}
.weather-details-wrap .temp-symbol::before {
  content: "";
  position: absolute;
  width: 1px;
  height: 26px;
  background-color: white;
  left: 22px;
  top: 2px;
}
.weather-details-wrap .temp-value-wrap {
  text-align: start;
}

.weather-details-wrap .temp-info-wrap p {
  margin-bottom: 10px;
  font-family: "Poppins-Regular";
  font-size: 24px;
}
.weather-details-wrap .temp-info-wrap {
  color: #f9f9f9;
  font-size: 24px;
  margin-top: 95px;
  margin-bottom: 44px;
}

.weather-details-wrap .close-wrap a {
  width: 18px;
  height: 18px;
  display: inline-block;
  position: absolute;
  top: 24px;
  right: 23px;
}
.weather-details-wrap .close-wrap a::before {
  position: absolute;
  content: "";
  width: 15px;
  height: 1px;
  background-color: white;
  top: 7px;
  right: 0px;
  transform: rotate(45deg);
}

.weather-details-wrap .close-wrap a::after {
  position: absolute;
  content: "";
  width: 15px;
  height: 1px;
  background-color: white;
  top: 7px;
  right: 0px;
  transform: rotate(-45deg);
}

.modile-side-weather-wrap {
  overflow: scroll;
}
.weaterDetailsHidden {
  height: 300px;
  transition: all 1s;
}
.mobile-weather-details-wrap .right-side .wrap {
  display: flex;
  flex-direction: column;
}
.mobile-weather-details-wrap .right-side {
  color: #f9f9f9;
  display: flex;
  flex-direction: column;
  justify-content: flex-end;
  padding-left: calc((100% - 276px));
}
.mobile-weather-details-wrap .right-side .text {
  white-space: nowrap;
}
.mobile-weather-details-wrap .right-side .icon-wrap img {
  width: 35px;
}
.temp-info-wrap .additional-info {
  text-align: start;
}
.temp-info-wrap .info-elem {
  margin-top: 32px;
  font-size: 13px;
  font-weight: bold;
}
.mobile-weather-details-wrap .show-info-wrap {
  text-align: start;
}
.mobile-weather-details-wrap .show-info-wrap .temp-val-symbol {
  position: relative;
  margin-left: 5px;
}
.mobile-weather-details-wrap .show-info-wrap .temp-val-symbol::before {
  content: "";
  width: 7px;
  height: 7px;
  position: absolute;
  border: 1px solid #a09f9f;
  border-radius: 10px;
}
.mobile-weather-details-wrap .temp-symbol span {
  margin: 0 7px;
}
.mobile-weather-details-wrap .temp-symbol {
  position: relative;
}
.mobile-weather-details-wrap .temp-symbol::before {
  content: "";
  position: absolute;
  width: 1px;
  height: 16px;
  background-color: white;
  left: 22px;
  top: 0px;
}
.mobile-weather-details-wrap .temp-value-wrap {
  text-align: start;
}
.mobile-weather-details-wrap .temp-info-wrap p {
  margin-bottom: 3px;
}
.mobile-weather-details-wrap .temp-info-wrap {
  color: #f9f9f9;
}
.mobile-weather-details-wrap .sides-wrap {
  display: flex;
}
.mobile-weather-details-wrap {
  width: 100%;
  display: flex;
  flex-direction: column;
  background-color: #052962;
  z-index: 999;
}
.mobile-weather-details-wrap .close-wrap a {
  width: 18px;
  height: 18px;
  display: inline-block;
  position: absolute;
  top: 24px;
  right: 23px;
}
.mobile-weather-details-wrap .close-wrap a::before {
  position: absolute;
  content: "";
  width: 15px;
  height: 1px;
  background-color: white;
  top: 7px;
  right: 0px;
  transform: rotate(45deg);
}
.mobile-weather-details-wrap .close-wrap a::after {
  position: absolute;
  content: "";
  width: 15px;
  height: 1px;
  background-color: white;
  top: 7px;
  right: 0px;
  transform: rotate(-45deg);
}

.mobile-weather-main-wrap {
  padding: 0 15px 40px 15px;
}
.mobile-weather-main-wrap .section-elem {
  display: flex;
  justify-content: center;
  color: white;
}
.mobile-weather-main-wrap .title-wrap {
  padding: 30px 0;
}
.mobile-weather-main-wrap .location-wrap {
  color: white;
}
.mobile-weather-main-wrap .links-wrap {
  display: flex;
  justify-content: space-between;
  margin-top: 10px;
}
.mobile-weather-main-wrap .links-wrap a {
  color: #f8c61a;
  text-decoration: none;
}
.mobile-weather-main-wrap .links-wrap a svg {
  width: 7px;
}
.mobile-weather-main-wrap .seacrh-country-wrap {
  display: inline-flex;
  flex-direction: column;
  margin-top: 45px;
  width: 100%;
}
.mobile-weather-main-wrap .seacrh-country-wrap .serch-result {
  color: rgb(248, 198, 26) !important;
}
.mobile-weather-main-wrap .seacrh-country-wrap .text-wrap {
  color: white;
}
.mobile-weather-main-wrap .weather-data-wrap .button-wrap {
  margin-top: 23px;
}
.mobile-weather-main-wrap .country-wrap span {
  color: #eaeaea;
  display: block;
  width: 100%;
  border-bottom: 1px solid;
  text-align: start;
}
.mobile-weather-main-wrap .button-wrap {
  margin-top: 15px;
}
.mobile-weather-main-wrap .button-wrap button {
  width: 100%;
  height: 35px;
  background-color: #f8c61a;
  border: none;
  font-size: 16px;
  font-weight: bold;
  text-transform: uppercase;
  letter-spacing: 1px;
}
.mobile-weather-main-wrap .weather-data-wrap {
  display: flex;
  color: #d6d6d6;
  display: flex;
  justify-content: center;
  margin-top: 15px;
}
.mobile-weather-main-wrap .weather-data-wrap .clouds {
  display: flex;
  flex-direction: column;
}
.mobile-weather-main-wrap .weather-data-wrap .clouds .cloud-state {
  margin-top: 5px;
}
.mobile-weather-main-wrap .weather-data-wrap .temp-value-wrap {
  display: flex;
  align-items: center;
  color: white;
  font-size: 32px;
  font-family: initial;
  position: relative;
  padding-right: 55px;
}
.mobile-weather-main-wrap .weather-data-wrap .temp-value-wrap .temp-value {
  font-size: 38px;
}
.mobile-weather-main-wrap .weather-data-wrap .temp-value-wrap .temp-symbol {
  position: absolute;
  top: 0;
  font-size: 26px;
  left: 32px;
}
.mobile-weather-main-wrap
  .weather-data-wrap
  .temp-value-wrap
  .temp-symbol
  .activeMode.active {
  color: rgb(248, 198, 26);
}
.mobile-weather-main-wrap
  .weather-data-wrap
  .temp-value-wrap
  .temp-symbol
  span {
  margin: 0 8px;
}
.mobile-weather-main-wrap
  .weather-data-wrap
  .temp-value-wrap
  .temp-symbol::before {
  content: "";
  position: absolute;
  width: 1px;
  height: 22px;
  background-color: white;
  left: 42px;
  top: 8px;
}
.mobile-weather-main-wrap .weather-data-wrap .clouds img {
  width: 70px;
}
.mobile-weather-main-wrap .weather-data-wrap .text-wrap p.dropdown {
  font-size: 32px;
  font-family: initial;
}
.mobile-weather-main-wrap .weather-data-wrap .button-wrap button {
  width: 100%;
  height: 35px;
  background-color: #f8c61a;
  border: none;
  font-size: 14px;
  font-weight: bold;
  text-transform: uppercase;
  letter-spacing: 1px;
}
.mobile-weather-main-wrap .weather-data-wrap .button-wrap button:hover {
  background-color: #ffe076;
}
.mobile-weather-main-wrap.weather-data-wrap .button-wrap button:hover {
  background-color: #ffe076;
}
.modile-side-weather-wrap {
  position: absolute;
  top: 58px;
  bottom: 0;
  left: 0;
  right: 0;
  background-color: #052962;
  z-index: 999;
  border-top: 1px solid;
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

/* .bg-close {
  position: fixed;
  bottom: 0;
  top: 0;
  left: 0;
  right: 0;
  background-color: rgba(0, 0, 0, 0.5);
  z-index: 999;
} */
</style>