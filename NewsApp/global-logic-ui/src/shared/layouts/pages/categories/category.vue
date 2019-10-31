<template>
    <div class="container content">
      <!-- Top title -->
      <div class="main-title-wrap">
        <span class="text">{{ category | titleToUpperCase }}</span>
      </div>

      <!-- Top-box with 4 images -->
      <div class="top-box-preview row">
        <div class="left-side col-md-6 box-item">
          <div class="hover-link">
            <button @click='goToCurrentNews(firstBlock)'>Read More</button>
          </div>
          <div class="gradient"></div>
          <div class="image-box">
            <img :src="firstBlock.urlToImage" />
          </div>
          <div class="title-wrap">
            <span class="title">
              <p>{{firstBlock.title}}</p>
            </span>
          </div>
        </div>
        <div class="right-side col-md-6">
          <div class="image-wrap right-side-top">
            <div class="box-item">
              <div class="hover-link"> 
                <button @click='goToCurrentNews(secoundBlock)'>Read More</button>
              </div>
              <div class="gradient"></div>
              <div class="image-box">
                <img :src="secoundBlock.urlToImage" />
              </div>
              <div class="title-wrap">
                <span class="title">
                  <p>{{secoundBlock.title}}</p>
                </span>
              </div>
            </div>
          </div>
          <div class="right-side-bottom row">
            <div class="image-wrap col-md-6 col-sm-6 box-item">
              <div class="hover-link">
                <button @click='goToCurrentNews(thirdBlock)'>Read More</button>
              </div>
              <div class="gradient"></div>
              <div class="image-box">
                <img :src="thirdBlock.urlToImage" />
              </div>
              <div class="title-wrap">
                <span class="title">
                  <p>{{thirdBlock.title}}</p>
                </span>
              </div>
            </div>
            <div class="image-wrap col-md-6 col-sm-6 box-item">
              <div class="hover-link">
                <button @click='goToCurrentNews(fourthBlock)'>Read More</button>
              </div>
              <div class="gradient"></div>
              <div class="image-box">
                <img :src="fourthBlock.urlToImage" />
              </div>
              <div class="title-wrap">
                <span class="title">
                  <p>{{fourthBlock.title}}</p>
                </span>
              </div>
            </div>
          </div>
        </div>
      </div>

      <!-- All News -->
      <b-card-group deck row>
        <div class="col-md-4" v-for='news of currentNews' v-bind:key='news.title' @click='goToCurrentNews(news)'>
          <b-card class="mb-2 new-card">
            <div class="image-wrap">
              <div class="gradient"></div>
              <b-card-img
                :src="news.urlToImage"
              ></b-card-img>
              <div class="title-wrap">
                <span class="title">
                  <p>{{ news.title }}</p>
                </span>
              </div>
            </div>
            <div class="text-wrap">
              <b-card-text>
                {{ news.content }}
              </b-card-text>
            </div>
            <template v-slot:footer>
              <small class="text-muted">6 min ago</small>
              <small class="text-muted">bbc.com</small>
            </template>
          </b-card>
        </div>
      </b-card-group>

      <categoryPagination :pageNumber='pageNumber' @changePage='changePage'></categoryPagination>
    </div>
</template>

<script>
import newsService from './../../../services/news.service';
import categoryPagination from './../../../components/paginate';

