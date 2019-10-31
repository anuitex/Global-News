<template>
    <div class="news">
        <img class="news-img" :src="currentNews.urlToImage" alt="">
        <div class="news-helpers">
            <span class="pablish-date">{{ news.publishedAt | moment("from", "now") }}</span>
            <social-sharing url="https://mySait.org/"
                      :title="currentNews.title"
                      :description="currentNews.description"
                      hashtags="news"
                      inline-template class="shared">
                <div>
                    <network network="facebook" class="social">
                        <img class="social" src="./../../assets/images/facebook-48.png" alt="facebooke">
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
        <div class="news-info">
            <h2>{{ currentNews.title }}</h2>
            <p>{{ currentNews.content }}</p>
        </div>
    </div>
</template>

<script>
export default {
    name: 'News',
    props: ['news'],
    data() {
        return {
            currentNews: {
                urlToImage: '',
                title: '',
                content: ''
            }
        }
    },
    mounted() {
        if (this.news) {
            this.currentNews = this.news;
        }
    },
    methods: {
        sharedNews(social) {
            alert('Congratulations, you shared the news in ' + social);
        }
    },
    created() {
        if (!this.news) {
            this.$router.push({name: 'Home'})
        }
    }
    
}
</script>

<style scoped>
    .news {
        position: relative;
        width: 70%;
        margin: 0 auto;
        padding-bottom: 140px;
    }

    .news-img {
        margin-top: 125px;
        max-width: 1000px;
        width: 75%;
    }

    .news-info {
        background-color: #ffffff;   
    }

    h2 {
        margin-top: 25px;
        font-size: 27px;
    }

    p {
        margin-top: 25px;
        font-size: 18px;
    }

    .news-helpers {
        display: flex;
        flex-direction: row;
        justify-content: space-around;
        margin-top: 15px;
    }

    .social {
        width: 20px;
        margin-left: 10px;
        cursor: pointer;
    }

    @media (max-width: 840px) {
        .news {
            height: 100%;
            width: 100%;
        }

        .news-img {
            width: 100%;
            margin-top: 150px;
        }

        h2 {
            font-size: 19px;
        }

        p {
            font-size: 16px;
        }
    }

    @media (max-width: 650px) {
        h2 {
            font-size: 26px;
        }

        p {
            font-size: 16px;
        }

        .news {
            padding-bottom: 100px;
        }
    }
</style>