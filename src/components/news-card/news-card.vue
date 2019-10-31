<template>
    <div class="news">
        <img class="news-img" :src="news.urlToImage" @error="imgPlaceholder" v-if="news.urlToImage" ref="newsImage">
        <img class="news-img" src="https://via.placeholder.com/300" v-else>
        <div class="news-info">
            <h3 class="news-title">{{ news.title }}</h3>
            <p class="news-description">{{ news.description }}</p>

            <router-link class="btn-read" :to="{name: 'News', params: {news}}">Read</router-link>
            <span class="pablish-date">{{ news.publishedAt | moment("from", "now") }}</span>
            <social-sharing url=""
                      :title="news.title"
                      :description="news.description"
                      :media="news.urlToImage"
                      :quote="news.description"
                      hashtags="news"
                      inline-template class="shared">
                <div>
                    <network network="facebook" class="social">
                        <img class="social" src="./../../assets/images/facebook-48.png" alt="facebook">
                    </network>
                    <network network="linkedin" class="social">
                        <img class="social" src="./../../assets/images/linkedin-48.png" alt="linkedin">
                    </network>
                    <network network="twitter" class="social">
                        <img class="social" src="./../../assets/images/twitter-48.png" alt="twitter">
                    </network>
                </div>
            </social-sharing>
        </div>
    </div>
</template>

<script>
export default {
    name: 'newsCard',
    props: ['sendedNews'],
    data() {
        return {
            news: {
                urlToImage: '',
                title: '',
                content: '',
                isImageForbidden: false,
            }
        }
    },
    mounted() {
        if (this.sendedNews) {
            this.news = this.sendedNews;
        }
    },
    created() {
        this.isImageForbidden = false;
        this.news = this.sendedNews;
    },
    watch:{
        $route (to, from){
            this.news = this.sendedNews;
        },
    },
    methods: {
        sharedNews(social) {
            alert('Congratulations, you shared the news in ' + social);
        },

        imgPlaceholder(e) {
            this.isImageForbidden = true;
            e.target.src = "https://via.placeholder.com/300"
        },
    }
}
</script>

<style scoped>
    .news {
        display: flex;
        flex-direction: row;
        width: 100%;
        margin-top: 55px;
        border: 1px solid #f0f0f0;
        padding: 5px;
        background-color: #ffffff;
    }

    .news-img {
        width: 350px;
        height: 300px;
    }

    h3 {
        font-size: 1.6vw;
    }

    p {
        display: block;
        font-size: 1vw;
        margin-top: 15px;
        height: 45px;
        overflow: hidden;
        text-overflow: clip;
    }

    .shared {
        position: absolute;
        bottom: 0;
        left: -10px;
    }

    .subscribe {
        position: absolute;
        bottom: 3.8em;
        left: 0;
        font-size: 14px;
        cursor: pointer;
    }

    .social {
        width: 20px;
        margin-left: 10px;
        cursor: pointer;
    }

    .news-info {
        position: relative;
        width: 50%;
        margin-left: 35px;
    }

    .btn-read {
        position: absolute;
        display: block;
        width: 6vw;
        padding: 5px;
        bottom: 0;
        right: 0;
        background-color: transparent;
        outline: none;
        border: 1px solid #d1d1d1;
        cursor: pointer;
        transition: .3s;
        margin-top: 5%;
        text-decoration: none;
        color: black;
        font-size: 1.3vw;
        margin-left: 60%;
        border-radius: 25px;
        margin-top: 10%;
    }

    .btn-read:hover {
        background-color: #f0f0f0;
    }

    .pablish-date {
        position: absolute;
        bottom: 2em;
        left: 0;
        font-size: 14px;
    }

    @media (max-width: 840px) {
        h3 {
            font-size: 16px;
        }

        p {
            font-size: 13px;
        }

        .btn-read {
            font-size: 17px;
            width: 80px;
            margin-top: 4%;
        }

        .news {
            margin-top: 30px;
        }
    }

    @media (max-width: 650px) {
        .news {
            justify-content: center;
            flex-direction: column;
            padding-bottom: 100px;
        }

        .news-img {
            width: 100%;
            height: 350px;
        }

        .pablish-date {
            bottom: -4.5em;
        }

        .news-info {
            width: 90%;
            margin-left: 5%;
        }

        h3 {
            margin-top: 5%;
            font-size: 26px;
        }

        p {
            display: inline;
            font-size: 16px;
        }

        .btn-read {
            font-size: 16px;
            width: 150px;
            margin: 0 auto;
            bottom: -5.5em;
        }

        .shared {
            bottom: -5.5em;
        }

        .subscribe {
            bottom: -2.9em;
        }
    }
</style>    