export default {
    name: 'currentCategory',
    components: {
      categoryPagination
    },
    data() {
        return {
            currentNews: [],
            category: null,
            firstBlock: {
              title: '',
              urlToImage: ''
            },
            secoundBlock: {
              title: '',
              urlToImage: ''
            },
            thirdBlock: {
              title: '',
              urlToImage: ''
            },
            fourthBlock: {
              title: '',
              urlToImage: ''
            },
            pageNumber: 0,
        }
    },
    beforeCreate() {
        this.category = this.$route.params.category;

        newsService.getData(this.category, 1).then(res => {
          const totalResult = res.data.totalResults;
          this.pageNumber = Math.ceil(totalResult / 16);
          let articles = res.data.articles;
          // this.firstBlock = articles[0];
          // this.secoundBlock = articles[1];
          // this.thirdBlock = articles[2];
          // this.fourthBlock = articles[3];
            for (let i = 0; i < 16; i++) {
              if (articles[i].urlToImage) {
                // adding to main articles
                if(!this.firstBlock.urlToImage) {
                  this.firstBlock = articles[i];
                } else if(!this.secoundBlock.urlToImage) {
                  this.secoundBlock = articles[i];
                } else if(!this.thirdBlock.urlToImage) {
                  this.thirdBlock = articles[i];
                } else if(!this.fourthBlock.urlToImage) {
                  this.fourthBlock = articles[i];
                }

                this.currentNews.push(articles[i])
              } else {
                continue;
              }
            }
            }, (err) => {
                console.log(err);
            });
    },
    watch:{
        $route (to){
            if (to.params.category) {
                this.currentNews = [];
                this.category = to.params.category;
                // let newsCol = 3;
                newsService.getData(this.category, 1).then(res => {   
                  let articles = res.data.articles;               
                    for (let i = 0; i < 16; i++) {
                      if (articles[i].urlToImage) {
                        // adding to main articles
                        if(!this.firstBlock.urlToImage) {
                          this.firstBlock = articles[i];
                        } else if(!this.secoundBlock.urlToImage) {
                          this.secoundBlock = articles[i];
                        } else if(!this.thirdBlock.urlToImage) {
                          this.thirdBlock = articles[i];
                        } else if(!this.fourthBlock.urlToImage) {
                          this.fourthBlock = articles[i];
                        }

                        this.currentNews.push(articles[i])
                      } else {
                        continue;
                      }
                    }
                }, (err) => {
                    console.log(err);
                });
            } 
        },
    },
    methods: {
      changePage(e) {
        window.scrollTo(0,0)
        newsService.getData(this.category, e).then(res => {
          let articles = res.data.articles;
          this.currentNews = [];
          this.firstBlock = res.data.articles[0];
          this.secoundBlock = res.data.articles[1];
          this.thirdBlock = res.data.articles[2];
          this.fourthBlock = res.data.articles[3];
            for (let i = 0; i < 16; i++) {
              if (articles[i].urlToImage) {
                // adding to main articles
                if(!this.firstBlock.urlToImage) {
                  this.firstBlock = articles[i];
                } else if(!this.secoundBlock.urlToImage) {
                  this.secoundBlock = articles[i];
                } else if(!this.thirdBlock.urlToImage) {
                  this.thirdBlock = articles[i];
                } else if(!this.fourthBlock.urlToImage) {
                  this.fourthBlock = articles[i];
                }

                this.currentNews.push(articles[i])
              } else {
                continue;
              }
            }
            }, (err) => {
                console.log(err);
            });
      },

        goToCurrentNews(news) {
          const category = this.category;
          this.$router.push({name: 'news-info', params: {news, category}})
        }
    },
    filters: {
      titleToUpperCase: function(value) {
        if (!value) return '';
        value = value.toString().toUpperCase();
        return value;
      }
    },
    mounted() {
      this.category = this.$route.params.category;
    }
}
</script>

<style scoped>
@media (min-width: 1140px) {
  .container {
    max-width: 1638px !important;
  }
}

@media (max-width: 1139px) {
  .container {
    max-width: 814px !important;
  }
  .main-title-wrap span {
    font-size: 24px !important;
    letter-spacing: 8px !important;
  }
  .main-title-wrap span::before {
    height: 27px !important;
    width: 95px !important;
  }
}
@media (max-width: 767px) {
  .main-title-wrap span {
    font-size: 24px !important;
  }
}
@media (max-width: 499px) {
  .main-title-wrap span {
    font-size: 20px !important;
    letter-spacing: 6px !important;
  }
  .main-title-wrap span::before {
    height: 21px !important;
    width: 94px !important;
  }
}
@media (max-width: 375px) {
  .main-title-wrap span {
    font-size: 16px !important;
    letter-spacing: 5px !important;
  }
  .main-title-wrap span::before {
    height: 16px !important;
    width: 92px !important;
  }
}

