<template>
    <div class="news-page">
        <div class="search-container">
            <img class="search-icon" src="../../assets/images/search-icon.png" alt="">
            <input class="search" type="text" placeholder="search" v-on:input="searchBytitle($event)" v-model='searchValue'>
        </div>
        <div class="news-content">
            <newsCard v-for="news of currentNews" :sendedNews='news'></newsCard>
        </div>
        <loader v-show="isLoaderShow" class="loader"></loader>

        <div v-if='isNothingFind' class="nothing-find">
            <h4>No Result</h4>
        </div>

        <div class="over-requests" v-if="isOverRequest">
            <h4>Sorry, but requests is over</h4>
        </div>
    </div>
</template>

<script>

import newsService from './../../shared/services/news.service';
import newsCard from './../../components/news-card/news-card';
import loader from './../../shared/components/loader';
import _ from 'lodash'

export default {
    name: 'Main',
    components: {
        newsCard,
        loader,
    },
    data() {
        return {
            currentNews: null,
            searchValue: '',
            cutegory: null,
            defaultCategory: 'health',
            isLoaderShow: true,
            isNothingFind: false,
            isOverRequest: false,
            page: 2,
        }
    },
    methods: {
        searchBytitle:_.debounce(function(event) {
            this.isLoaderShow = true;
            this.currentNews = [];
            this.searchValue = event.target.value;
                if (this.searchValue.length > 0) {
                    newsService.searchByTitle(this.searchValue).then((res) => {
                        this.currentNews = res.data.articles;
                        this.isLoaderShow = false;
                        if (this.currentNews.length === 0) {
                            this.isNothingFind = true;
                        }
                        this.isOverRequest = false;
                    }, (err) => {
                        if (err) {
                            this.isOverRequest = true;
                            this.isLoaderShow = false;
                        }
                    })
                } else if (this.searchValue.length === 0) {
                    newsService.getData(this.category, 1).then(res => {
                        this.currentNews = res.data.articles;
                        this.isLoaderShow = false;
                        this.isNothingFind = false;
                        this.isOverRequest = false
                    }, (err) => {
                        if (err) {
                            this.isOverRequest = true;
                            this.isLoaderShow = false;
                        }
                    });
                }
            }, 1000),
        scroll() {
            window.onscroll = () => {
                let bottomOfWindow = document.documentElement.scrollTop + window.innerHeight === document.documentElement.offsetHeight;
                if (bottomOfWindow) {
                    this.isLoaderShow = true;
                    newsService.getData(this.category, this.page).then(res => {
                        for (let i = 0; i < res.data.articles.length; i++) {
                            this.currentNews.push(res.data.articles[i]);
                        }
                        this.isLoaderShow = false;
                        this.isOverRequest = false
                    }, (err) => {
                        if (err) {
                            this.isOverRequest = true
                            this.isLoaderShow = false;
                        }
                    });

                    this.page += 1;
                }
            }
        },
    },
    mounted() {
        if (this.category) {
            this.currentCategory = this.category;
        }
        this.scroll();
    },
    created() {

        if (this.$route.params.category !== this.defaultCategory) {
            this.category = this.$route.params.category;
        }

        if (this.category) {
            this.isLoaderShow = true;
            newsService.getData(this.category, 1).then(res => {
                this.currentNews = res.data.articles;
                this.isLoaderShow = true;
                this.isOverRequest = false
            }, (err) => {
                    if (err) {
                        this.isOverRequest = true
                        this.isLoaderShow = false;
                    }
                });
        } else {
            this.isLoaderShow = true;
            newsService.getData(this.defaultCategory, 1).then(res => {
                this.currentNews = res.data.articles;
                this.isLoaderShow = true;
                this.isOverRequest = false
            }, (err) => {
                    if (err) {
                        this.isOverRequest = true
                        this.isLoaderShow = false;
                    }
                });
        };
    },
    watch:{
        $route (to, from){
            this.searchValue = '';
            if (to.params.category) {
                this.currentNews = [];
                this.category = to.params.category;
                this.isLoaderShow = true;
                this.isIndexPage = false;
                newsService.getData(this.category, 1).then(res => {
                    this.currentNews = res.data.articles;
                    this.isLoaderShow = false;
                    this.isOverRequest = false
                }, (err) => {
                    if (err) {
                        this.isOverRequest = true
                        this.isLoaderShow = false;
                    }
                });
            } 
        },
    },
}
</script>

<style scoped>
    .news-page {
        position: relative;
        display: flex;
        flex-direction: column;
        align-items: center;
        width: 70%;
        margin: 0 auto;
        padding-bottom: 250px
    }

    .search-container {
        display: flex;
        justify-content: flex-end;
        position: relative;
        width: 100%;
        margin-top: 80px;
    }

    .search {
        width: 15%;
        padding: 5px 10px;
        padding-right: 40px;
        border: none;
        border-bottom: 1px solid #d1d1d1;
        outline: none;
    }

    .loader {
        position: absolute;
        bottom: 175px;
    }

    .search-icon {
        position: absolute;
        width: 18px;
        margin: 4px 0 0 -10px;
    }

    @media (max-width: 840px) {
        .search {
            width: 35%;
        }

        .news-page {
            width: 95%;
            top: 0;
        }

        .news-content {
            margin-top: 20px;
        }

        .search-container {
            justify-content: center;
            margin-top: 110px;
            font-size: 18px;
        }

        .search-icon {
            margin: 12px 0 0 15%;
        }
    }

    @media (max-width: 650px) {
        .search-container {
            margin-top: 170px;
            font-size: 18px;
        }

        .search-container input {
            width: 60%;
        }

        .search-icon {
            margin: 12px 0 0 25%;
        }
    }
</style>