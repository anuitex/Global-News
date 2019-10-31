import newsService from './../../shared/services/news.service';

export default {
    actions: {
        async getNewsForHomePage(ctx, data) {
            newsService.getData(data.category, 1).then((res) => {
            let newsCol = data.limit;
            let news = [];
                for (let i = 0; i < newsCol; i++) {
                    if (res.data.articles[i].urlToImage) {
                        news.push(res.data.articles[i])

                    } else {
                        newsCol += 1;
                        continue;
                    }
                }

                ctx.commit('updateNews', news);
            })
        }
    },
    mutations: {
        updateNews(state, news) {
            state.news = news;
        }
    },
    state: {
        news: []
    },
    getters: {
        getNews(state) {
            return state.news 
        }
    },
}