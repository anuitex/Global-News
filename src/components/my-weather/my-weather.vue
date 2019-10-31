<template>
    <div class="weather" ref='weather'>  
        <div class="left-panel panel">
            <span class="date">{{ date | moment("dddd") }}</span>
            <br>
            <span class="date">
                {{ date | moment("MMMM DD, YYYY") }}
            </span>
            <span class="city">
                {{ location }}
            </span>
            <span class="temp">
            {{ temp }}&deg;
            </span>
            <span class="temp-symbol" v-bind:class="{ active: !isCelsius }" @click='changeTemp("fahrenheit")'>F</span>
            <span> | </span>
            <span class="temp-symbol" v-bind:class="{ active: isCelsius }" @click='changeTemp("celsius")'>&#8451</span>
        </div>

    </div>
</template>

<script>
import weatherService from './../../shared/services/weather.service';

export default {
    name: 'myWeather',
    props: ['isShowWeather'],
    data() {
        return {
            temp: '',
            location: '',
            date: '',
            coordinates: null,
            isCelsius: true,
        }
    },
    created() {
        this.$getLocation()
        .then(coordinates => {
            this.coordinates = coordinates;
            weatherService.getWeather(coordinates.lat, coordinates.lng).then((res) => {
                this.temp = res.data.main.temp;
                this.temp = this.temp + '';
                this.temp = this.temp.split(".")[0];
                this.location = res.data.name;
                this.date = new Date().toJSON().slice(0,10).replace(/-/g,'/');
            });
        });
    },
    watch: {
        isShowWeather() {
            if (this.isShowWeather) {
                this.$refs.weather.style.visibility = 'visible';
            } else {
                this.$refs.weather.style.visibility = 'hidden';
            }
        }
    },
    methods: {
        changeTemp(temp) {
            if (temp === 'fahrenheit') {
                this.isCelsius = false;
                weatherService.getWeather(this.coordinates.lat, this.coordinates.lng).then((res) => {
                    this.temp = res.data.main.temp * 1.8 + 32;
                    this.temp = this.temp + '';
                    this.temp = this.temp.split(".")[0];
                });
            } else {
                this.isCelsius = true;
                weatherService.getWeather(this.coordinates.lat, this.coordinates.lng).then((res) => {
                    this.temp = res.data.main.temp;
                    this.temp = this.temp + '';
                    this.temp = this.temp.split(".")[0];
                });
            }
        }
    }
}
</script>

<style scoped>
    .weather{
       display: flex;
       flex-direction: row;
       margin-top: 10px;
    }

    div.date{
        font-size: 14px;
        font-weight: bold;
        color: rgba(0,0,0, 1);
    }

    div.city{
        font-size: 17px;
        font-weight: bold;
        text-transform: uppercase;
        padding-top: 5px;
        color: rgba(0,0,0, 1);
    }

    div.temp{
        font-size: 30px;
        color: rgba(0,0,0, 1);
        font-weight: 100;
    }

    .left-panel {
        text-align: left;
    }

    .temp-symbol {
        cursor: pointer;
    }

    .active {
        color: blue;
    }
</style>