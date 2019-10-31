<template>
    <div class="subscribe">
        <div class="container">
            <div @click='closeSubscribe' class="close">
                <span class="close-line"></span>
            </div>

            <div class="content">
                <span>
                    You subscribe on
                    <select name="" id="" v-model='category'>
                        <option v-model='category' value="all">All</option>
                        <option v-for='categiry of categories' :value="categiry">{{ categiry }}</option>
                    </select>
                    News
                </span>
                <span>You <input class="email" type="email" placeholder="email" v-model='email'></span>
                <p class="incorrect-email" v-if='isIncorrectEmail'>Your email is incorrect</p>
                <p class="correct-email" v-if='correctEmail'>You Subscribe</p>
                <button class="btn-sub" @click='subscribe'>Subscribe</button>
            </div>
        </div>
        <div class="bg-close" @click='closeSubscribe'></div>
    </div>
</template>

<script>
    import subscriptionrService from './../../shared/services/subscription.service';

    export default {
        name: 'subscribe',
        data() {
            return {
                email: '',
                isIncorrectEmail: false,
                correctEmail: false,
                categories: ['Business', 'Entertainment', 'Health', 'Science', 'Sports', 'Technology'],
                category: '',
            }
        },
        methods: {
            closeSubscribe() {
                this.$emit('closeSubscribe', false)
            },

            validateEmail(email) {
                let re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
                return re.test(email);
            },

            subscribe() {
                let isEmailValid = this.validateEmail(this.email);
                if (!isEmailValid) {
                    this.isIncorrectEmail = true;
                    setTimeout(() => {
                        this.isIncorrectEmail = false
                    }, 3000)
                } else {
                    this.correctEmail = true;
                    subscriptionrService.addSubscroption(this.email, this.category);

                    setTimeout(() => {
                        this.correctEmail = false;
                        this.$emit('closeSubscribe', false);
                    }, 2000)
                }
            }
        }
    }
</script>

<style scoped>
    .subscribe {
        display: flex;
        justify-content: center;
        align-items: center;
        position: fixed;
        width: 100vw;
        height: 100vh;
        top: 0;
        background-color: rgba(0, 0, 0, 0.7);
    }

    .container {
        position: relative;
        width: 65%;
        height: 245px;
        background-color: white;
        border-radius: 15px;
        z-index: 10;
    }

    .close {
        position: absolute;
        top: 10px;
        right: 10px;
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

    .content {
        display: flex;
        flex-direction: column;
        justify-content: center;
        align-items: center;
        width: 100%;
        height: 100%;
    }

    .email {
        border: none;
        outline: none;
        border-bottom: 1px solid black;
        padding: 0 0 0 10px;
    }

    .btn-sub {
        background-color: #ff1100;
        color: white;
        border: none;
        outline: none;
        padding: 10px 25px;
        border-radius: 5px;
        margin-top: 15px;
        transition: .3s;
    }

        .btn-sub:hover {
            background-color: #ff3e30;
        }

    .incorrect-email {
        color: red;
        font-size: 22px;
    }

    .correct-email {
        color: #0ced00;
        font-size: 22px;
    }

    .bg-close {
        position: absolute;
        width: 100%;
        height: 100%;
    }
</style>