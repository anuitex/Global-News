<script>
import axios from 'axios';

export default {
    name: 'lifeSearchService',
    getDataForLifeSearch(text) {
        let urlString = window.location.protocol + '//' + window.location.host + '/searchCity?name=' + text;

        return axios.get(urlString);
    },
}
</script>