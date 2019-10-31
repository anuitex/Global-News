<template>
  <div class="business-wrap">
    <div
      class="title-wrap"
      data-aos="fade-right"
      v-bind:style="titleBorder ? {borderLeft: '5px solid #' + titleBorder} : {}"
    >
      <span class="title-text">{{ title }}</span>
    </div>
    <slick
      ref="slick"
      :options="slickOptions"
      class="slick"
      v-if="sendedNews.length"
      data-aos="fade-up"
      data-aos-easing="ease-in-out"
      data-aos-mirror="true"
      data-aos-once="false"
    >
      <div
        class="card-wrap"
        v-for="news of sendedNews"
        v-bind:key="news.title"
        @click="goToCurrentNews(news)"
      >
        <b-card class="mb-2 new-card new-card col-md-12">
          <div class="image-wrap">
            <b-card-title>{{ news.title }}</b-card-title>
            <b-card-img class="card-image" :src="news.urlToImage"></b-card-img>
          </div>

          <b-card-text>{{ news.description }}</b-card-text>
          <template v-slot:footer>
            <small class="text-muted">{{ news.publishedAt | moment("from", "now") }}</small>
            <small class="text-muted">{{ news.source.name }}</small>
          </template>
        </b-card>
      </div>
    </slick>
  </div>
</template>

<script>
import Slick from "vue-slick";

export default {
  components: {
    Slick
  },
  name: "card",
  props: ["sendedNews", "title", "titleBorder", 'category'],
  data() {
    return {
      slickOptions: {
        slidesToShow: 3,
        infinite: true,
        accessibility: true,
        adaptiveHeight: true,
        arrows: true,
        dots: true,
        draggable: true,
        edgeFriction: 0.3,
        swipe: true,
        responsive: [
          {
            breakpoint: 768,
            settings: {
              slidesToShow: 1
            }
          }
        ]
      }
    };
  },
  methods: {
    goToCurrentNews(news) {
      let category = this.category;
      this.$router.push({ name: "news-info", params: { news, category } });
    }
  }
};
</script>

<style scoped>
@import "../../../node_modules/slick-carousel/slick/slick.css";

@media (max-width: 1199px) {
  .business-wrap .title-wrap .title-text,
  .entertainment-wrap .title-wrap .title-text,
  .science-wrap .title-wrap .title-text {
    font-size: 28px !important;
  }

  .card-title {
    font-size: 16px !important;
  }
}
@media (max-width: 1139px) {
  .business-wrap .title-wrap .title-text,
  .entertainment-wrap .title-wrap .title-text,
  .science-wrap .title-wrap .title-text {
    font-size: 20px !important;
  }
  .image-wrap {
    width: 245px !important;
    max-height: 245px !important;
  }
  .card-title {
    font-size: 12px !important;
  }
  .card-body {
    height: 325px !important;
  }
}
@media (max-width: 767px) {
  .business-wrap .title-wrap .title-text,
  .entertainment-wrap .title-wrap .title-text,
  .science-wrap .title-wrap .title-text {
    font-size: 16px !important;
  }
  .business-wrap,
  .entertainment-wrap,
  .science-wrap {
    margin-top: 30px !important;
  }
  .card-title {
    font-size: 16px !important;
  }
  .image-wrap {
    width: unset !important;
    height: unset !important;
    max-height: unset !important;
  }
}
@media (max-width: 575px) {
  .business-wrap .title-wrap .title-text,
  .entertainment-wrap .title-wrap .title-text,
  .science-wrap .title-wrap .title-text {
    font-size: 12px !important;
    letter-spacing: 5px !important;
  }
  .slick-slider {
    margin-top: 20px;
  }
}

.elem-wrap {
  max-width: 526px;
}
.elem-wrap img {
  width: 100%;
}
.description-wrap {
  padding: 19px 0 10px 0;
  border-bottom: 2px solid #b3abab;
}
.creator-info {
  display: flex;
  justify-content: space-between;
  padding-top: 15px;
}
.description-wrap span {
  font-size: 16px;
  font-weight: bold;
}
.card-deck {
  margin-top: 30px;
}
.image-wrap {
  height: 330px;
  position: relative;
}

.image-wrap img {
  width: 100%;
  height: 100%;
  object-fit: cover;
}
.card-text-wrap {
  padding-bottom: 10px;
}

.card-title {
  position: absolute;
  color: white;
  font-family: "Amiri-Bold";
  font-size: 20px;
  padding: 0 35px;
  bottom: 10px;
  padding-left: 15px;
}
.card-text {
  padding: 19px 0 10px 0;
  max-height: 70px;
  overflow: hidden;
  border-bottom: none;
  font-family: "Poppins-Regular";
  font-size: 16px;
}
.card-footer {
  padding: 15px 0 0 0 !important;
  background-color: unset !important;
  display: flex;
  justify-content: space-between;
  border-top: 2px solid #b3abab;
}
.new-card {
  margin: 0 auto !important;
  max-width: 526px !important;
  border: none !important;
  padding-bottom: 15px;
}

.new-card .card-body {
  padding: 0 !important;
  height: 408px;
}

.entertainment-wrap {
  margin-top: 60px;
  text-align: start;
}
.entertainment-wrap .title-wrap .title-text {
  display: block;
  font-size: 32px;
  font-family: "Poppins-Bold";
  text-transform: uppercase;
  letter-spacing: 10px;
  padding: 6px 30px;
}

.slick-slider {
  margin-top: 30px;
}
.slick-slider .slick-dots {
  display: none !important;
}
.slick-slider button.slick-prev,
.slick-slider button.slick-next:focus {
  outline: none;
}
.slick-slider button.slick-prev {
  position: absolute;
  top: -49px;
  right: 50px;
  color: transparent;
  background: transparent;
  border: none;
  width: 30px;
}
.slick-slider button.slick-prev::before {
  right: 8px;
  position: absolute;
  content: "";
  width: 10px;
  height: 10px;
  border-left: 2px solid #4e3535;
  border-bottom: 2px solid #4e3535;
  transform: rotate(45deg);
  top: 8px;
}
.slick-slider button.slick-next {
  position: absolute;
  top: -49px;
  right: 15px;
  color: transparent;
  background: transparent;
  border: none;
  width: 30px;
}
.slick-slider button.slick-next::before {
  position: absolute;
  content: "";
  width: 10px;
  height: 10px;
  border-right: 2px solid #4e3535;
  border-bottom: 2px solid #4e3535;
  transform: rotate(-45deg);
  top: 8px;
  left: 8px;
}
</style>