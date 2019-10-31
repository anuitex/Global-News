// Vendors
import Vue from "vue";
import App from "./App.vue";
import BootstrapVue from "bootstrap-vue";
import VueRouter from "vue-router";
import Slick from "vue-slick";
import vWow from "v-wow";
import AOS from 'aos';
import VueGeolocation from 'vue-browser-geolocation';
import SocialSharing from 'vue-social-sharing'
import VueMoment from 'vue-moment';
import Paginate from 'vuejs-paginate'

// Router
import routes from "./routes";
// Styles
import "bootstrap/dist/css/bootstrap.css";
import "bootstrap-vue/dist/bootstrap-vue.css";
import "animate.css";
import "aos/dist/aos.css";
import "./assets/css/global/global.css";
import "./assets/css/components/pagination.css";

// Store
import store from './store';

// Fonts
import { library } from "@fortawesome/fontawesome-svg-core";
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";
import {
  faCoffee,
  faSpinner,
  faEdit,
  faCircle,
  faCheck,
  faPlus,
  faEquals,
  faArrowRight,
  faPencilAlt,
  faComment
} from "@fortawesome/free-solid-svg-icons";
import { fas } from "@fortawesome/free-solid-svg-icons";
Vue.config.productionTip = false;

library.add(
  faCoffee,
  faSpinner,
  faEdit,
  faCircle,
  faCheck,
  faPlus,
  faEquals,
  faArrowRight,
  faPencilAlt,
  faComment,
  fas
);

Vue.component("font-awesome-icon", FontAwesomeIcon);
Vue.component('paginate', Paginate)
Vue.use(BootstrapVue);
Vue.use(VueRouter);
Vue.use(Slick);
Vue.use(vWow);
Vue.use(VueMoment);
Vue.use(VueGeolocation);
Vue.use(SocialSharing);

const router = new VueRouter({ routes });

new Vue({
  store,
  created() {
    AOS.init();
  },
  render: h => h(App),
  router
}).$mount("#app");
