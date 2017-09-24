const Accounts = Vue.component('accounts', {
    created: function () {
        this.$http.get('accounts')
            .then(res => {
                this.accounts = res.body;
            });
    },
    methods: {
        create: function () {
            var data = { name: 'new account', token: '' };
            this.$http.post('accounts', data)
                .then(res => {
                    var location = '/accounts/' + res.body.id;
                    router.push(location);
                });
        }
    },
    data: function () {
        return { accounts: [] };
    },
    template: `
<div class = "container-fluid">
    <h3>accounts</h3>

    <table class="table table-striped">
            <tr v-for="account in accounts">
                <td>
                    <router-link :to = "'/accounts/' + account.id + '/transactions/'">{{ account.name }}</router-link>
                </td>
                <td>
                    <router-link :to = "'/accounts/' + account.id">edit</router-link>
                </td>
            </tr>
    </table>
    <input class='btn btn-primary' value='create new' v-on:click="create"/>
</div>`
});