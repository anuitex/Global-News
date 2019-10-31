<template>
    <div v-if='isShowLoader' class="loader-container">
        <div class="circle-rotate"></div>
    </div>
</template>

<script>
export default {
    name: 'loader',
    props: ['isShowLoader'],
    data() {
        return {
        }
    },
    watch: {
        isShowLoader: function() {

        }
    }
}
</script>

<style scoped>
    .loader-container {
        display: flex;
        justify-content: center;
        align-content: center;
        position: fixed;
        top: 0;
        bottom: 0;
        left: 0;
        right: 0;
        background-color: blue;
        transition: .7;
        opacity: 1;
    }

    .circle-rotate {
        width: 50px;
        height: 50px;
        border-radius: 50%;
        transition: 5s;
        transform: rotateY(720deg);
    }

    .smoth-opacity {
        opacity: 0;
    }

    .hide-loader {
        display: none;
    }
</style>