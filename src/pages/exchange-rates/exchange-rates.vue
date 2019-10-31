<template>
    <div class="rates" ref="rates">

        <div class="container">
            <div class="rates-type">
                <input v-on:input="changeAmount($event)" type="number" placeholder="Amount" class="amount" @focus="focusOn" @blur="focusOut">
                <span> Exchange rate from </span>
                <select v-on:change="changeCurrentRate($event)">
                    <option v-for="value of ratesName" :value="value" v-if="value !== exchangeName" v-bind:selected="value == currentRate">{{ value }}</option>
                </select>
                <span> to </span>
                <select v-on:change="changeRateTo($event)">
                    <option v-for="value of ratesName" :value="value" v-if="value !== currentRate" v-bind:selected="value == exchangeName">{{ value }}</option>
                </select>
            </div>

            <div class="current-rate-container">
                <h2 class="current-rate">{{ rateAmount }} {{ currentRate }}: {{ exchangeName }} {{ exchangeTo[0] }}.{{exchangeTo[1]}}</h2>
            </div>

             <div class="rates-couples">
                <div class="couple">
                    <span>EUR/USD = {{ retesCouples.first.usd[0] }}.{{ retesCouples.first.usd[1] }}</span>
                </div>
                <div class="couple">
                    <span>USD/JPY = {{ retesCouples.secound.jpy[0] }}.{{ retesCouples.secound.jpy[1] }}</span>
                </div>
                <div class="couple">
                    <span>GBP/USD = {{ retesCouples.third.usd[0] }}.{{ retesCouples.third.usd[1] }}</span>
                </div>
            </div>   
        </div>

        <div v-show="isLoaderShow" class="loader-container">
            <loader class="loader"></loader>
        </div>
    </div>
</template>

