<template>
    <div v-bind:class="{ notificationAnim: isShowNotification }" class="notification">
        <div @click='closeNotification' class="close">
            <span class="close-line"></span>
        </div>
        <span class="content">Do you want to receive more news? <span @click='showSubscribe' class="subscribe">Subscribe us!</span></span>
    </div>
</template>

<script>
export default {
    name: 'subscribeNotification',
    props: ['isUserSubscribe'],
    data() {
        return {
            isShowNotification: false,
            timer: null,
        }
    },
    created() {
    },
    methods: {
        showSubscribe() {
            this.$emit('showSubscribe', true)
        },

        closeNotification() {
            this.isShowNotification = false;
        }
    },
    mounted() {
        this.timer = setTimeout(() => {
            this.isShowNotification = true
        }, 5000);
    },
    watch: {
        isUserSubscribe: function () {
            this.isShowNotification = false;
            clearTimeout(this.timer);
        }
    }
}
</script>

<style scoped>
    .notification {
        display: flex;
        justify-content: center;
        align-items: center;
        position: fixed;
        top: 150px;
        left: -350px;
        width: 350px;
        height: 135px;
        background-color: white;
        border-radius: 15px;
        border: 1px solid black;
    }

    .content {
        color: black;
        font-size: 17px;
    }

    .subscribe {
        color: blue;
        cursor: pointer;
    }

    .notificationAnim {
        -webkit-transition: 1s;
        -moz-transition: 1s;
        -ms-transition: 1s;
        -o-transition: 1s;
        transition: 1s;
        left: 100px;
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

    @media (max-width: 840px) {
        .notificationAnim {
            left: 25px;
        }
    }

    @media (max-width: 650px) {
        .notification {
            width: 300px;
        }

        .notificationAnim {
            left: 0;
        }
    }
</style>