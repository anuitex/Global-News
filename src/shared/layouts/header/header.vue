<template>
    <div class="header">
        <div class="logo">
            <h1><router-link class="link" :to="{name: `Home`}">Global News</router-link></h1>

            <myWeather :isShowWeather="isShowWeather"></myWeather>
        </div>
        <div class="header-content">       
            <div class="choose-category">
                <ul class="categories">
                    <li class="category" v-bind:class="{ activeCategory: currentUrl === 'Home' }">
                        <router-link class="link" :to="{name: `Home`}">Home Page</router-link>
                    </li>
                    <li class="category" v-bind:class="{ activeCategory: currentUrl === category }" v-for="category of this.categories">
                        <router-link class="link" :to="{name: `newsCategory`, params: {category}}">{{ category }}</router-link>
                    </li>
                    <li class="category" v-bind:class="{ activeCategory: currentUrl === 'ExchangeRates' }">
                        <router-link class="link" :to="{name: `ExchangeRates`}">Exchange Rates</router-link>
                    </li>
                    <li class="category" v-bind:class="{ activeCategory: currentUrl === 'Weather' }">
                        <router-link class="link" :to="{name: `Weather`}">Weather</router-link>
                    </li>
                </ul>
            </div>

            <input id="burger" type="checkbox" style="visibility: hidden" ref="mobileMenu"/>

            <label for="burger" class="mobileMenu" v-on:click="toggleWeather()">
                <span></span>
                <span></span>
                <span></span>
            </label>

            <nav>    
                <ul class="categories mobile-categories">
                    <li v-on:click="closeMenu()" class="category" v-bind:class="{ activeCategory: currentUrl === 'Home' }">
                        <router-link class="link" :to="{name: `Home`}">Home Page</router-link>
                    </li>
                    <li v-on:click="closeMenu()" class="category" v-bind:class="{ activeCategory: currentUrl === category }" v-for="category of this.categories">
                        <router-link class="link" :to="{name: `newsCategory`, params: {category}}">{{ category }}</router-link>
                    </li>
                    <li v-on:click="closeMenu()" class="category" v-bind:class="{ activeCategory: currentUrl === 'ExchangeRates' }">
                        <router-link class="link" :to="{name: `ExchangeRates`}">Exchange Rates</router-link>
                    </li>
                    <li v-on:click="closeMenu()" class="category" v-bind:class="{ activeCategory: currentUrl === 'Weather' }">
                        <router-link class="link" :to="{name: `Weather`}">Weather</router-link>
                    </li>
                </ul>
            </nav>

        </div>
    </div>
</template>

<script>
import apiService from './../../services/news.service';
import myWeather from './../../../components/my-weather/my-weather';

export default {
    name: 'Header',
    components: {
        myWeather
    },
    data() {
        return {
            currentUrl: null,
            categories: ['Business', 'Entertainment', 'Health', 'Science', 'Sports', 'Technology'],
            countries: [
                {
                    name: 'United Arab Emirates',
                    code: 'AE'
                },
                {
                    name: 'Argentina',
                    code: 'AR'
                },
                {
                    name: 'Austria',
                    code: 'AT'
                },
                {
                    name: 'Australia',
                    code: 'AU'
                }
            ],
            currentCountry: '',
            isShowMobileMenu: false,
            mobileMenu: [],
            lat: null,
            lon: null,
            temp: '',
            location: '',
            date: '',
            isShowWeather: true,
            coordinates: null,
        }
    },
    created() {
        if (!this.currentUrl) {
            if (this.$route.params.category) {
                this.currentUrl = this.$route.params.category;
            } else {
                this.currentUrl = this.$route.name
            }
        };
    },
    watch:{
        $route (to, from){
            if (to.params.category) {
                if (to.params.category) {
                    this.currentUrl = to.params.category; 
                } else if (to.params.country) {
                    this.currentUrl = to.params.country; 
                }
            } else {
                this.currentUrl = to.name
            }
        }
    },
    methods: {
        showMobileMenu() {
            this.isShowMobileMenu = !this.isShowMobileMenu;
        },

        closeMenu() {
            this.$refs.mobileMenu.checked = false;
            if (this.isShowWeather === false) {
                this.isShowWeather = true;
            }
        },

        toggleWeather() {
            let matchWindow = window.matchMedia("(max-width: 650px)")
            if (matchWindow.matches) {  
                this.isShowWeather = !this.isShowWeather;
            }
        },
    },
}
</script>

