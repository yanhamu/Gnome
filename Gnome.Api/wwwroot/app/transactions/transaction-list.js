const TransactionList = Vue.component('transaction-list', {
    props: ['transactions'],
    methods: {
        selectTransaction: function (data) {
            this.$emit('select-transaction', data);
        }
    },
    template: `
    <div class="container-fluid">
        <h4>transaction list</h4>
        <table class="table table-striped table-hover">
            <tbody>
                <tr v-for="t in transactions.rows" v-on:click="selectTransaction(t)">
                    <td>{{t.date}}</td>
                    <td>{{t.amount}}</td>
                </tr>
            </tbody>
        </table>
    </div>`
});