@media (max-width: 374px) {
  .pagination-wrap button {
    width: 25px !important;
    height: 25px !important;
  }
}
/* Top-box with 4 images*/
@media (max-width: 1199px) {
  .top-box-preview .title-wrap {
    bottom: 15px !important;
  }

  .top-box-preview .left-side .title-wrap span {
    font-size: 20px !important;
  }

  .top-box-preview .right-side-top .title-wrap span,
  .top-box-preview .right-side-bottom .title-wrap span {
    font-size: 15px !important;
  }
}

@media (max-width: 1139px) {
  .top-box-preview .left-side .title-wrap span {
    font-size: 20px !important;
  }

  .top-box-preview .right-side-top .title-wrap span,
  .top-box-preview .right-side-bottom .title-wrap span {
    font-size: 10px !important;
  }
}

@media (max-width: 992px) {
  .top-box-preview .title-wrap span {
    font-size: 12px !important;
  }
  .top-box-preview .title-wrap {
    left: 30px !important;
    bottom: 15px !important;
  }
}

@media (max-width: 767px) {
  .left-side .title-wrap {
    max-width: 85%;
  }
  .right-side-top {
    margin: 10px 0;
  }
  .top-box-preview {
    margin-bottom: 20px !important;
    margin-top: 20px !important;
  }

  .top-box-preview .title-wrap {
    left: 40px !important;
  }

  .top-box-preview .title-wrap span {
    font-size: 20px !important;
  }
}

@media (max-width: 575px) {
  .top-box-preview .right-side-top .title-wrap span,
  .top-box-preview .right-side-bottom .title-wrap span {
    font-size: 22px !important;
  }

  .left-side .title-wrap {
    max-width: 76%;
  }

  .right-side-bottom .image-wrap {
    margin-bottom: 10px;
  }
}

@media (max-width: 450px) {
  .top-box-preview .right-side-top .title-wrap span,
  .top-box-preview .right-side-bottom .title-wrap span {
    font-size: 16px !important;
  }

  .top-box-preview .left-side .title-wrap span {
    font-size: 16px !important;
  }
}

@media (max-width: 350px) {
  .top-box-preview .right-side-top .title-wrap span,
  .top-box-preview .right-side-bottom .title-wrap span {
    font-size: 12px !important;
  }

  .top-box-preview .left-side .title-wrap span {
    font-size: 12px !important;
  }
}

@media (max-width: 419px) {
  .left-side .title-wrap span,
  .right-side-top .title-wrap span,
  .right-side-bottom .title-wrap span,
  .new-card .title-wrap span {
    font-size: 14px !important;
  }
}

.right-side-top .title-wrap {
  left: 30px !important;
  width: 85%;
}

.right-side-top .hover-link {
  right: 0 !important;
  left: 0 !important;
  z-index: 999;
}
.right-side-top .gradient {
  margin: 0;
}

.right-side-top .hover-link button {
  height: 15% !important;
}

.content .top-box-preview .hover-link button {
  opacity: 0;
  width: 65%;
  height: 10%;
  background-color: #f8c61a;
  border: none;
  font-size: 20px;
  font-weight: bold;
  text-transform: uppercase;
  color: #052962;
  letter-spacing: 2px;
  cursor: pointer;
  z-index: 999;
}
.content .top-box-preview .hover-link {
  z-index: 999;
  display: flex;
  visibility: hidden;
  align-items: center;
  justify-content: center;
  position: absolute;
  bottom: 0;
  top: 0;
  left: 15px;
  right: 15px;
  position: absolute;
  background-color: rgba(0, 0, 0, 0.6);
  background: rgba(0, 0, 0, 0.6);
  color: rgba(0, 0, 0, 0.6);
}

.content .top-box-preview .box-item:hover .hover-link {
  visibility: visible;
  z-index: 999;
  transition: all 0.5s;
}

.content .top-box-preview .box-item:hover .hover-link button {
  opacity: 1;
  transition: all 1s;
}

.content .top-box-preview .box-item:hover img {
  transform: scale(1.1);
  transition: transform 1s;
}

.content .main-title-wrap .text {
  position: relative;
  font-size: 36px;
  font-weight: bold;
  text-transform: uppercase;
  letter-spacing: 10px;
  padding-left: 86px;
}

