const QueryWizard = Vue.component('query-wizard', {
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
        next: function () {
            this.step = this.step + 1;
        },
        back: function () {
            this.step = this.step - 1;
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
            console.log(queryData);
            var data = {
                id: queryData.queryId,
                name: queryData.name,
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
        },
        create: function () {
            this.$http.post('queries', { name: 'new-query' })
                .then(res => {
                    this.query = this.createQueryObject(res.body);
                    this.next();
                });
        }
    },
    template: `
  <div class="container-fluid">
    <h3>report creation wizard</h3>
    <div class="row">
        <div class="col-md-6">
            <query-list v-on:query-selected="querySelected" v-if="step == 1"/>
            <query-accounts v-if="step == 2" v-bind:query="query" v-bind:accounts="accounts" />
            <query-expressions v-if="step == 3" v-bind:query="query" v-bind:expressions="expressions" />
            <query-preview v-if="step == 4" v-bind:query="query" />
            <query-save v-if="step == 5" v-bind:query="query" />
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
    <div class="row">
        <div class="col-sm-3">
            <button class="btn btn-primary" v-if="step == 1" v-on:click="create">create new</button>
        </div>
        <div class="col-sm-6"></div>
        <div class="col-sm-3">
            <button class="btn btn-primary" v-if="step == 1 && query" v-on:click="next"">continue</button>
        </div>
    </div>
  </div>`
});