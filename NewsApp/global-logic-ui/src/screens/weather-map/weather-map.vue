<template>
  <div class="container">
    <div class="back-to-home" @click="goBack()">
      <a href="#" class="back-to-home-button"></a>
    </div>
    <moreWeather
      :isShowMoreWeather="isShowMoreWeather"
      @closeMoreWeather="closeMoreWeather"
      :weatherData="weatherData"
      :isWeatherMap="true"
    ></moreWeather>
    <div id="map" class="map"></div>
  </div>
</template>

<script>
import { environment } from "./../../environment/environment";
import mapboxgl from "mapbox-gl";
import moreWeather from "./../../shared/components/more-weather";
import weatherService from "./../../shared/services/weather.service";

export default {
  props: ["data"],
  name: "weatherMap",
  components: {
    moreWeather
  },
  data() {
    return {
      map: mapboxgl.Map,
      isShowMoreWeather: false,
      weatherData: null
    };
  },
  mounted() {
    let that = this;
    mapboxgl.accessToken = environment.mapboxKey;
    this.$getLocation()
      .then(coordinates => {
        this.map = new mapboxgl.Map({
          container: "map", // container id
          style: "mapbox://styles/mapbox/streets-v11", // stylesheet location
          center: [coordinates.lng, coordinates.lat], // starting position [lng, lat]
          zoom: 9 // starting zoom
        });

        this.map.on("click", function(e) {
          weatherService.getWeather(e.lngLat.lat, e.lngLat.lng).then(res => {
            that.weatherData = res.data;
            that.isShowMoreWeather = true;
          });
        });
      })
      .catch(function() {
        this.map = new mapboxgl.Map({
          container: "map", // container id
          style: "mapbox://styles/mapbox/streets-v11", // stylesheet location
          center: [51.51062085840897, -0.12035208720763535], // starting position [lng, lat]
          zoom: 9 // starting zoom
        });

        this.map.on("click", function(e) {
          weatherService.getWeather(e.lngLat.lat, e.lngLat.lng).then(res => {
            that.weatherData = res.data;
            that.isShowMoreWeather = true;
          });
        });
      });
  },
  methods: {
    closeMoreWeather() {
      this.isShowMoreWeather = false;
    },

    goBack() {
      this.$router.go(-1);
    }
  }
};
</script>

<style scoped>
.back-to-home {
  position: fixed;
  font-size: 30px;
  left: 100px;
  top: 100px;
  z-index: 99999;
  width: 56px;
  height: 56px;
  background-color: rgba(43, 98, 154, 0.5);
  background: rgba(43, 98, 154, 0.5);
  color: rgba(43, 98, 154, 0.5);
}

.back-to-home::before {
  position: absolute;
  content: "";
  width: 20px;
  height: 20px;
  border-bottom: 5px solid white;
  border-left: 5px solid white;
  -webkit-transform: rotate(45deg);
  transform: rotate(45deg);
  top: 19px;
  left: 20px;
}

.map {
  position: fixed;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  z-index: 999;
}

.container {
  display: flex;
  justify-content: center;
  align-items: center;
}
</style>