<script>
import ratesService from './../../shared/services/rates.service'
import loader from './../../shared/components/loader';
import _ from 'lodash'

    export default {
        name: 'ExchangeRages',
        components: {
            loader
        },
        data() {
            return {
                ratesName: [],
                ratesValue: {},
                currentRate: 'USD',
                currentRateValue: '',
                exchangeTo: '',
                exchangeName: 'EUR',
                rateAmount: 100,
                isLoaderShow: false,
                retesCouples: {
                    first: {
                        eur: this.rateAmount,
                        usd: ''
                    },

                    secound: {
                        usd: this.rateAmount,
                        jpy: '',
                    },

                    third: {
                        gbp: this.rateAmount,
                        usd: '',
                    }
                }
            }
        },
        created() {
            this.isLoaderShow = true;

            ratesService.getRates(this.currentRate).then(res => {
                for (let i in res.data.rates) {
                    this.ratesName.push(i);
                }
                this.ratesValue = res.data.rates;
                this.exchangeTo = this.ratesValue[this.exchangeName] * this.rateAmount;
                this.exchangeTo = this.exchangeTo+'';
                this.exchangeTo = this.exchangeTo.split('.');
                let array = this.exchangeTo[0].split('');
                this.exchangeTo[0] = ''; 
                for (let i = 0; i < array.length; i++) {
                    if (array.length > 3) {
                        if (i % 3 == 0) { 
                            if (i < array.length-1) {
                                array[i] = array[i]+','
                            } else {
                                continue;
                            }
                        }
                    }
                }
                this.exchangeTo[0] = array.join('')
                this.exchangeTo[1] = this.exchangeTo[1].slice(0, 4);
                this.isLoaderShow = false;
            });

            ratesService.getRates('EUR').then((res) => {
                this.retesCouples.first.usd = res.data.rates.USD;
                this.retesCouples.first.usd = this.retesCouples.first.usd + '';
                this.retesCouples.first.usd = this.retesCouples.first.usd.split(".");
                let array = this.retesCouples.first.usd[0].split('');
                this.retesCouples.first.usd[0] = ''; 
                for (let i = 0; i < array.length; i++) {
                    if (array.length > 3) {
                        if (i % 3 == 0) { 
                            if (i < array.length-1) {
                                array[i] = array[i]+','
                            } else {
                                continue;
                            }
                        }
                    }
                }
                this.retesCouples.first.usd[0] = array.join('')
                this.retesCouples.first.usd[1] = this.retesCouples.first.usd[1].slice(0, 4);
            });

            ratesService.getRates('USD').then((res) => {
                this.retesCouples.secound.jpy = res.data.rates.JPY;
                this.retesCouples.secound.jpy = this.retesCouples.secound.jpy + '';
                this.retesCouples.secound.jpy = this.retesCouples.secound.jpy.split(".");
                let array = this.retesCouples.secound.jpy[0].split('');
                this.retesCouples.secound.jpy[0] = ''; 
                for (let i = 0; i < array.length; i++) {
                    if (array.length > 3) {
                        if (i % 3 == 0) { 
                            if (i < array.length-1) {
                                array[i] = array[i]+','
                            } else {
                                continue;
                            }
                        }
                    }
                }
                this.retesCouples.secound.jpy[0] = array.join('')
                this.retesCouples.secound.jpy[1] = this.retesCouples.secound.jpy[1].slice(0, 4);
            });

            ratesService.getRates('GBP').then((res) => {
                this.retesCouples.third.usd = res.data.rates.USD;
                this.retesCouples.third.usd = this.retesCouples.third.usd + '';
                this.retesCouples.third.usd = this.retesCouples.third.usd.split(".");
                let array = this.retesCouples.third.usd[0].split('');
                this.retesCouples.third.usd[0] = ''; 
                for (let i = 0; i < array.length; i++) {
                    if (array.length > 3) {
                        if (i % 3 == 0) { 
                            if (i < array.length-1) {
                                array[i] = array[i]+','
                            } else {
                                continue;
                            }
                        }
                    }
                }
                this.retesCouples.third.usd[0] = array.join('')
                this.retesCouples.third.usd[1] = this.retesCouples.third.usd[1].slice(0, 4);

            });

        },
        methods: {
            changeCurrentRate(event) {
                this.isLoaderShow = true;
                let target = event.target.value;
                this.currentRate = target;
                this.itemValue = ['EUR', 'USD', 'RUB', 'CHF'];

                for (let i = 0; i < this.itemValue.length; i++) {
                    if (this.itemValue[i] === this.currentRate) {
                        this.itemValue.splice(i,1);
                    }
                }

                ratesService.getRates(this.currentRate).then(res => {
                    this.rates = res.data.rates;
                    this.currentRateValue = this.rates[this.currentRate];

                    this.exchangeTo = this.rates[this.exchangeName] * this.rateAmount;
                    this.exchangeTo = this.exchangeTo+'';
                    this.exchangeTo = this.exchangeTo.split('.');
                    let array = this.exchangeTo[0].split('');
                    this.exchangeTo[0] = ''; 
                    for (let i = 0; i < array.length; i++) {
                        if (array.length > 3) {
                            if (i % 3 == 0) { 
                                if (i < array.length-1) {
                                    array[i] = array[i]+','
                                } else {
                                    continue;
                                }
                            }
                        }
                    }
                    this.exchangeTo[0] = array.join('')
                    this.exchangeTo[1] = this.exchangeTo[1].slice(0, 4);
                    this.isLoaderShow = false;
                });
            },

            changeRateTo(event) {
                this.isLoaderShow = true;
                let target = event.target.value;

                ratesService.getRates(this.currentRate).then(res => {
                    this.rates = res.data.rates;
                    this.exchangeTo = this.rates[target] * this.rateAmount;
                    this.exchangeTo = this.exchangeTo+'';
                    this.exchangeTo = this.exchangeTo.split('.');
                    let array = this.exchangeTo[0].split('');
                    this.exchangeTo[0] = ''; 
                    for (let i = 0; i < array.length; i++) {
                            if (array.length > 3) {
                                if (i % 3 == 0) { 
                                    if (i < array.length-1) {
                                        array[i] = array[i]+','
                                    } else {
                                        continue;
                                    }
                                }
                            }
                    }
                    this.exchangeTo[0] = array.join('')
                    this.exchangeTo[1] = this.exchangeTo[1].slice(0, 4);
                    this.exchangeName = target;
        
                    this.isLoaderShow = false;
                });
            },

            changeAmount:_.debounce(async function(event) {
                this.isLoaderShow = true;
                const value = event.target.value;

                this.rateAmount = value;

                const res = await ratesService.getRates(this.currentRate);

                if (value) {
                    if (this.exchangeTo === 0) {
                        this.exchangeTo = res.data.rates[this.exchangeName]
                        this.exchangeTo = this.exchangeTo * value;
                    } else {
                        this.exchangeTo = res.data.rates[this.exchangeName] * value
                        this.exchangeTo = this.exchangeTo+'';
                        this.exchangeTo = this.exchangeTo.split('.');
                        let array = this.exchangeTo[0].split('');
                        this.exchangeTo[0] = ''; 
                        for (let i = 0; i < array.length; i++) {
                            if (array.length > 3) {
                                if (i % 3 == 0) { 
                                    if (i < array.length-1) {
                                        array[i] = array[i]+','
                                    } else {
                                        continue;
                                    }
                                }
                            }
                        }
                        this.exchangeTo[0] = array.join('')
                        this.exchangeTo[1] = this.exchangeTo[1].slice(0, 4);
                    }
                } else {
                    this.rateAmount = 100;
                    this.exchangeTo = res.data.rates[this.exchangeName] * this.rateAmount;
                    this.exchangeTo = this.exchangeTo+'';
                    this.exchangeTo = this.exchangeTo.split('.');
                    let array = this.exchangeTo[0].split('');
                    this.exchangeTo[0] = ''; 
                    for (let i = 0; i < array.length; i++) {
                        if (array.length > 3) {
                            if (i % 3 == 0) { 
                                if (i < array.length-1) {
                                    array[i] = array[i]+','
                                } else {
                                    continue;
                                }
                            }
                        }
                    }
                    this.exchangeTo[0] = array.join('')
                    this.exchangeTo[1] = this.exchangeTo[1].slice(0, 4);
                }
                
                this.rates = res.data.rates;

                for (let item in this.rates) {
                    if (typeof this.rates[item] == 'number') {
                        this.rates[item] = this.rates[item] * value;
                    }
                    continue;
                }
                this.isLoaderShow = false;
            }, 1000),

            focusOn() {
                if( /Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent) ) {
                    this.$emit('toggleHeadAndFoot', false);
                }
            },

            focusOut() {
                this.$emit('toggleHeadAndFoot', true);
            }
        }
        
    }
