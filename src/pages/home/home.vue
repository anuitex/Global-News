<template>
    <div class="home">
        <newsCarousel v-if="!isOverRequest" class="carousel" :sendedNews='slides'></newsCarousel>

        <div class="home-content" v-for="news of news" v-on:click="goToCurrentNews(news)">
            <img :src="news.urlToImage" alt="">
            <div class="content-description">
                <h3>{{ news.title }}</h3>
                <p>{{ news.description }}</p>
            </div>
        </div>

        <div class="over-requests" v-if="isOverRequest">
            <h4 class="slide-title">Sorry, but requests is over</h4>
        </div>
    </div>
</template>

<script>
import newsCarousel from './../../components/news-slider/news-slider';
import newsService from './../../shared/services/news.service'

export default {
    name: 'Home',
    components: {
        newsCarousel,
    },
    data() {
        return {
            news: [],
            slides: [],
            isOverRequest: false
        }
    },
    created() {
        newsService.getTopNews('pageSize=6&').then((res) => {
            this.news = res.data.articles
            for (let i = 0; i < 3; i++) {
                this.slides.push(this.news[i]);
            }
            this.isOverRequest = false;
        }, (err) => {
            this.isOverRequest = true;
        })
    },
    methods: {
        goToCurrentNews(news) {
            this.$router.push({name: 'News', params: {news}})
        }
    }
}
</script>

<style scoped>
    .home {
        display: flex;
        position: relative;
        flex-direction: row;
        justify-content: center;
        flex-wrap: wrap;
        width: 70%;
        height: 100%;
        margin: 0 auto;
        padding-bottom: 250px;
    }

    .carousel {
        margin-top: 80px;
        width: 100%;
    }

    .home-content {
        position: relative;
        display: flex;
        flex-direction: row;
        width: 40%;
        margin-top: 55px;
        margin-left: 55px;
        padding: 5px;
        border: 1px solid #f0f0f0;
        cursor: pointer;
        background-color: #ffffff;
    }

    img {
        height: 170px;
        width: 170px;
        object-fit: contain;
    }

    h3 {
        font-size: 1.6vw;
        height: 170px;
        overflow: hidden;
    }

    .over-requests {
        margin-top: 120px;
    }

    .content-description {
        display: flex;
        flex-direction: column;
        align-items: center;
        justify-content: center;
        height: 100%;
        width: 100%;
        margin: 0 45px 0 45px;
    }

    p {
        display: none;
        margin-top: 15px;
        font-size: 1vw;
    }

    @media (max-width: 1100px) {
        .home-content {
            width: 80%;
        }

        h3 {
            height: auto;
        }

        p {
            display: inline-block;
        }
    }

    @media (max-width: 840px) {
        .home {
            width: 95%;
        }

        h3 {
            font-size: 16px;
        }

        p {
            font-size: 13px;
        }

        .carousel {
            margin-top: 100px;
        }
    }

    @media (max-width: 650px) {
        .home {
            width: 100%;
        }

        .home-content {
            justify-content: center;
            flex-direction: column;
            margin-top: 80px;
            margin-left: 0;
        }

        img {
            width: 100%;
            height: 50%;
        }

        .content-description {
            width: 90%;
            margin-left: 5%;
            /* padding: 0 20px 0 20px; */
        }

        h3 {
            margin-top: 5%;
        }

        .btn-read {
            font-size: 17px;
            width: 150px;
            margin: 0 auto;
            margin-top: 4%;
        }

        h3 {
            font-size: 26px;
        }

        p {
            font-size: 16px;
        }

        .carousel {
            margin-top: 160px;
        }
    }
</style>