<template>
  <div>
    <div class="weather-main-wrap" v-if="isShowWeatherModal">
      <div class="weather-search-wrap">
        <div class="close-wrap" @click="closeWeatherModal()">
          <a href="#"></a>
        </div>
        <div class="temp-value-wrap">
          <div class="text-wrap">
            <span>
              Do you mean
              <span class="search-result">{{ userCity }}</span>?
            </span>
          </div>
        </div>

        <div class="seacrh-country-wrap">
          <div class="country-wrap">
            <input :value='userCity' v-on:input="changecountry($event)"/>
          </div>
          <div class="button-wrap" @click='getWeather()'>
            <button href="#">Search</button>
          </div>
        </div>
        <div class="clouds">
          <span>{{ currentWeather }}</span>
          <span class="icon">
            <img :src="currentWeatherImg" alt="cloud" />
          </span>
        </div>

        <div class="temp-value-wrap">
          <span class="value">{{ temp }}</span>
          <span class="temp-symbol-wrap">
            <span class="temp-symbol">
              <span class="mode active"><sup class="mode active">o</sup>C</span>
            </span>
          </span>
        </div>
      </div>
      <div class="links-wrap">
        <a href="#" @click='showWeatherMap()'>Weather Map</a>
        <a href="#" @click="showMoreWeather()">More</a>
      </div>
    </div>

    <converterDesctop :isShowConverter="isShowConverter" @closeConverterModal="closeConverterModal"></converterDesctop>

    <!-- Mobile  Weather -->
    <div class="modile-side-weather-wrap">
      <div class="mobile-weather-main-wrap">
        <div class="title-wrap section-elem">
          <span>Weather</span>
        </div>
        <div class="location-wrap section-elem">
          <span>Glasgow</span>
        </div>
        <div class="weather-data-wrap">
          <div class="clouds">
            <span class="icon">
              <img src="../../assets/images/cloud.svg" alt="cloud" />
            </span>
            <span class="cloud-state">Broken Clouds</span>
          </div>
          <div class="temp-value-wrap">
            <span class="temp-value">+9</span>
            <span class="temp-symbol">
              <span class="activeMode active">&#8451;</span>
              <span class="activeMode">F</span>
            </span>
          </div>
        </div>
        <div class="seacrh-country-wrap">
          <div class="text-wrap">
            <p>
              Do you mean
              <span class="search-result">London</span> ?
            </p>
          </div>
          <div class="country-wrap">
            <span>Lond</span>
          </div>
          <div class="button-wrap">
            <button href="#">Search</button>
          </div>
        </div>
        <div class="links-wrap">
          <!-- Mobile Weater Details -->
          <div class="mobile-weather-details-wrap">
            <div class="links-wrap">
              <div class="left-link">
                <a href="#">
                  More
                  <font-awesome-icon icon="caret-down" />
                </a>
              </div>
              <div class="right-link">
                <a href="#">Weather Map</a>
              </div>
            </div>
            <div class="sides-wrap">
              <div class="left-side">
                <div class="temp-info-wrap">
                  <div class="temp-value-wrap info-elem">
                    <p>
                      <span class="cwitch">Show weather in :</span>
                      <span class="temp-symbol">
                        <span>F</span>
                        <span>&#8451;</span>
                      </span>
                    </p>
                    <p>Place : London</p>
                  </div>
                  <div class="show-info-wrap info-elem">
                    <p>
                      Min Temperature :
                      <span class="temp-value">
                        14
                        <span class="temp-val-symbol"></span>
                      </span>
                    </p>
                    <p>
                      Max Temperature :
                      <span class="temp-value">
                        14
                        <span class="temp-val-symbol"></span>
                      </span>
                    </p>
                    <p>
                      Temperature :
                      <span class="temp-value">
                        14
                        <span class="temp-val-symbol"></span>
                      </span>
                    </p>
                  </div>
                  <div class="additional-info info-elem">
                    <p class>
                      Humidity :
                      <span class="value">28</span>
                    </p>
                    <p class>
                      Wind Speed :
                      <span class="value">3</span>
                    </p>
                  </div>
                </div>
              </div>
              <div class="right-side">
                <div class="wrap">
                  <span class="icon-wrap">
                    <img src="../../assets/images/cloud.svg" alt="cloud" />
                  </span>
                  <span class="text">Broken Clouds</span>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>

      <div class="mobile-weather-details-wrap">
        <div class="sides-wrap">
          <div class="weather-map left-side">
            <div class="temp-info-wrap">
              <div class="temp-value-wrap info-elem">
                <p>
                  <span class="cwitch">Show weather in :</span>
                  <span class="temp-symbol">
                    <span>F</span>
                    <span>&#8451;</span>
                  </span>
                </p>
                <p>Place : London</p>
              </div>
              <div class="show-info-wrap info-elem">
                <p>
                  Min Temperature :
                  <span class="temp-value">
                    14
                    <span class="temp-val-symbol"></span>
                  </span>
                </p>
                <p>
                  Max Temperature :
                  <span class="temp-value">
                    14
                    <span class="temp-val-symbol"></span>
                  </span>
                </p>
                <p>
                  Temperature :
                  <span class="temp-value">
                    14
                    <span class="temp-val-symbol"></span>
                  </span>
                </p>
              </div>
              <div class="additional-info info-elem">
                <p class>
                  Humidity :
                  <span class="value">28</span>
                </p>
                <p class>
                  Wind Speed :
                  <span class="value">3</span>
                </p>
              </div>
            </div>
          </div>
          <div class="right-side">
            <div class="wrap">
              <span class="icon-wrap">
                <img src="../../assets/images/cloud.svg" alt="cloud" />
              </span>
              <span class="text">Broken Clouds</span>
            </div>
          </div>
        </div>
      </div>
    </div>

    <!-- Weater Details -->
    <moreWeather :isShowMoreWeather='isShowMoreWeather' @closeMoreWeather='closeMoreWeather' :weatherData='currentWeatherData' :isWeatherMap='false'></moreWeather>
  </div>
