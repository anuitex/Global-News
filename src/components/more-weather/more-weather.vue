<template>
    <div class="more">
        <div class="container">
            <div class="close" @click='closePopup()'>
                <span class="close-line"></span>
            </div>
            <ul>
                <li class="weather-style">Show weather in 
                    <span class="temp-symbol" v-bind:class="{ active: !isCelsius }" @click='changeTemp("fahrenheit")'>F</span>
                    <span> | </span>
                    <span class="temp-symbol" v-bind:class="{ active: isCelsius }" @click='changeTemp("celsius")'>&#8451</span>
                </li>
                <li>Country: {{ weather.sys.country }}</li>
                <li>Min Temperature: {{ weather.main.temp_min }}&deg;</li>
                <li>Max Temperature: {{ weather.main.temp_max }}&deg;</li>
                <li>Temperature: {{ weather.main.temp }}&deg;</li>
                <li>weather: {{ weather.weather[0].description }} <img :src='weatherImg'> </li>
                <li>Humidity: {{ weather.main.humidity }}</li>
                <li>Wind Speed: {{ weather.wind.speed }}</li>
            </ul>
        </div>

        <div class="bg-close" @click='closePopup()'></div>
    </div>
</template>

<script>
import weatherService from './../../shared/services/weather.service';

export default {
    name: 'more',
    props: ['weather'],
    data() {
        return {
            weatherImg: '',
            isCelsius: true,
        }
    },
    mounted() {
        if (this.weather) {
            this.weather.main.temp = this.weather.main.temp + '';
            this.weather.main.temp = this.weather.main.temp.split(".")[0];
            this.weather.main.temp_max = this.weather.main.temp_max + '';
            this.weather.main.temp_max = this.weather.main.temp_max.split(".")[0];
            this.weather.main.temp_min = this.weather.main.temp_min + '';
            this.weather.main.temp_min = this.weather.main.temp_min.split(".")[0];
            this.weatherImg = `http://openweathermap.org/img/wn/${this.weather.weather[0].icon}@2x.png`;
        }
    },
    methods: {
        closePopup() {
            this.$emit('closePopup', true);
        },

        changeTemp(temp) {
            if (temp === 'fahrenheit') {
                this.isCelsius = false;
                weatherService.getWeatherByCountry(this.weather.name).then((res) => {
                    this.weather.main.temp = res.data.main.temp * 1.8 + 32;
                    this.weather.main.temp = this.weather.main.temp + '';
                    this.weather.main.temp = this.weather.main.temp.split(".")[0];
                    this.weather.main.temp_max = res.data.main.temp_max * 1.8 + 32;
                    this.weather.main.temp_max = this.weather.main.temp_max + '';
                    this.weather.main.temp_max = this.weather.main.temp_max.split(".")[0];
                    this.weather.main.temp_min = res.data.main.temp_min * 1.8 + 32;
                    this.weather.main.temp_min = this.weather.main.temp_min + '';
                    this.weather.main.temp_min = this.weather.main.temp_min.split(".")[0];
                });
            } else {
                this.isCelsius = true;
                weatherService.getWeatherByCountry(this.weather.name).then((res) => {
                    this.weather.main.temp = res.data.main.temp;
                    this.weather.main.temp = this.weather.main.temp + '';
                    this.weather.main.temp = this.weather.main.temp.split(".")[0];
                    this.weather.main.temp_max = res.data.main.temp_max;
                    this.weather.main.temp_max = this.weather.main.temp_max + '';
                    this.weather.main.temp_max = this.weather.main.temp_max.split(".")[0];
                    this.weather.main.temp_min = res.data.main.temp_min;
                    this.weather.main.temp_min = this.weather.main.temp_min + '';
                    this.weather.main.temp_min = this.weather.main.temp_min.split(".")[0];
                });
            }
        }
    }
}
</script>

<style scoped>
    .more {
        display: flex;
        justify-content: center;
        align-items: center;
        position: absolute;
        width: 100vw;
        height: 100vh;
        background-color: rgba(0, 0, 0, 0.7);
    }

    .container {
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

    @media (max-width: 650px) {
        .container {
            width: 80%;
        }
    }
</style>