.content .main-title-wrap .text::before {
  z-index: -1;
  position: absolute;
  content: "";
  width: 102px;
  height: 37px;
  background-color: #c710a2;
  left: 0;
  top: 0;
}

.content .top-box-preview {
  margin-top: 42px;
  margin-bottom: 60px;
  display: flex;
  justify-content: space-between;
}

.content .top-box-preview img {
  width: 100%;
    height: 100%;
    -o-object-fit: cover;
    object-fit: cover;
}

.left-side {
  position: relative;
}

.left-side .image-box,
.right-side .image-box,
.right-side-bottom .image-box {
  overflow: hidden;
  height:100%;
}

.right-side {
  display: flex;
  flex-direction: column;
  justify-content: space-between;
}

.right-side .image-wrap {
  position: relative;
}

.right-side-bottom {
  display: flex;
  justify-content: space-between;
  margin-top:30px;
}

.right-side .right-side-top .gradint {
  margin: 0;
}

.right-side .right-side-top .title-wrap span,
.right-side .right-side-bottom .title-wrap span {
  font-size: 20px;
}

.right-side .right-side-bottom .title-wrap {
  width: 76%;
}

.description-wrap {
  margin-top: 20px;
  padding-bottom: 10px;
  border-bottom: 1px solid #d5d3d3;
}

.elem-wrap .image-wrap {
  position: relative;
}

.gradient {
  position: absolute;
  top: 0bott;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
  background: rgb(0, 0, 0);
  background: linear-gradient(
    0deg,
    rgba(0, 0, 0, 0.9416141456582633) 0%,
    rgba(255, 255, 255, 0) 30%
  );
  margin: 0 15px;
}

.top-box-preview .left-side {
  position: relative;
}
.top-box-preview .title-wrap {
  position: absolute;
  bottom: 30px;
  left: 50px;
}

.top-box-preview .title-wrap span {
  color: white;
  text-align: start;
  font-weight: bold;
  font-size: 32px;
}

.top-box-preview .title-wrap span p {
  margin-bottom: 5px;
}

.elem-wrap .image-wrap .title-wrap {
  position: absolute;
  bottom: 25px;
  left: 25px;
}

.elem-wrap .image-wrap .title-wrap span {
  color: white;
  text-align: start;
  font-weight: bold;
  font-size: 20px;
}

.elem-wrap .image-wrap .title-wrap span p {
  margin-bottom: 5px;
}

.container.content {
  max-width: 1638px;
}

.pagination-wrap .separator-wrap {
  display: inline-flex;
  vertical-align: top;
}

.pagination-wrap .separator-wrap .separator {
  margin-top: 5px;
}

.pagination-wrap .numbers-wrap .separator {
  font-size: 22px;
  font-weight: bold;
}

.pagination-wrap .numbers-wrap button {
  margin-top: 11px;
  margin-left: 5px;
  margin-right: 8px;
}

.pagination-wrap {
  display: flex;
  justify-content: center;
  align-items: center;
}
.pagination-wrap button {
  background-color: unset;
}

.pagination-wrap .page-number {
  position: relative;
  padding: 0;
  font-size: 20px;
  font-weight: bold;
  color: #052962;
  width: 32px;
  height: 32px;
  border-radius: 25px;
  border: 1px solid transparent;
}

.pagination-wrap .page-number.active {
  background-color: #052962;
}
.pagination-wrap .page-number.active span {
  color: #f8c61a;
}

.pagination-wrap .page-number span {
  position: absolute;
  top: 43%;
  left: 50%;
  transform: translate(-50%, -50%);
}

.pagination-wrap .page-number:hover {
  border: 1px solid #052962;
}

.pagination-wrap .double-arrow-right {
  position: relative;
  padding: 0;
  display: inline-flex;
  border: none;
  width: 30px;
  height: 30px;
}

.pagination-wrap .double-arrow-right::before {
  padding: 0;
  display: inline-flex;
  border: none;
  content: "";
  width: 8px;
  height: 8px;
  border-right: 2px solid #052962;
  border-bottom: 2px solid #052962;
  transform: rotate(-45deg);
  position: absolute;
  right: 7px;
  top: 10px;
}

