const TransactionManager = Vue.component('transaction-manager', {
    props: ['id'],
    data: function () {
        return {
            transactions: null,
            selectedTransaction: null
        };
    },
    methods: {
        filterSet: function (data) {
            var url = 'transactions/query';
            this.$http.post(url, data).then(res => {
                this.transactions = res.body;
            });
        },
        selectTransaction: function (data) {
            this.selectedTransaction = data;
        }
    },
    template: `
  <div class="container-fluid">
    <h3>transactions</h3>
    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-default">
                <div class="panel-body">
                    <transaction-filter v-on:filter-set="filterSet"></transaction-filter>
                </div>
            </div>
        </div>
    </div>
        <div class="row">
            <div class="col-md-6">
                <div class="panel panel-default" v-if="transactions">
                    <div class="panel-body">
                        <transaction-list v-bind:transactions="transactions" v-on:select-transaction="selectTransaction"></transaction-list>
                    </div>
                </div>
            </div>

            <div class="col-md-6">
                <div class="panel panel-default" v-if="selectedTransaction">
                    <div class="panel-body">
                        <transaction-detail v-bind:transaction="selectedTransaction"></transaction-detail>
                    </div>
                </div>
            </div>
        </div>
    </div>`
});