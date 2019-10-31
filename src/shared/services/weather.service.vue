<script>
import axios from 'axios';
import {environment} from './../../environment/environment'

export default {
    name: 'weatherService',
    getWeather(lat, lon, country) {
        return axios.get(`${environment.weatherApiUrl}lat=${lat}&lon=${lon}${environment.weatherApiKey}&units=metric`);
    },

    getWeatherByCountry(country) {
        return axios.get(`${environment.weatherApiUrl}q=${country}&${environment.weatherApiKey}&units=metric`);
    }
}
</script>