</script>

<style scoped>
    .rates {
        position: absolute;
        display: flex;
        flex-direction: column;
        align-items: center;
        justify-content: center;
        width: 100%; 
        height: 100vh;
        top: 0;
        margin: 0 auto;
    }

    .container {
        background-color: white;
        width: 50%;
        padding: 45px 0;
    }

    .current-rate-container {
        margin-top: 12px;
    }

    .loader-container {
        display: flex;
        justify-content: center;
        align-items: center;
        position: absolute;
        background-color: rgba(255, 255, 255, .7);
        width: 100%;
        height: 100%;
    }

    .rates-couples {
        display: flex;
        width: 100%;
        flex-direction: row;
        flex-wrap: wrap;
        justify-content: center;
    }

    .couple {
        display: flex;
        flex-direction: row;
        justify-content: center;
        align-items: center;
        width: 200px;
        height: 75px;
        border: 1px solid black;
        margin: 10px 0 0 10px;
    }

    .rate-items {
        display: flex;
        flex-direction: row;
        flex-wrap: wrap;
        width: 100%;
        margin-top: 35px;
        justify-content: center;
        background-color: #ffffff;
    }

    .rate-item {
        border: 1px solid #f0f0f0;
        margin-left: 25px;
        padding: 25px 20px;
        margin-top: 10px;
    }

    .amount {
        border: none;
        outline: none;
        width: 90px;
        padding: 2px 5px;
        border-bottom: 1px solid #d1d1d1;
    }

    .rate {
        font-size: 27px;
    }

    @media (max-width: 840px) {
        .rate {
            font-size: 20px;
        }

        .rates-type {
            margin-top: 0;
        }

        .container {
            width: 80%;
        }
    }

    @media (max-width: 650px) {
        .rate {
            font-size: 18px;
        }

        .rates-type {
            margin-top: 150px;
        }

        .rate-item {
            margin-left: 0;
        }

        .current-rate {
            font-size: 18px;
        }

        .rate-items {
            margin-top: 10px;
        }

        .rate-item {
            padding: 10px 15px;
            margin-top: 10px;
        }

        .rates-type {
            margin-top: -7em;
        }
    }

    @media (max-width: 670px) {
        .rates-type {
            margin-top: 0;
        }

        .container {
            width: 100%;
        }
    }
</style>