<template>
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
    <b-carousel-slide v-for="news of slidesNews" :key="news.title" :img-src="news.urlToImage">
      <div class="slide-title">
        <span>{{ news.title }}</span>
        <span class="slide-category general">{{ news.source.name }}</span>
      </div>
    </b-carousel-slide>
  </b-carousel>
</template>

<script>
export default {
  props: ["slidesNews"],
  name: "homeSlider"
};
</script>
<style>
/* Slider */
.carousel-caption {
  position: absolute;
  right: unset !important;
  bottom: 10% !important;
  left: 30px !important;
  z-index: 10;
  padding-top: 20px;
  padding-bottom: 20px;
  color: #fff;
  text-align: center;
}
.carousel-caption .slide-title {
  max-width: 400px;
  text-align: start;
  font-family: "Amiri-Bold";
}
.carousel-caption .slide-title span {
  font-size: 40px;
}

.carousel-caption .slide-title .slide-category {
  display: flex;
  flex-direction: column;
  font-size: 16px;
  text-align: start;
  letter-spacing: 5px;
  font-family: "Poppins-Medium";
  margin-left: 15px;
  margin-top: 20px;
}

.carousel-caption .slide-title .slide-category.general::before {
  content: "";
  width: 3px;
  height: 23px;
  background-color: #1bfe85;
  position: absolute;
  left: 0px;
}
.carousel-caption .slide-title .slide-category.entertainment::before {
  content: "";
  width: 3px;
  height: 23px;
  background-color: #ff995e;
  position: absolute;
  left: 0px;
}
.carousel-caption .slide-title .slide-category.science::before {
  content: "";
  width: 3px;
  height: 23px;
  background-color: #10c7ba;
  position: absolute;
  left: 0px;
}

.carousel-indicators {
  display: flex;
  align-items: center;
}
.carousel-indicators li {
  width: 7px !important;
  height: 7px !important;
  margin-right: 10px !important;
  margin-left: 10px !important;
  opacity: 0.7 !important;
  cursor: pointer;
  background-color: #f8c61a !important;
  background-clip: unset !important;
  border-radius: 10px;
  border-top: unset !important;
  border-bottom: unset !important;
}
.carousel-indicators .active {
  width: 12px !important;
  height: 12px !important;
}
.carousel-control-prev span,
.carousel-control-next span {
  display: none;
}
.carousel-control-prev,
.carousel-control-next {
  background: #453333;
  width: 50px !important;
  height: 50px !important;
  bottom: unset !important;
  top: 35px !important;
}
.carousel .carousel-control-prev {
  right: 100px !important;
  left: unset !important;
}
.carousel .carousel-control-next {
  right: 35px !important;
}
.carousel .carousel-control-prev::before {
  position: absolute;
  content: "";
  width: 20px;
  height: 20px;
  border-left: 2px solod red;
  border-top: 2px solod red;
  border-bottom: 3px solid;
  border-left: 3px solid;
  transform: rotate(45deg);
  left: 19px;
}
.carousel .carousel-control-next::after {
  position: absolute;
  content: "";
  width: 20px;
  height: 20px;
  border-left: 2px solod red;
  border-top: 2px solod red;
  border-bottom: 3px solid;
  border-left: 3px solid;
  transform: rotate(223deg);
  left: 12px;
}

@media (max-width: 1139px) {
  .carousel-caption .slide-title span {
    font-size: 22px !important;
  }

  .carousel-caption .slide-title .slide-category {
    font-size: 12px !important;
  }

  .carousel-caption .slide-title .slide-category::before {
    height: 19px !important;
  }
  .carousel-caption {
    bottom: 10% !important;
  }
  .slider-wrap .carousel-control-prev {
    width: 30px !important;
    height: 30px !important;
    right: 70px !important;
  }
  .slider-wrap .carousel-control-next {
    width: 30px !important;
    height: 30px !important;
    right: 25px !important;
  }

  .carousel .carousel-control-next::after {
    width: 10px !important;
    height: 10px !important;
    left: 8px !important;
  }
  .carousel .carousel-control-prev::before {
    width: 10px !important;
    height: 10px !important;
    left: 12px !important;
  }
}
@media (max-width: 767px) {
  .carousel-caption .slide-title span {
    font-size: 18px !important;
  }
  .carousel-caption {
    bottom: 10% !important;
  }
}
@media (max-width: 575px) {
  .carousel-caption .slide-title span {
    font-size: 16px !important;
  }
  .carousel-caption .slide-title .slide-category {
    font-size: 8px !important;
    margin-top: 10px !important;
  }
  .carousel-caption .slide-title .slide-category::before {
    height: 10px !important;
  }
}
@media (max-width: 450px) {
  .carousel-caption .slide-title span {
    font-size: 12px !important;
  }
  .carousel-caption .slide-title .slide-category {
    font-size: 5px !important;
  }
  .carousel-caption .slide-title .slide-category::before {
    height: 7px !important;
  }
}

@media (max-width: 375px) {
  .slider-wrap .carousel-control-prev {
    width: 25px !important;
    height: 25px !important;
  }
  .slider-wrap .carousel-control-next {
    width: 25px !important;
    height: 25px !important;
  }

  .carousel .carousel-control-next::after {
    width: 10px !important;
    height: 10px !important;
    left: 6px !important;
  }
  .carousel .carousel-control-prev::before {
    width: 10px !important;
    height: 10px !important;
    left: 10px !important;
  }
}
</style>

