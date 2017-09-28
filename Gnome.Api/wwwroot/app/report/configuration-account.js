const ConfigurationAccount = Vue.component('configuration-account', {
    data: function () {
        return {
            accounts: []
        };
    },
    created: function () {
        this.$http.get('accounts')
            .then(res => {
                this.accounts = res.body;
            });
    },
    methods: {
        select: function (a) {
            this.$emit('account-selected', a);
        },
        selectAll: function () {
            var self = this;
            self.accounts.forEach(a => self.$emit('account-selected', a));
        }
    },
    template: `
  <div class="container-fluid">
    <h3>account</h3>
        <table class="table table-hover table-bordered">
            <tbody>
                <tr v-on:click="selectAll">
                    <td>all</td>
                </tr>
                <tr v-for="a in accounts" v-on:click="select(a)">
                    <td>
                        {{a.name}}
                    </td>
                </tr>
            </tbody>
        </table>
  </div>`
});