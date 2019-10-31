<script>
import axios from 'axios';
import {environment} from './../../environment/environment'

export default {
    name: 'ratesService',
    getRates(base) {
        return axios.get(`${environment.ratesApiUrl}base=${base}`)
    },
}
</script>