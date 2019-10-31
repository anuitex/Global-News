<template>
  <div>
    <!-- Subscribe -->
    <div class="subscribe-prompt-wrap">
      <div class="close-wrap">
        <a href="#"></a>
      </div>
      <div class="text-wrap">
        <span>Do you want to receive more news ?</span>
      </div>
      <div class="button-wrap">
        <button href="#">Subscribe Us</button>
      </div>
    </div>
    <!-- Notify -->
    <div class="notify-prompt-wrap">
      <div class="close-wrap">
        <a href="#"></a>
      </div>

      <div class="text-wrap">
        <p>You subscribe on</p>
        <p class="dropdown">
          <span>All News</span>
          <span class="wropdown-arrow">
            <font-awesome-icon icon="caret-down" />
          </span>
        </p>
      </div>
      <div class="send-email-wrap">
        <div class="email-wrap">
          <span>E-mail</span>
        </div>
        <div class="button-wrap">
          <button href="#">Subscribe</button>
        </div>
      </div>
    </div>

    <!-- Currency Converter -->
    <div class="currency-converter-wrap">
      <div class="close-wrap">
        <a href="#"></a>
      </div>
      <div class="from">
        <div class="dropdown-wrap" selected>
          <span>from</span>
          <select class="dropdown">
            <option>USD</option>
            <option>CHF</option>
            <option>MYR</option>
            <option>BGN</option>
          </select>
        </div>
        <div class="value-wrap">
          <span class="value">100</span>
        </div>
      </div>
      <div class="to">
        <div class="dropdown-wrap" selected>
          <span>to</span>
          <select class="dropdown">
            <option>EUR</option>
            <option>CHF</option>
            <option>MYR</option>
            <option>BGN</option>
          </select>
        </div>
        <div class="value-wrap">
          <span class="value">91.0249</span>
        </div>
      </div>

      <div class="rate-wrap">
        <div>
          <span>EUR/USD = 1.0986</span>
        </div>
        <div>
          <span>USD/JPY = 106.8905</span>
        </div>
        <div>
          <span>GBP/USD = 1.2234</span>
        </div>
      </div>
    </div>

    <!-- Weather -->
    <div class="weather-main-wrap">
      <div class="weather-search-wrap">
        <div class="close-wrap">
          <a href="#"></a>
        </div>

        <div class="text-wrap">
          <p>Do you mean London?</p>
        </div>
        <div class="seacrh-country-wrap">
          <div class="country-wrap">
            <span>Lond</span>
          </div>
          <div class="button-wrap">
            <button href="#">Search</button>
          </div>
        </div>

        <div class="clouds">
          <span>Broken Clouds</span>
          <span class="icon">
            <img src="../../../../assets/images/cloud.svg" alt="cloud" />
          </span>
        </div>

        <div class="temp-value-wrap">
          <span>+12</span>

          <span class="temp-symbol">
            <span>&#8451;</span>
            <span>F</span>
          </span>
        </div>
      </div>
      <div class="links-wrap">
        <a href="#">Weather Map</a>
        <a href="#">More</a>
      </div>
    </div>

    <!-- Weather Details -->
    <div class="weather-details-wrap">
      <div class="close-wrap">
        <a href="#"></a>
      </div>
      <div class="left-side">
        <div class="temp-info-wrap">
          <div class="temp-value-wrap info-elem">
            <p>
              <span class="cwitch">Show weather in :</span>
              <span class="temp-symbol">
                <span>F</span>
                <span>&#8451;</span>
              </span>
            </p>
            <p>Place : London</p>
          </div>
          <div class="show-info-wrap info-elem">
            <p>
              Min Temperature :
              <span class="temp-value">
                14
                <span class="temp-val-symbol"></span>
              </span>
            </p>
            <p>
              Max Temperature :
              <span class="temp-value">
                14
                <span class="temp-val-symbol"></span>
              </span>
            </p>
            <p>
              Temperature :
              <span class="temp-value">
                14
                <span class="temp-val-symbol"></span>
              </span>
            </p>
          </div>
          <div class="additional-info info-elem">
            <p class>
              Humidity :
              <span class="value">28</span>
            </p>
            <p class>
              Wind Speed :
              <span class="value">3</span>
            </p>
          </div>
        </div>
      </div>
      <div class="right-side">
        <div class="wrap">
          <span class="icon-wrap">
            <img src="../../../../assets/images/cloud.svg" alt="cloud" />
          </span>
          <span>Broken Clouds</span>
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped>
/* Weather Details */

