const QuerySummary = Vue.component('query-summary', {
    data: function () {
        return {
        };
    },
    props: ['query'],
    created: function () {
    },
    methods: {
        remove: function (item, collection) {
            var index = collection.indexOf(item);
            collection.splice(index, 1);
        },
        removeAccount: function (account) {
            var index = this.query.accounts.indexOf(account)
            this.query.accounts.splice(index, 1);
        }
    },
    template: `
<div>
    <h4>summary</h4>
    <table class="table table-hover table-bordered">
        <thead>
            <tr>
                <th colspan="2">accounts</th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="a in query.accounts">
                <td>{{a.name}}</td>
                <td>
                    <button class='btn btn-danger' v-on:click="removeAccount(a)">
                        <span class="glyphicon glyphicon-remove" />
                    </button>
                </td>
            </tr>
        </tbody>
        <thead>
            <tr>
                <th colspan="2">include expressions</th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="ie in query.includeExpressions">
                <td>{{ie.name}}</td>
                <td>
                    <button class='btn btn-danger' v-on:click="remove(ie, query.includeExpressions)">
                        <span class="glyphicon glyphicon-remove" />
                    </button>
                </td>
            </tr>
        </tbody>
        <thead>
            <tr>
                <th colspan="2">exclude expressions</th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="ee in query.excludeExpressions">
                <td>{{ee.name}}</td>
                <td>
                    <button class='btn btn-danger' v-on:click="remove(ee, query.excludeExpressions)">
                        <span class="glyphicon glyphicon-remove" />
                    </button>
                </td>
            </tr>
        </tbody>
    </table>
</div>`
});