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
        removeAccount: function (accountId) {
            this.$emit("remove-account", accountId);
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
            <tr v-for="ie in query.includedExpressions">
                <td>{{ie.name}}</td>
                <td>
                    <button class='btn btn-danger' v-on:click="remove(ie, query.includedExpressions)">
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
            <tr v-for="ee in query.excludedExpressions">
                <td>{{ee.name}}</td>
                <td>
                    <button class='btn btn-danger' v-on:click="remove(ee, query.excludedExpressions)">
                        <span class="glyphicon glyphicon-remove" />
                    </button>
                </td>
            </tr>
        </tbody>
    </table>
</div>`
});