.weather-details-wrap .right-side {
  position: absolute;
  right: 11%;
  top: 35%;
  font-size: 24px;
  font-weight: bold;
}
.weather-details-wrap .right-side .wrap span {
  margin: 20px 0;
}
.weather-details-wrap .right-side .wrap {
  display: flex;
  flex-direction: column;
}
.weather-details-wrap .right-side {
  color: #f9f9f9;
}
.weather-details-wrap .right-side .icon-wrap img {
  width: 130px;
}
.temp-info-wrap .additional-info {
  text-align: start;
}
.temp-info-wrap .info-elem {
  margin-top: 40px;
  font-weight: bold;
}
.weather-details-wrap .show-info-wrap {
  text-align: start;
}
.weather-details-wrap .show-info-wrap .temp-val-symbol {
  position: relative;
  margin-left: 5px;
}
.weather-details-wrap .show-info-wrap .temp-val-symbol::before {
  content: "";
  width: 7px;
  height: 7px;
  position: absolute;
  border: 1px solid #a09f9f;
  border-radius: 10px;
}
.weather-details-wrap .temp-symbol span {
  margin: 0 7px;
}
.weather-details-wrap .temp-symbol {
  position: relative;
}
.weather-details-wrap .temp-symbol::before {
  content: "";
  position: absolute;
  width: 1px;
  height: 20px;
  background-color: white;
  left: 27px;
  top: 2px;
}
.weather-details-wrap .temp-value-wrap {
  text-align: start;
}

.weather-details-wrap .temp-info-wrap p {
  margin-bottom: 3px;
}
.weather-details-wrap .temp-info-wrap {
  color: #f9f9f9;
  font-size: 24px;
  margin-top: 95px;
  margin-bottom: 44px;
}
.weather-details-wrap {
  display: flex;
  width: 618px;
  position: absolute;
  top: 660px;
  background-color: #052962;
  border: 1px solid;
  z-index: 999;
  padding: 0 50px;
}

.weather-details-wrap .close-wrap a {
  width: 18px;
  height: 18px;
  display: inline-block;
  position: absolute;
  top: 24px;
  right: 23px;
}
.weather-details-wrap .close-wrap a::before {
  position: absolute;
  content: "";
  width: 15px;
  height: 1px;
  background-color: white;
  top: 7px;
  right: 0px;
  transform: rotate(45deg);
}

.weather-details-wrap .close-wrap a::after {
  position: absolute;
  content: "";
  width: 15px;
  height: 1px;
  background-color: white;
  top: 7px;
  right: 0px;
  transform: rotate(-45deg);
}

/* Weather */
.weather-main-wrap .links-wrap {
  display: flex;
  justify-content: space-between;
  margin-top: 55px;
}
.weather-main-wrap .links-wrap a {
  color: #f8c61a;
  text-decoration: none;
}

.weather-search-wrap .temp-value-wrap .temp-symbol {
  position: absolute;
  top: -7px;
  font-size: 26px !important;
  left: 161px;
}

.weather-search-wrap .temp-value-wrap {
  color: white;
  font-size: 32px;
  font-weight: bold;
  position: relative;
  margin-top: 50px;
}

.weather-search-wrap .temp-value-wrap .temp-symbol span {
  margin: 0 5px;
}
.weather-search-wrap .temp-value-wrap .temp-symbol::before {
  content: "";
  position: absolute;
  width: 2px;
  height: 20px;
  background-color: white;
  left: 37px;
  top: 7px;
}

.weather-search-wrap .clouds {
  margin-top: 55px;
  color: #eaeaea;
  display: flex;
  justify-content: space-between;
  align-items: center;
}

.weather-search-wrap .clouds img {
  width: 90px;
}

.weather-main-wrap {
  position: absolute;
  width: 380px;
  right: 571px;
  top: 660px;
  background-color: #052962;
  padding-bottom: 20px;
  border: 1px solid;
  z-index: 999;
  padding: 0 20px 10px 20px;
}
.weather-search-wrap {
  padding: 0 40px;
}
.weather-search-wrap .close-wrap a {
  width: 18px;
  height: 18px;
  display: inline-block;
  position: absolute;
  top: 24px;
  right: 23px;
}
.weather-search-wrap .close-wrap a::before {
  position: absolute;
  content: "";
  width: 15px;
  height: 1px;
  background-color: white;
  top: 7px;
  right: 0px;
  transform: rotate(45deg);
}

.weather-search-wrap .close-wrap a::after {
  position: absolute;
  content: "";
  width: 15px;
  height: 1px;
  background-color: white;
  top: 7px;
  right: 0px;
  transform: rotate(-45deg);
}

.weather-search-wrap .text-wrap {
  margin-top: 80px;
  padding: 0;
}
.weather-search-wrap .text-wrap p {
  color: #eaeaea;
}

.weather-search-wrap .text-wrap p.dropdown {
  font-size: 32px;
  font-family: initial;
}

.weather-search-wrap .seacrh-country-wrap {
  display: inline-flex;
  flex-direction: column;
  margin-top: 10px;
}