.pagination-wrap .double-arrow-right::after {
  padding: 0;
  display: inline-flex;
  border: none;
  content: "";
  width: 8px;
  height: 8px;
  border-right: 2px solid #052962;
  border-bottom: 2px solid #052962;
  transform: rotate(-45deg);
  position: absolute;
  right: 15px;
  top: 10px;
}

.pagination-wrap .double-arrow-left {
  position: relative;
  padding: 0;
  display: inline-flex;
  border: none;
  width: 30px;
  height: 30px;
}

.pagination-wrap .double-arrow-left::before {
  padding: 0;
  display: inline-flex;
  border: none;
  content: "";
  width: 8px;
  height: 8px;
  border-left: 2px solid #052962;
  border-bottom: 2px solid #052962;
  transform: rotate(45deg);
  position: absolute;
  left: 7px;
  top: 10px;
}

.pagination-wrap .double-arrow-left::after {
  padding: 0;
  display: inline-flex;
  border: none;
  content: "";
  width: 8px;
  height: 8px;
  border-left: 2px solid #052962;
  border-bottom: 2px solid #052962;
  transform: rotate(45deg);
  position: absolute;
  left: 15px;
  top: 10px;
}

.pagination-wrap .arrow-left {
  position: relative;
  padding: 0;
  display: inline-flex;
  border: none;
  width: 30px;
  height: 30px;
}

.pagination-wrap .arrow-left::before {
  padding: 0;
  display: inline-flex;
  border: none;
  content: "";
  width: 8px;
  height: 8px;
  border-left: 2px solid #052962;
  border-bottom: 2px solid #052962;
  transform: rotate(45deg);
  position: absolute;
  right: 8px;
  top: 10px;
}

.pagination-wrap .arrow-right {
  position: relative;
  padding: 0;
  display: -webkit-inline-box;
  display: -ms-inline-flexbox;
  display: inline-flex;
  border: none;
  width: 30px;
  height: 30px;
}

.pagination-wrap .arrow-right::before {
  padding: 0;
  display: inline-flex;
  border: none;
  content: "";
  width: 8px;
  height: 8px;
  border-right: 2px solid #052962;
  border-bottom: 2px solid #052962;
  transform: rotate(-45deg);
  position: absolute;
  left: 8px;
  top: 10px;
}

.new-card {
  border: none !important;
}
.new-card .text-wrap p {
  max-block-size: 70px;
  overflow: hidden;
}
.new-card .card-body {
  padding: 0 !important;
}
.new-card .image-wrap {
  position: relative;
  height:330px;
}

.new-card .image-wrap img{
      width: 100%;
    height: 100%;
    -o-object-fit: cover;
    object-fit: cover;
}
.card-deck {
  margin-bottom: 60px;
}

.card-deck .card{
  margin-left: 0;
  margin-right: 0;
}
.card-deck .card-body .image-wrap .gradient {
  margin: 0;
}
.new-card .title-wrap {
  position: absolute;
  bottom: 10px;
  font-size: 20px;
  color: white;
  font-size: bold;
  text-align: start;
  left: 25px;
  bottom: 25px;
}
.new-card .title-wrap p {
  margin-bottom: 0;
}
.new-card .card-footer {
  background: transparent;
  text-align: start;
  padding-left: 0;
  padding-right: 0;
  display: flex;
  justify-content: space-between;
}
.new-card .card-text {
  padding: 18px 0 13px 0;
  text-align: start;
  border: none;
}
.new-card .text-wrap {
  border-bottom: 1px solid #b3abab;
  padding-bottom: 10px;
}
@media (max-width: 1199px) {
  .new-card .title-wrap {
    max-width: 86%;
  }
}
@media (max-width: 1139px) {
  .new-card .title-wrap {
    font-size: 12px !important;
  }
  .new-card .title-wrap {
    max-width: 78%;
  }

  .new-card .image-wrap{
    height:200px !important;
  }
}
@media (max-width: 767px) {
  .new-card .title-wrap {
    font-size: 22px !important;
  }
  .new-card {
    margin-bottom: 30px !important;
  }
}
</style>