<template>
    <div class="shared-button" @click='showSubscribe'>
        <img class="shared-image" src="./../../assets/images/bell-48.png">
    </div>
</template>

<script>
export default {
    name: 'subscribeButton',
    methods: {
        showSubscribe() {
            this.$emit('showSubscribe', true)
        },
    }
}
</script>

<style scoped>
    .shared-button {
        display: flex;
        position: fixed;
        justify-content: center;
        align-items: center;
        width: 55px;
        height: 55px;
        background-color: white;
        border: 1px solid black;
        border-radius: 50%;
        z-index: 99;
        bottom: 115px;
        right: 25px;
        cursor: pointer;
    }

    .shared-image {
        width: 35px;
        height: 35px;
    }

    @media (max-width: 840px) {
        .shared-button {
            width: 45px;
            height: 45px;
        }

        .shared-image {
            width: 30px;
            height: 30px;
        }
    }

    @media (max-width: 650px) {
        .shared-button {
            bottom: 100px;
        }
    }

</style>