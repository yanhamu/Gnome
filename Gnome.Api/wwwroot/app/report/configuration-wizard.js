const ConfigurationWizard = Vue.component('configuration-wizard', {
    data: function () {
        return {
            step: 1,
            accounts: [],
            includedExpressions: [],
            excludedExpressions: []
        };
    },
    methods: {
        addAccount: function (a) {
            if (this.accounts.indexOf(a) < 0)
                this.accounts.push(a);
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
            if (this.excludedExpressions.indexOf(e) < 0)
                this.excludedExpressions.push(e);
        },
        includeExpression: function (e) {
            if (this.includedExpressions.indexOf(e) < 0)
                this.includedExpressions.push(e);
        }
    },
    template: `
  <div class="container-fluid">
    <h3>report creation wizard</h3>
    <div class="row">
        <div class="col-md-6">
            <configuration-query-list v-if="step == 1"/>
            <configuration-account v-if="step == 2" v-on:account-selected="addAccount" />
            <configuration-expression v-if="step == 3" v-on:includeExpression="includeExpression" v-on:excludeExpression="excludeExpression" />
            <configuration-preview v-if="step == 4"
                v-bind:excludedExpressions="excludedExpressions"
                v-bind:includedExpressions="includedExpressions"
                v-bind:accounts="accounts" />
            <configuration-save v-if="step == 5"
                v-bind:excludedExpressions="excludedExpressions"
                v-bind:includedExpressions="includedExpressions"
                v-bind:accounts="accounts" />
        </div>
        <div class="col-md-6">
            <h4>summary</h4>
            <table class="table table-hover table-bordered">
                <thead>
                    <tr>
                        <th colspan="2">accounts</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="a in accounts">
                        <td>{{a.name}}</td>
                        <td>
                            <button class='btn btn-danger' v-on:click="remove(a, accounts)">
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
                    <tr v-for="ie in includedExpressions">
                        <td>{{ie.name}}</td>
                        <td>
                            <button class='btn btn-danger' v-on:click="remove(ie, includedExpressions)">
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
                    <tr v-for="ee in excludedExpressions">
                        <td>{{ee.name}}</td>
                        <td>
                            <button class='btn btn-danger' v-on:click="remove(ee, excludedExpressions)">
                                <span class="glyphicon glyphicon-remove" />
                            </button>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-9"></div>
        <div class="col-sm-3">
            <button class="btn btn-primary" v-on:click="back" :disabled="step == 1">back</button>
            <button class="btn btn-primary" v-on:click="next" :disabled="step == 5">next</button>
        </div>
    </div>
  </div>`
});