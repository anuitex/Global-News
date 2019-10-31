<script>
import axios from 'axios';
import {environment} from './../../environment/environment'

export default {
    name: 'newsService',
    getData(category, page, someFilter) {
        return axios.get(`${environment.newsApiUrl}top-headlines?category=${category}&pageSize=16&page=${page}&country=us&${someFilter}&apiKey=${environment.newsApiKey}`);
    },

    getTopNews(someFilter) {
        return axios.get(`${environment.newsApiUrl}top-headlines?country=us&${someFilter}apiKey=${environment.newsApiKey}`);
    },

    searchByTitle(text) {
        return axios.get(`${environment.newsApiUrl}everything?qInTitle=${text}&apiKey=${environment.newsApiKey}`);
    },

    getPageCol(category) {
        return axios.get(`${environment.newsApiUrl}top-headlines?category=${category}&apiKey=${environment.newsApiKey}`)
    }
}
</script>