<style scoped>
    .header {
        position: relative;
        width: 70%;
        margin: 0 auto;
        z-index: 99;
        padding-top: 40px;
    }

    .header-content {
        position: absolute;
        width: 100%;
    }

    .countries {
        display: flex;
        flex-direction: row;
        list-style: none;
        margin-top: 20px;
    }

    .categories {
        display: flex;
        flex-direction: row;
        justify-content: space-around;
        list-style: none;
        margin-top: 20px;
    }

    .logo {
        position: relative;
        display: flex;
        justify-content: space-between;
        width: 100%;
        z-index: 9;
    }

    .country:hover {
        font-size: 17px;
    }

    .category {
        display: inline-block;
        padding: 5px 15px;
        cursor: pointer;
        word-wrap: none;
        font-size: 1vw;
        transition: .2s;
        white-space: nowrap;
    }

    .category:hover {
        font-size: 1.05vw;
    }

    .link {
        text-decoration: none;
        color: black;
    }

    .mobileMenu {
        display: none;
    }

    .mobile-categories {
        margin-top: 40px;
    }

    input + label {
        position: absolute;
        top: -2.5em;
        left: 20px;
        height: 20px;
        width: 15px;
        z-index: 10;
    }
    input + label span {
        position: absolute;
        width: 100%;
        height: 2px;
        top: 50%;
        margin-top: -1px;
        left: 0;
        display: block;
        background: #020304;
        transition: .5s;
    }
    input + label span:first-child {
        top: 3px;
    }
    input + label span:last-child {
        top: 16px;
    }
    label:hover {
        cursor: pointer;
    }
    input:checked + label span {
        opacity: 0;
        top: 50%;
    }
    input:checked + label span:first-child {
        opacity: 1;
        transform: rotate(405deg);
    }
    input:checked + label span:last-child {
        opacity: 1;
        transform: rotate(-405deg);
    }
    input ~ nav {
        background: white;
        position: fixed;
        top: 0;
        left: 0;
        width: 100%;
        height: 0px;
        z-index: 3;
        transition: .5s;
        transition-delay: .5s;
        overflow: hidden;
    }
    input ~ nav > ul {
        text-align: center;
        position: absolute;
        left: 20%;
        right: 20%;
        top: 10%;
    }
    input ~ nav > ul > li {
        opacity: 0;
        transition: .5s;
        transition-delay: 0s;
    }
    input ~ nav > ul > li > a {
        text-decoration: none;
        text-transform: uppercase;
        color: #020304;
        font-weight: 700;
        font-family: sans-serif;
        display: block;
        margin-top: 10px;
    }
    input:checked ~ nav {
        height: 100%;
        transition-delay: 0s;
    }
    input:checked ~ nav > ul > li {
        opacity: 1;
        transition-delay: .5s;
    }

    @media (min-width: 840px) {
        .activeCategory {
            border-bottom: 3px solid #ff9900;
        }
    }

    @media (max-width: 840px) {
        .header {
            width: 100%;
            position: fixed;
            background-color: white;
            padding-top: 25px;
        }
        
        .mobileMenu {
            display: block;
        }

        .mobile-menu {
            position: fixed;
            display: block;
            background-color: black;
            border: 1px solid #d1d1d1;
            width: 90%;
            left: 5%;
            top: 10%;
        }

        .choose-category {
            display: none;
        }

        .categories {
            flex-direction: column;
        }

        .logo {
            justify-content: space-around;
        }

        .categories-mobile {
            list-style: none;
        }

        .category-mob {
            margin-top: 10px;
        }

        .activeCategory {
            border-bottom: 3px solid #ffffff;
        }

        .category {
            font-size: 20px;
        }
    }

    @media (max-width: 650px) {
        .header {
            padding-bottom: 15px;
        }

        input + label {
            width: 25px;
            top: -4.4em;
        }

        input + label span {
            height: 3px;
        }

        .category {
            font-size: 15px;
        }

        .logo h1 {
            font-size: 32px;
        }

        .logo {
            justify-content: center;
            flex-direction: column;
            align-items: center;
        }
    }
</style>