const ConfigurationWizard = Vue.component('configuration-wizard', {
    data: function () {
        return {
            step: 1,
            query: null,
            accounts: [],
            expressions: []
        };
    },
    created: function () {
        this.$http.get('accounts').then(res => this.accounts = res.body);
        this.$http.get('expressions').then(res => this.expressions = res.body);
    },
    methods: {
        addAccount: function (a) {
            if (this.query.accounts.indexOf(a) < 0) {
                this.query.accounts.push(a);
                this.updateQuery();
            }
        },
        remove: function (item, collection) {
            var index = collection.indexOf(item);
            collection.splice(index, 1);
        },
        next: function () {
            this.step = this.step + 1;
        },
        back: function () {
            this.step = this.step - 1;
        },
        excludeExpression: function (e) {
            if (this.query.excludedExpressions.indexOf(e) < 0)
                this.query.excludedExpressions.push(e);
        },
        includeExpression: function (e) {
            if (this.query.includedExpressions.indexOf(e) < 0)
                this.query.includedExpressions.push(e);
        },
        querySelected: function (q) {
            this.query = this.createQueryObject(q);
        },
        updateQuery: function () {
            var data = {};
            this.$http.put('queries/' + this.query.id, data)
                .then();
        },
        createQueryObject: function (queryData) {
            var data = {
                id: queryData.queryId,
                includeExpressions: [],
                excludeExpressions: [],
                accounts: []
            };

            queryData.accounts.forEach(a => data.accounts.push(this.matchById(a, this.accounts)));
            queryData.includeExpressions.forEach(e => data.includeExpressions.push(this.matchById(e, this.expressions)));
            queryData.excludeExpressions.forEach(e => data.excludeExpressions.push(this.matchById(e, this.expressions)));

            return data;
        },
        matchById: function (id, collection) {
            for (var index in collection) {
                var item = collection[index];
                if (item.id == id) {
                    return item;
                }
            }
        }
    },
    template: `
  <div class="container-fluid">
    <h3>report creation wizard</h3>
    <div class="row">
        <div class="col-md-6">
            <configuration-query-list v-on:query-selected="querySelected" v-if="step == 1"/>
            <configuration-account v-if="step == 2" v-on:account-selected="addAccount" />
            <configuration-expression v-if="step == 3" v-on:includeExpression="includeExpression" v-on:excludeExpression="excludeExpression" />
            <configuration-preview v-if="step == 4" v-bind:query="query" />
            <configuration-save v-if="step == 5" v-bind:query="query" />
        </div>
        <div class="col-md-6" v-if="query">
            <query-summary v-bind:query="query"></query-summary>
        </div>
    </div>
    <div class="row" v-if="step != 1">
        <div class="col-sm-9"></div>
        <div class="col-sm-3">
            <button class="btn btn-primary" v-on:click="back" :disabled="step == 1">back</button>
            <button class="btn btn-primary" v-on:click="next" :disabled="step == 5">next</button>
        </div>
    </div>
    <div class="row" v-if="step == 1">
        <div class="col-sm-3">
            <button class="btn btn-primary" v-on:click="next">create new</button>
        </div>
        <div class="col-sm-9">
        </div>
    </div>
  </div>`
});