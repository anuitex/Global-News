<template>
    <div>
        <b-carousel
        id="carousel-1"
        :interval="4000"
        controls
        indicators
        background="#ababab"
        img-width="1024"
        img-height="480"
        style="text-shadow: 1px 1px 2px #333;"
        >
            <b-carousel-slide v-for='slide of slides' :img-src="slide.urlToImage" @click="goToCurrentNews(slide)">
                <h2>{{ slide.title }}</h2>
            </b-carousel-slide>
        </b-carousel>
    </div>

</template>

<script>

export default {
    name: 'newsCarousel',
    props: ['sendedNews'],
    data() {
      return {
        slides: {
            urlToImage: '',
            title: '',
            description: ''
        },
      };
    },
    mounted() {
        if (this.sendedNews) {
            this.slides = this.sendedNews;
        }
    },
    created() {
        if (this.sendedNews) {
            this.slides = this.sendedNews;
        }
    },
    watch:{
        $route (to, from){
            this.slides = this.sendedNews;
        },

        sendedNews() {
            this.slides = this.sendedNews;
        },
    },
    methods: {
        goToCurrentNews(news) {
            this.$router.push({name: 'News', params: {news}})
        }
    }
}
</script>

<style scoped>
    h2 {
        font-size: 18px;
    }
</style>