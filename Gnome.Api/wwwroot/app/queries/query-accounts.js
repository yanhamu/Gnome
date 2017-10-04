const QueryAccounts = Vue.component('query-accounts', {
    data: function () {
        return {
        };
    },
    props: ['query', 'accounts'],
    created: function () {
    },
    methods: {
        select: function (a) {
            if (!this.exists(a.id)) {
                this.query.accounts.push(a);
            }
        },
        selectAll: function () {
            var self = this;
            self.accounts.forEach(a => self.select(a));
        },
        exists: function (accountId) {
            for (var index in this.query.accounts) {
                if (this.query.accounts[index].id == accountId) {
                    return true;
                }
            }
            return false;
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