.weather-search-wrap .button-wrap {
  margin-top: 23px;
}

.weather-search-wrap .country-wrap span {
  color: #eaeaea;
  display: block;
  width: 100%;
  border-bottom: 1px solid;
  text-align: start;
}

.weather-search-wrap .button-wrap button {
  width: 242px;
  height: 48px;
  background-color: #f8c61a;
  border: none;
  font-size: 16px;
  font-weight: bold;
  text-transform: uppercase;
  letter-spacing: 1px;
}
.weather-search-wrap .button-wrap button:hover {
  background-color: #ffe076;
}

.weather-search-wrap .seacrh-country-wrap {
  display: inline-flex;
  flex-direction: column;
  margin-top: 10px;
}

.weather-search-wrap .button-wrap {
  margin-top: 23px;
}

.weather-search-wrap .country-wrap span {
  color: #eaeaea;
  display: block;
  width: 100%;
  border-bottom: 1px solid;
  text-align: start;
}

.weather-search-wrap .button-wrap button {
  width: 242px;
  height: 48px;
  background-color: #f8c61a;
  border: none;
  font-size: 16px;
  font-weight: bold;
  text-transform: uppercase;
  letter-spacing: 1px;
}
.weather-search-wrap .button-wrap button:hover {
  background-color: #ffe076;
}

/* Currency Converter */
/* Notify */
.currency-converter-wrap .rate-wrap {
  padding: 0 60px;
  margin-top: 45px;
}
.currency-converter-wrap .rate-wrap span {
  color: #e2e1e1;
  padding: 14px;
  display: block;
  background: rgb(255, 255, 255);
  background: linear-gradient(
    0deg,
    rgba(255, 255, 255, 0.21612394957983194) 100%,
    rgba(255, 255, 255, 0.5186449579831933) 100%
  );
  margin-top: 10px;
}

.currency-converter-wrap .to .value-wrap {
  font-size: 19px;
  display: flex;
  align-items: center;
}

.currency-converter-wrap .to .value-wrap .value {
  width: 103px;
  display: block;
  border-bottom: 1px solid #b7b7b7 !important;
  text-align: center;
}

.currency-converter-wrap .to .dropdown-wrap {
  width: 100px;
  display: flex;
  flex-direction: column;
}
.currency-converter-wrap .to .dropdown-wrap .dropdown option {
  font-size: 16px;
  color: black;
}

.currency-converter-wrap .to .dropdown-wrap .dropdown {
  background: transparent;
  width: 80px;
  height: 40px;
  color: white;
  font-size: 26px;
  border: none;
  font-family: initial;
}

.currency-converter-wrap .to .dropdown-wrap .dropdown:focus {
  outline: none;
}

.currency-converter-wrap .to {
  margin-top: 70px;
  text-align: start;
  display: flex;
  justify-content: space-between;
}
.currency-converter-wrap .from .value-wrap {
  font-size: 19px;
  display: flex;
  align-items: center;
}

.currency-converter-wrap .from .value-wrap .value {
  width: 103px;
  display: block;
  border-bottom: 1px solid #b7b7b7 !important;
  text-align: center;
}

.currency-converter-wrap .from .dropdown-wrap {
  width: 100px;
  display: flex;
  flex-direction: column;
}
.currency-converter-wrap .from .dropdown-wrap .dropdown option {
  font-size: 16px;
  color: black;
}

.currency-converter-wrap .from .dropdown-wrap .dropdown {
  background: transparent;
  width: 80px;
  height: 40px;
  color: white;
  font-size: 26px;
  border: none;
  font-family: initial;
}

.currency-converter-wrap .from .dropdown-wrap .dropdown:focus {
  outline: none;
}

.currency-converter-wrap .from {
  margin-top: 70px;
  text-align: start;
  display: flex;
  justify-content: space-between;
}
.currency-converter-wrap .from,
.currency-converter-wrap .to {
  color: #eaeaea;
  font-size: 10px;
  padding: 0 60px;
}

.currency-converter-wrap {
  width: 380px;
  border: 1px solid;
  position: absolute;
  right: 570px;
  top: 102px;
  background-color: #052962;
  z-index: 999;
  padding-bottom: 45px;
}
.currency-converter-wrap .close-wrap a {
  width: 18px;
  height: 18px;
  display: inline-block;
  position: absolute;
  top: 24px;
  right: 23px;
}
.currency-converter-wrap .close-wrap a::before {
  position: absolute;
  content: "";
  width: 15px;
  height: 1px;
  background-color: white;
  top: 7px;
  right: 0px;
  transform: rotate(45deg);
}

.currency-converter-wrap .close-wrap a::after {
  position: absolute;
  content: "";
  width: 15px;
  height: 1px;
  background-color: white;
  top: 7px;
  right: 0px;
  transform: rotate(-45deg);
}

