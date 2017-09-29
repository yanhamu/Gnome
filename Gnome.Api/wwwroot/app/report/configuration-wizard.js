const ConfigurationWizard = Vue.component('configuration-wizard', {
    data: function () {
        return {
            step: 1,
            accounts: [],
            inlcudedExpressions: [],
            excludedExpressions: []
        };
    },
    created: function () {
    },
    methods: {
        addAccount: function (a) {
            if(this.accounts.indexOf(a) < 0)
                this.accounts.push(a);
        },
        removeAccount: function (a) {
            var indexOf = this.accounts.indexOf(a);
            this.accounts.splice(indexOf, 1);
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
            if (this.inlcudedExpressions.indexOf(e) < 0)
                this.inlcudedExpressions.push(e);
        }
    },
    template: `
  <div class="container-fluid">
    <h3>report creation wizard</h3>
    <div class="row">
        <div class="col-md-6">
            <configuration-account v-if="step == 1" v-on:account-selected="addAccount" />
            <configuration-expression v-if="step == 2" v-on:includeExpression="includeExpression" v-on:excludeExpression="excludeExpression" />
        </div>
        <div class="col-md-6">
            <h4>summary</h4>
            <table class="table table-hover table-bordered">
                <thead>
                    <tr>
                        <td>accounts</td>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="a in accounts">
                        <td>{{a.name}}</td>
                        <td>
                            <button class='btn btn-danger' v-on:click="removeAccount(a)">
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
            <button class="btn btn-primary" v-on:click="next">next</button>
        </div>
    </div>
  </div>`
});