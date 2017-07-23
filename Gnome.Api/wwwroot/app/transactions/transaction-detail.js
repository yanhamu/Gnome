const TransactionDetail = Vue.component('transaction-detail', {
    props: ['transaction'],
    template: `
    <div class="container-fluid">
        <h4>transaction detail</h4>
        <table class="table table-striped">
            <tbody>
                <tr>
                    <td>Date</td>
                    <td>{{transaction.date}}</td>
                </tr>
                <tr>
                    <td>Amount</td>
                    <td>{{transaction.amount}}</td>
                </tr>
                <tr>
                    <td>Type</td>
                    <td>{{transaction.type}}</td>
                </tr>
                <tr v-for="(item, index) in transaction.fields">
                    <td>{{index}}</td>
                    <td>{{item}}</td>
                </tr>
            </tbody>
        </table>
    </div>`
});