/* Notify Subscribe*/

.notify-prompt-wrap .text-wrap p {
  color: #eaeaea;
}

.notify-prompt-wrap .text-wrap p.dropdown {
  font-size: 32px;
  font-family: initial;
  margin-right: 10px;
}

.notify-prompt-wrap .send-email-wrap {
  display: inline-flex;
  flex-direction: column;
  margin-top: 10px;
}

.notify-prompt-wrap .button-wrap {
  margin-top: 23px;
}

.notify-prompt-wrap .email-wrap span {
  color: #eaeaea;
  display: block;
  width: 100%;
  border-bottom: 1px solid;
  text-align: start;
}

.notify-prompt-wrap .button-wrap button {
  width: 242px;
  height: 48px;
  background-color: #f8c61a;
  border: none;
  font-size: 16px;
  font-weight: bold;
  text-transform: uppercase;
  letter-spacing: 1px;
}
.notify-prompt-wrap .button-wrap button:hover {
  background-color: #ffe076;
}

.notify-prompt-wrap {
  width: 355px;
  padding-bottom: 56px;
  border: 1px solid;
  position: absolute;
  right: 0;
  top: 402px;
  background-color: #052962;
  z-index: 999;
}
.notify-prompt-wrap .close-wrap a {
  width: 18px;
  height: 18px;
  display: inline-block;
  position: absolute;
  top: 24px;
  right: 23px;
}
.notify-prompt-wrap .close-wrap a::before {
  position: absolute;
  content: "";
  width: 15px;
  height: 1px;
  background-color: white;
  top: 7px;
  right: 0px;
  transform: rotate(45deg);
}

.notify-prompt-wrap .close-wrap a::after {
  position: absolute;
  content: "";
  width: 15px;
  height: 1px;
  background-color: white;
  top: 7px;
  right: 0px;
  transform: rotate(-45deg);
}

.notify-prompt-wrap .text-wrap {
  margin-top: 86px;
  padding: 0px 90px;
  color: #f8c61a;
}

.notify-prompt-wrap .wropdown-arrow {
  margin-left: 10px;
  font-size: 20px;
  font-size: 14px;
}
.notify-prompt-wrap .text-wrap p {
  color: #eaeaea;
}

.notify-prompt-wrap .text-wrap p.dropdown {
  font-size: 32px;
  font-family: initial;
}

.notify-prompt-wrap .send-email-wrap {
  display: inline-flex;
  flex-direction: column;
  margin-top: 10px;
}

.notify-prompt-wrap .button-wrap {
  margin-top: 23px;
}

.notify-prompt-wrap .email-wrap span {
  color: #eaeaea;
  display: block;
  width: 100%;
  border-bottom: 1px solid;
  text-align: start;
}

.notify-prompt-wrap .button-wrap button {
  width: 242px;
  height: 48px;
  background-color: #f8c61a;
  border: none;
  font-size: 16px;
  font-weight: bold;
  text-transform: uppercase;
  letter-spacing: 1px;
}
.notify-prompt-wrap .button-wrap button:hover {
  background-color: #ffe076;
}

/* Subscribe Auto Show*/
.subscribe-prompt-wrap .close-wrap a {
  width: 18px;
  height: 18px;
  display: inline-block;
  position: absolute;
  top: 24px;
  right: 23px;
}
.subscribe-prompt-wrap .close-wrap a::before {
  position: absolute;
  content: "";
  width: 15px;
  height: 1px;
  background-color: white;
  top: 7px;
  right: 0px;
  transform: rotate(45deg);
}

.subscribe-prompt-wrap .close-wrap a::after {
  position: absolute;
  content: "";
  width: 15px;
  height: 1px;
  background-color: white;
  top: 7px;
  right: 0px;
  transform: rotate(-45deg);
}

.subscribe-prompt-wrap .text-wrap {
  margin-top: 90px;
  padding: 0px 115px;
}
.subscribe-prompt-wrap .text-wrap span {
  color: #eaeaea;
}

.subscribe-prompt-wrap .button-wrap {
  margin-top: 37px;
}

.subscribe-prompt-wrap .button-wrap button {
  width: 242px;
  height: 48px;
  background-color: #f8c61a;
  border: none;
  font-size: 16px;
  font-weight: bold;
  text-transform: uppercase;
  letter-spacing: 1px;
}
.subscribe-prompt-wrap .button-wrap button:hover {
  background-color: #ffe076;
}
.subscribe-prompt-wrap {
  width: 381px;
  padding-bottom: 40px;
  border: 1px solid;
  position: absolute;
  right: 0;
  top: 102px;
  background-color: #052962;
  z-index: 999;
}
</style>
