const QueryPreview = Vue.component('query-preview', {
    data: function () {
        return {
            transactions: [],
            selectedTransaction: null
        };
    },
    props: ['query'],
    created: function () {

        var from = moment().subtract(1, 'years').format('YYYY-MM-DD');
        var to = moment().format('YYYY-MM-DD');

        var data = {
            accounts: [],
            includeExpressions: [],
            excludeExpressions: [],
            dateFilter: {
                from: from,
                to: to
            }
        };

        this.query.accounts.forEach(a => { data.accounts.push(a.id) });
        this.query.includeExpressions.forEach(a => { data.includeExpressions.push(a.id) });
        this.query.excludeExpressions.forEach(a => { data.excludeExpressions.push(a.id) });
        var url = 'transactions/query';
        this.$http.post(url, data)
            .then(res => {
                this.transactions = res.body
            });
    },
    methods: {
        selectTransaction: function (data) {
            this.selectedTransaction = data;
        }
    },
    template: `
  <div class="container-fluid">
    <h3>preview</h3>
    <div class="row">
        <div class="col-sm-12">
            <transaction-list v-bind:transactions="transactions" v-on:select-transaction="selectTransaction"></transaction-list>
        </div>
    </div>
    <div class="row" v-if="selectedTransaction">
        <div class="col-sm-12">
            <transaction-detail v-bind:transaction="selectedTransaction"></transaction-detail>
        </div>
    </div>
  </div>`
});