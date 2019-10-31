<script>
    import axios from 'axios';

    export default {
        name: 'subscriptionService',

        addSubscroption(email, category) {
            let subscribeAll = false;

            if (category == null || category == undefined || category == ''|| category == 'all') {
                subscribeAll = true;
                category = 'Business';
            }

            let urlString = window.location.protocol + '//' + window.location.host + '/addSubscription';
            let data = { Email: email, Category: category, SubscribeAll: subscribeAll };

            return axios.post(urlString, data)
                .then(response => {
                    console.log(response);
                })
                .catch(response => {
                    console.log(response);
                });
        }
    }
</script>