</template>

<script>
import converterDesctop from "./converter";
import weatherService from './../services/weather.service';
import moreWeather from './../components/more-weather';
import lifeSearchService from './../services/lifesearch.service';
import _ from 'lodash';

export default {
  props: ["isShowWeatherModal", "isShowConverter", 'weatherData'],
  name: "weatherDesctop",
  components: {
    converterDesctop,
    moreWeather
  },
  data() {
    return {
      currentWeatherData: null,
      userCity: 'London',
      temp: "",
      location: "",
      date: "",
      coordinates: null,
      isCelsius: true,
      currentWeather: null,
      currentWeatherImg: null,
      isShowMoreWeather: false
    };
  },
  methods: {
    closeWeatherModal() {
      this.$emit("closeWeatherModal", false);
    },

    closeConverterModal() {
      this.isShowConverter = false;
    },

    showMoreWeather() {
      this.isShowMoreWeather = true;
    },

    closeMoreWeather() {
      this.isShowMoreWeather = false;
    },

    showWeatherMap() {
      let data = this.weatherData;
      this.$emit("closeWeatherModal", false);
      this.$router.push({name: 'weatherMap', params: {data}});
    },

    changecountry:_.debounce(function(event) {
        const value = event.target.value;
        this.userCity = value;
        lifeSearchService.getDataForLifeSearch(value).then((res) => {
            this.userCity = res.data.data;
        }, (err) => {
            console.log(err)
        })

    }, 1000),

    getWeather() {
      weatherService.getWeatherByCountry(this.userCity).then((res) => {
        console.log(res.data)
        this.currentWeatherData = res.data;
        this.temp = res.data.main.temp;
        this.temp = this.temp + '';
        this.temp = this.temp.split(".")[0];
        this.userCity = res.data.name;
        this.location = this.userCity;
        this.currentWeatherImg = `http://openweathermap.org/img/wn/${res.data.weather[0].icon}@2x.png`
        this.currentWeather = res.data.weather[0].description
      });
    },
  },
  mounted() {
    if (this.weatherData) {
      this.currentWeatherData = this.weatherData;
      this.temp = this.weatherData.main.temp;
      this.temp = this.temp + "";
      this.temp = this.temp.split(".")[0];
      this.location = this.weatherData.name;
      this.currentWeather = this.weatherData.weather[0].description;
      this.date = new Date()
        .toJSON()
        .slice(0, 10)
        .replace(/-/g, "/");
      this.currentWeatherImg = `http://openweathermap.org/img/wn/${this.weatherData.weather[0].icon}@2x.png`;
    }
  },
  watch: {
    weatherData: function() {
      this.temp = this.weatherData.main.temp;
      this.temp = this.temp + "";
      this.temp = this.temp.split(".")[0];
      this.location = this.weatherData.name;
      this.currentWeather = this.weatherData.weather[0].description;
      this.date = new Date()
        .toJSON()
        .slice(0, 10)
        .replace(/-/g, "/");
      this.currentWeatherImg = `http://openweathermap.org/img/wn/${this.weatherData.weather[0].icon}@2x.png`;
    }
  },
};
</script>

<style scoped>
/* Weather Details */

/* font-family: 'Poppins-SemiBold'; */

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
  /* font-weight: bold; */
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

