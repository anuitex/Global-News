<template>
  <div id="app">
    <CanvasBg v-show='isShowCanvas'></CanvasBg>
    <Header v-show='isShowHeaderAndFooter'></Header>
    <subscribeNotification :isUserSubscribe='isShowNotitfication' @showSubscribe='showSubscribe' class="notification"></subscribeNotification>
    <router-view @toggleHeadAndFoot='toggleHeadAndFoot' @hideAll='hideAll'/>
    <subscribeButton v-if='isShowSubButton' @showSubscribe='showSubscribe'></subscribeButton>
    <subscribe @closeSubscribe='closeSubscribe' class="subscribe" v-if='isShowSubscribe'></subscribe>
    <Footer v-show='isShowHeaderAndFooter' class="footer"></Footer>
  </div>
</template>

<script>
import Header from './shared/layouts/header/header';
import Footer from './shared/layouts/footer/footer';
import subscribeButton from './shared/components/subscribe-button';
import CanvasBg from './shared/components/canvas-bg';
import subscribe from './components/subscribe-popup/subscribe-popup';
import subscribeNotification from './shared/components/subscribe-notification';

export default {
  name: 'app',
  components: {
    Header,
    Footer,
    CanvasBg,
    subscribeButton,
    subscribe,
    subscribeNotification
  },
  data() {
    return {
      category: null,
      isShowHeaderAndFooter: true,
      isShowSubscribe: false,
      isShowNotitfication: true,
      isShowCanvas: true,
      isShowSubButton: true,
    }
  },
  created() {

  },
  methods: {
    updateCategory(e) {
      this.$emit('updateNews', e)
    },

    toggleHeadAndFoot(bool) {
      this.isShowHeaderAndFooter = bool
    },

    showSubscribe() {
      this.isShowSubscribe = true;
      this.isShowNotitfication = false;
    },

    closeSubscribe() {
      this.isShowSubscribe = false;
    },

    hideAll(bool) {
      this.isShowHeaderAndFooter = bool;
      this.isShowCanvas = bool;
      this.isShowNotitfication = bool;
      this.isShowSubButton = bool;
    }
  },
}
</script>

<style>
html, body {
  min-height: 100vh;
}

* {
  padding: 0;
  margin: 0;
}

#app {
  position: relative;
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  min-height:100vh;
}

.subscribe {
  z-index: 999;
}

.notification {
  z-index: 99;
}
</style>
