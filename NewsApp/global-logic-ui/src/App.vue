<template>
  <div id="app">
    <HeaderDesctop :weatherData='weatherData' ></HeaderDesctop>
    <router-view />
    <Footer></Footer>
  </div>
</template>

<style>
#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}
</style>

<script>
import HeaderDesctop from './shared/layouts/header/header';
import Footer from './shared/layouts/footer/footer';
import weatherService from './shared/services/weather.service';

export default {
  name: "app",
  components: {
    HeaderDesctop,
    Footer
  },
  data() {
    return {
      weatherData: null,
    }
  },
  beforeCreate() {
    this.$getLocation().then(coordinates => {
      this.coordinates = coordinates;
      weatherService.getWeather(coordinates.lat, coordinates.lng).then(res => {
        this.weatherData = res.data;
      });
    }).catch(function () {
      weatherService.getWeather(51.51062085840897, -0.12035208720763535).then(res => {
        this.weatherData = res.data;
      });
    }) 
  },
};
</script>
