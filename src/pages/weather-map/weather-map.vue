<template>
    <div class="container">
        <div class="back-container" @click='back'>
            <img class="back" src="../../assets/images/arrow-left-30.png" alt="">
        </div>  
        <gmap-map
        :center="center"
        :zoom="12"
        class="gmap"
        style="width:100%;  height: 100%"
        @click="showWeather($event)"
        :options="{
            mapTypeControl: false,
        }"
        >
        </gmap-map>

        <div v-if='isShowWeather' class="weather-container">
            <div class="weather">
                <div class="close" @click='closePopup()'>
                    <span class="close-line"></span>
                </div>
                <ul>
                    <li class="weather-style">Show weather in 
                        <span class="temp-symbol" v-bind:class="{ active: isFahrenheit }" @click='changeTemp("fahrenheit")'>F</span>
                        <span> | </span>
                        <span class="temp-symbol" v-bind:class="{ active: !isFahrenheit }" @click='changeTemp("celsius")'>&#8451</span>
                    </li>
                    <li>Place: {{ currentWeather.name }}</li>
                    <li>Min Temperature: {{ currentWeather.main.temp_min }}&deg;</li>
                    <li>Max Temperature: {{ currentWeather.main.temp_max }}&deg;</li>
                    <li>Temperature: {{ currentWeather.main.temp }}&deg;</li>
                    <li>weather: {{ currentWeather.weather[0].description }} <img :src='weatherImg'> </li>
                    <li>Humidity: {{ currentWeather.main.humidity }}</li>
                    <li>Wind Speed: {{ currentWeather.wind.speed }}</li>
                </ul>
            </div>

            <div class="bg-close" @click='closePopup()'></div>
        </div>
    </div>
</template>

<script>
import weatherService from './../../shared/services/weather.service';

export default {
    name: 'weatherMap',
    data() {
        return {
            center: { lat: 45.508, lng: -73.587 },
            markers: [],
            places: [],
            currentPlace: null,
            currentWeather: {},
            isShowWeather: false,
            weatherImg: '',
            isFahrenheit: false,
        }
    },
    created() {
        this.$emit('hideAll', false);
        this.$getLocation()
        .then(coordinates => {
            this.center.lat = coordinates.lat;
            this.center.lng = coordinates.lng;
        })
    },
    beforeRouteLeave (to, from , next) {
        this.$emit('hideAll', true);
        next(true)
    },
    methods: {
        showWeather(e) {
            let lat = e.latLng.lat();
            let lng = e.latLng.lng();
            weatherService.getWeather(lat, lng).then((res) => {
                this.currentWeather = res.data;
                this.weatherImg = `http://openweathermap.org/img/wn/${this.currentWeather.weather[0].icon}@2x.png`;
                this.isShowWeather = true;
            })
        },

        closePopup() {
            this.isShowWeather = false;
        },

        changeTemp(temp) {
            if (temp === 'fahrenheit') {
                this.isFahrenheit = true;
                weatherService.getWeatherByCountry(this.currentWeather.name).then((res) => {
                    this.currentWeather.main.temp = res.data.main.temp * 1.8 + 32;
                    this.currentWeather.main.temp = this.currentWeather.main.temp + '';
                    this.currentWeather.main.temp = this.currentWeather.main.temp.split(".")[0];
                    this.currentWeather.main.temp_max = res.data.main.temp_max * 1.8 + 32;
                    this.currentWeather.main.temp_max = this.currentWeather.main.temp_max + '';
                    this.currentWeather.main.temp_max = this.currentWeather.main.temp_max.split(".")[0];
                    this.currentWeather.main.temp_min = res.data.main.temp_min * 1.8 + 32;
                    this.currentWeather.main.temp_min = this.currentWeather.main.temp_min + '';
                    this.currentWeather.main.temp_min = this.currentWeather.main.temp_min.split(".")[0];
                });
            } else {
                this.isFahrenheit = false;
                weatherService.getWeatherByCountry(this.currentWeather.name).then((res) => {
                    this.currentWeather.main.temp = res.data.main.temp;
                    this.currentWeather.main.temp = this.currentWeather.main.temp + '';
                    this.currentWeather.main.temp = this.currentWeather.main.temp.split(".")[0];
                    this.currentWeather.main.temp_max = res.data.main.temp_max;
                    this.currentWeather.main.temp_max = this.currentWeather.main.temp_max + '';
                    this.currentWeather.main.temp_max = this.currentWeather.main.temp_max.split(".")[0];
                    this.currentWeather.main.temp_min = res.data.main.temp_min;
                    this.currentWeather.main.temp_min = this.currentWeather.main.temp_min + '';
                    this.currentWeather.main.temp_min = this.currentWeather.main.temp_min.split(".")[0];
                });
            }
        },

        back() {
            this.$router.push({name: 'Weather'})
        }
    }
}
</script>

<style scoped>
    .container {
        position: absolute;
        top: 0; bottom: 0; right: 0; left: 0;
    }

    .gmap {
        position: fixed;
        top: 0; left: 0; right: 0; bottom: 0;
        z-index: 100;
    }

    .weather-container {
        display: flex;
        justify-content: center;
        align-items: center;
        position: fixed;
        z-index: 101;
        top: 0; bottom: 0; left: 0; right: 0;
        background-color: rgba(0, 0, 0, 0.7);
    }

    .weather {
        position: relative;
        width: 50%;
        background-color: white;
        padding: 25px;
        border-radius: 15px;
        z-index: 10;
    }

    ul {
        list-style: none;
        width: 100%;
    }

    li {
        color: black;
        text-align: left;
    }

    .close {
        position: absolute;
        top: 15px;
        right: 25px;
        width: 35px;
        height: 35px;
        display: flex;
        justify-content: center;
        align-items: center;
        cursor: pointer;
    }

    .close-line,
    .close-line::after {
        position: absolute;
        display: block;
        width: 3px;
        height: 25px;
        background: red;
    }

    .close-line {
        transform: rotate(45deg);
    }

    .close-line::after {
        content: '';
        transform: rotate(90deg);
    }

    .temp-symbol {
        cursor: pointer;
    }

    .active {
        color: blue;
    }

    .bg-close {
        position: absolute;
        width: 100%;
        height: 100%;
    }

    .back-container {
        position: absolute;
        z-index: 101;
        top: 20px;
        cursor: pointer;
    }

    @media (max-width: 650px) {
        .weather {
            width: 80%;
        }
    }

</style>