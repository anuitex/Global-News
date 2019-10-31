<template>
    <div class="weather">
        <div class="widget" ref='widget' :style='blockPosition'>
            <div class="city">
                <input type="text" class="input-country" :value='userCity' v-on:input="changecountry($event)">
                <button class="showWeather" @click='getWeather()'>Search</button>
            </div>
            <div class="hint" v-if='probablyCity'>
                <p class="hint-value">Did you mean <span class="probably-city">{{ probablyCity[cityArrayNumber].name }}({{ probablyCity[cityArrayNumber].country }})</span>?</p>
                <img src="./../../assets/images/refresh.png" class="refresh-city" @click='refreshCity'>
            </div>
            <div class="left-panel panel">
                <div class="info">
                    <div class="weather-info">
                        <span>{{ weather }}</span>
                        <img :src="currentWeatherImg">
                    </div>
                    <div class="temp">
                        <span>Temp {{ temp }}&deg; </span>
                        <span class="temp-symbol" v-bind:class="{ active: !isCelsius }" @click='changeTemp("fahrenheit")'>F</span>
                        <span> | </span>
                        <span class="temp-symbol" v-bind:class="{ active: isCelsius }" @click='changeTemp("celsius")'>&#8451</span>
                    </div>
                </div>
            </div>
            <span @click='showMoreWeather' class="more-btn">More</span>
            <router-link class="earth-map" :to="{name: 'weatherMap'}">Weather Map</router-link>
        </div>
        <more @closePopup='closePopup' :weather='moreWeather' v-if='isShowMoreWeather' class="more-popup"></more>
    </div>
</template>

<script>
import weatherService from './../../shared/services/weather.service';
import lifeSearchService from './../../shared/services/lifeSearch.service';
import more from './../../components/more-weather/more-weather'
import _ from 'lodash'

export default {
    name: 'Weather',
    components: {
        more,
    },
    data() {
        return {
            temp: '',
            userCity: 'London',
            currentWeatherImg: '',
            weather: '',
            probablyCity: null,
            blockPosition: {
                margin: 'auto auto'
            },
            cityArrayNumber: 0,
            moreWeather: null,
            isShowMoreWeather: false,
            isCelsius: true,
            autocomplete: null,            
        }
    },
    created() {
        weatherService.getWeatherByCountry(this.userCity).then((res) => {
            this.moreWeather = res.data;
            this.temp = res.data.main.temp;
            this.temp = this.temp + '';
            this.temp = this.temp.split(".")[0];
            this.userCity = res.data.name;

            this.currentWeatherImg = `http://openweathermap.org/img/wn/${res.data.weather[0].icon}@2x.png`
            this.weather = res.data.weather[0].description
        });
    },
    methods: {
        changecountry:_.debounce(function(event) {
            const value = event.target.value;
            this.userCity = value;
            lifeSearchService.getDataForLifeSearch(value).then((res) => {
                this.probablyCity = res.data.data;
            }, (err) => {
                console.log(err)
            })

        }, 1000),

        refreshCity() {
            if(this.cityArrayNumber === this.probablyCity.lenght) {
                this.cityArrayNumber = 0;
            } else {
                this.cityArrayNumber += 1;
            }
        },

        getWeather() {
            let value;
            value = this.userCity;
            weatherService.getWeatherByCountry(value).then((res) => {
                this.moreWeather = res.data;
                this.temp = res.data.main.temp;
                this.temp = this.temp + '';
                this.temp = this.temp.split(".")[0];
                this.userCity = res.data.name;
                
                this.currentWeatherImg = `http://openweathermap.org/img/wn/${res.data.weather[0].icon}@2x.png`
                this.weather = res.data.weather[0].description
            });
        },

        changeTemp(temp) {
            let value = this.userCity;

            if (temp === 'fahrenheit') {
                this.isCelsius = false;
                weatherService.getWeatherByCountry(value).then((res) => {
                    this.temp = res.data.main.temp * 1.8 + 32;
                    this.temp = this.temp + '';
                    this.temp = this.temp.split(".")[0];
                });
            } else {
                this.isCelsius = true;
                weatherService.getWeatherByCountry(value).then((res) => {
                    this.temp = res.data.main.temp;
                    this.temp = this.temp + '';
                    this.temp = this.temp.split(".")[0];
                });
            }
        },

        showMoreWeather() {
            this.isShowMoreWeather = true;
        },

        closePopup() {
            this.isShowMoreWeather = false;
        },

        focusOn() {
            if( /Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent) ) {
                this.$emit('toggleHeadAndFoot', false);
            }
        },

        focusOut() {
            this.$emit('toggleHeadAndFoot', true);
        },

        setPlace(place) {
            this.userCity = place.name;
            this.getWeather();
        },
    },
    mounted() {
    }
}
</script>

<style scoped>
    .weather {
        position: absolute;
        display: flex;
        width: 100%;
        height: 100%;
        top: 0;
        overflow: hidden;
    }

    .refresh-city {
        width: 26px;
        height: 26px;
        cursor: pointer;
    }

    .showWeather {
        width: 30%;
        background-color: transparent;
        outline: none;
        border: none;
        margin-top: 5px;
        border: 1px solid black;
    }

    .probablyCountry-container {
        font-size: 14px;
    }

    .probablyCountry {
        color: blue;
        cursor: pointer;
    }

    .country {
        margin-top: 15px;
    }

    .hint {
        display: flex;
        flex-direction: row;
        flex-wrap: wrap;
        justify-content: center;
        align-items: center;
        margin-top: 17px;
    }

    .hint-value {
        font-size: 18px;
        margin-bottom: 0;
    }

    div.widget {
        display: flex;
        position: relative;
        flex-direction: column;
        width: 550px;
        background-color: #fcfdfd;
        border-radius: 9px;
        padding: 25px;
        padding-right: 30px;
        box-shadow: 0px 31px 35px -26px #080c21;
        z-index: 9;
    }

    div.left-panel {
        display: flex;
        flex-direction: row;
        align-items: center;
        width: 100%;
    }

    .more-btn {
        position: absolute;
        bottom: 15px;
        right: 15px;
        cursor: pointer;
    }

    .probably-city {
        cursor: pointer;
    }

    .earth-map {
        position: absolute;
        bottom: 15px;
        left: 15px;
        cursor: pointer;
        color: rgb(44, 62, 80);;
    }

    .more-popup {
        position: absolute;
        top: 0; left: 0; right: 0; bottom: 0;
        z-index: 999;
    }

    .info {
        display: flex;
        flex-direction: column;
        width: 100%;
    }

    div.city {
        display: flex;
        flex-direction: row;
        position: relative;
        justify-content: space-around;
        font-size: 18px;
        font-weight: bold;
        text-transform: uppercase;
        padding-top: 5px;
        width: 100%;
        color: rgba(0,0,0,0.7);
    }

    div.temp,
    div.weather-info {
        font-size: 25px;
        color: rgba(0,0,0,0.9);
        font-weight: 100;
    }

    div.right-panel {
        position: absolute;
        float: right;
        top: 0;
    }

    .temp-symbol {
        cursor: pointer;
    }

    .active {
        color: blue;
    }

    .input-country {
        outline: none;
        border: none;
        font-size: 18px;
        width: 65%;
        border-bottom: 1px solid black;
    }

    @media (max-width: 650px) {
        div.widget {
            width: 96%;
            height: 300px;
        }

        div.left-panel {
            flex-direction: column;
        }
    }

    @media (max-width: 350px) {
        div.widget {
            width: 96%;
            height: 300px;
        }
    }
</style>