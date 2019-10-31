<template>
<div>
  <paginate
      :page-count="pageNumber"
      :page-range="3"
      :margin-pages="1"
      :click-handler="clickCallback"
      :container-class="'pagination-wrap'"
      :page-class="'page-number'"
      :active-class="'active'"
      :no-li-surround="false">
  </paginate>

  <!-- <div class="pagination-wrap">
        <button class="double-arrow-left"></button>
        <button class="arrow-left"></button>

        <div class="numbers-wrap">
          <button href="#" class="page-number">
            <span class="value">1</span>
          </button>
          <button href="#" class="page-number active">
            <span class="value">2</span>
          </button>
          <button href="#" class="page-number">
            <span class="value">3</span>
          </button>

          <div class="separator-wrap">
            <span class="separator">...</span>
          </div>

          <button href="#" class="page-number">
            <span class="value">16</span>
          </button>
        </div>

        <button href="#" class="arrow-right"></button>
        <button href="#" class="double-arrow-right"></button>
      </div> -->
</div>
</template>

<script>
export default {
    props: ['pageNumber'],
    name: 'categoryPagination',
    methods: {
        clickCallback (pageNum) {
            this.$emit('changePage', pageNum)
        }
    }
}
</script>

<style scoped>
/*----------------------------------*/

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
  list-style: none;
}
.pagination-wrap button {
  background-color: unset;
}

.page-number {
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
</style>