.weather-details-wrap .temp-symbol .switch-mode.active{
  color: #F8C61A;
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
  font-family: 'Poppins-Regular';
  font-size:24px;
  
}
.weather-details-wrap .temp-info-wrap {
  color: #f9f9f9;
  font-size: 24px;
  margin-top: 95px;
  margin-bottom: 44px;
}
.weather-details-wrap {
  display: flex;
  width: 602px;
  position: absolute;
  top: 500px;
  background-color: #052962;
  z-index: 999;
  padding: 0 50px;
  left: -550px;
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


/* Weather */
.weather-main-wrap {
  position: absolute;
  width: 355px;
  right: -150px;
  top: 106px;
  background-color: #052962;
  padding-bottom: 20px;
  z-index: 99999;
  padding: 0 60px 10px 60px;
}

.weather-main-wrap .links-wrap {
  display: flex;
  justify-content: space-between;
  margin-top: 55px;
}
.weather-main-wrap .links-wrap a {
  color: #f8c61a !important;
  text-decoration: none;
  font-family: "Poppins-Regular";
}

.weather-search-wrap .temp-value-wrap .temp-symbol {
  top: -7px;
  font-size: 26px !important;
}

.weather-search-wrap .temp-value-wrap {
  position: relative !important;
  color: white;
  font-weight: bold;
  position: relative;
  margin-top: 50px;
  font-family: "Poppins-SemiBold";
  display: flex;
  justify-content: center;
}

.weather-search-wrap .temp-value-wrap .temp-symbol-wrap {
  display: block;
  text-align: start;
  position: relative;
  min-width: 60px;
}

.weather-search-wrap .temp-value-wrap .temp-symbol-wrap .temp-symbol {
  position: absolute;
}

.weather-search-wrap
  .temp-value-wrap
  .temp-symbol-wrap
  .temp-symbol
  .mode.active {
  color: #f8c61a;
}
.weather-search-wrap .temp-value-wrap .value {
  display: block;
  text-align: end;
}

.weather-search-wrap .temp-value-wrap .temp-symbol span {
  margin: 0 5px;
}
.weather-search-wrap .temp-value-wrap .temp-symbol::before {
  content: "";
  position: absolute;
  width: 2px;
  height: 23px;
  background-color: white;
  left: 41px;
  top: 7px;
}

.weather-search-wrap .clouds {
  margin-top: 55px;
  color: #eaeaea;
  display: flex;
  justify-content: space-between;
  align-items: center;
  font-family: "Poppins-Regular";
}

.weather-search-wrap .clouds img {
  width: 90px;
}

.weather-search-wrap .close-wrap a {
  width: 18px;
  height: 18px;
  display: inline-block;
  position: absolute;
  top: 24px;
  right: 23px;
}
.weather-search-wrap .close-wrap a::before {
  position: absolute;
  content: "";
  width: 15px;
  height: 1px;
  background-color: white;
  top: 7px;
  right: 0px;
  transform: rotate(45deg);
}

.weather-search-wrap .close-wrap a::after {
  position: absolute;
  content: "";
  width: 15px;
  height: 1px;
  background-color: white;
  top: 7px;
  right: 0px;
  transform: rotate(-45deg);
}

.weather-search-wrap .text-wrap {
  margin-top: 40px;
  padding: 0;
  font-family: "Poppins-Regular";
}
.weather-search-wrap .text-wrap .search-result {
  color: #f8c61a;
}

.weather-search-wrap .text-wrap p.dropdown {
  font-size: 32px;
  font-family: initial;
}

.weather-search-wrap .button-wrap {
  margin-top: 18px;
}

.weather-search-wrap .country-wrap span {
  color: #eaeaea;
  display: block;
  width: 100%;
  border-bottom: 1px solid;
  text-align: start;
}

.weather-search-wrap .button-wrap button {
  height: 48px;
  background-color: #f8c61a;
  border: none;
  font-size: 16px;
  font-weight: bold;
  text-transform: uppercase;
  letter-spacing: 1px;
  font-family: "Poppins-SemiBold";
  width: 100%;
  color: #052962;
}
.weather-search-wrap .button-wrap button:hover {
  background-color: #ffe076;
}

.weather-search-wrap .seacrh-country-wrap {
  display: inline-flex;
  flex-direction: column;
  margin-top: 30px;
  width: 100%;
}

.weather-search-wrap .button-wrap {
  margin-top: 23px;
}

.weather-search-wrap .country-wrap input {
  color: #eaeaea;
  display: block;
  width: 100%;
  text-align: start;
  font-family: "Poppins-Regular";
  border: none;
  border-bottom: 1px solid;
  background: transparent;
}

/* Mob Weater*/
.modile-side-weather-wrap {
  /* display: none; */
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
.mobile-weather-main-wrap .seacrh-country-wrap .search-result {
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
@media (max-width: 1139px) {
  .weather-main-wrap{
    top: 103px;
  }
}
/* Links More Info weater hidden 
class='weather-details-wrap'

 */

</style>