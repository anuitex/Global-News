<template>
    <div class="bottom-menu-wrap">
        <div class="container">
        <div class="box-menu">
            <b-nav class="bottom-menu">
            <b-nav-item>
                <router-link class="link" :to="{ name: `category`, params: {category: 'business'} }">Business</router-link>
            </b-nav-item>
            <b-nav-item>
                <router-link class="link" :to="{ name: `category`, params: {category: 'entertainment'} }">Entertainment</router-link>
            </b-nav-item>
            <b-nav-item>
                <router-link class="link" :to="{ name: `category`, params: {category: 'general'} }">General</router-link>
            </b-nav-item>
            <b-nav-item>
                <router-link class="link" :to="{ name: `category`, params: {category: 'health'} }">Health</router-link>
            </b-nav-item>
            <b-nav-item>
                <router-link class="link" :to="{ name: `category`, params: {category: 'science'} }">Science</router-link>
            </b-nav-item>
            <b-nav-item>
                <router-link class="link" :to="{ name: `category`, params: {category: 'sport'} }">Sport</router-link>
            </b-nav-item>
            <b-nav-item>
                <router-link class="link" :to="{ name: `category`, params: {category: 'technology'} }">Technology</router-link>
            </b-nav-item>
            </b-nav>
        </div>
        </div>
    </div>
</template>

<script>
export default {
    name: 'navigationDesctop'
}
</script>

<style scoped>
/* Bottom menu */
.bottom-menu-wrap {
  height: 120px;
  display: flex;
  align-items: center;
}
.bottom-menu-wrap {
  font-family: "Amiri-Bold";
}

@media (max-width: 1199px) {
  .bottom-menu-wrap .bottom-menu li a {
    font-size: 22px !important;
  }
}

@media (max-width: 1139px) {
  .bottom-menu-wrap .bottom-menu li a {
    font-size: 18px;
  }
  .bottom-menu-wrap {
    height: 100px;
  }
}

@media (max-width: 991px) {
  .bottom-menu-wrap .bottom-menu li a {
    font-size: 15px !important;
  }
}

@media (max-width: 767px) {
  .bottom-menu-wrap .bottom-menu {
    flex-wrap: unset;
  }
  .bottom-menu-wrap .box-menu {
    overflow: scroll !important;
    display: flex;
  }
}


/* end */

.bottom-menu {
  background-color: unset !important;
  justify-content: center !important;
}
.bottom-menu li a a {
  color: #3f3f3f;
  font-size: 26px;
  font-weight: bold;
  text-decoration: none;
}
.bottom-menu li a:hover {
  color: #f8c61a !important;
}

.bottom-menu-wrap {
  height: 120px;
  display: flex;
  align-items: center;
}

@media (max-width: 1199px) {
  .bottom-menu ul li a span {
    font-size: 23px;
  }
}
@media (max-width: 991px) {
  .bottom-menu ul li a span {
    font-size: 17px;
  }
}
</style>