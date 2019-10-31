<script>
import axios from 'axios';
import {environment} from './../../environment/environment'

export default {
    name: 'mapsService',
    getData() {
        return axios.get(`${environment.mapboxUrl}${environment.mapboxKey}`)
    }
}
</script>