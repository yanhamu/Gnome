const TransactionDetail = Vue.component('transaction-detail', {
    props: ['transaction'],
    template: `
    <div class="container-fluid">
        <h4>transaction detail</h4>
        <table class="table table-striped">
            <tbody>
                <tr>
                    <td>Date</td>
                    <td>{{transaction.row.date | formatDate}}</td>
                </tr>
                <tr>
                    <td>Amount</td>
                    <td>{{transaction.row.amount}}</td>
                </tr>
                <tr>
                    <td>Type</td>
                    <td>{{transaction.row.type}}</td>
                </tr>
                <tr v-for="(item, index) in transaction.row.fields" v-if="item != ''">
                    <td>{{index}}</td>
                    <td>{{item}}</td>
                </tr>
            </tbody>
        </table>
    </div>`
});