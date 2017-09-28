const ConfigurationWizard = Vue.component('configuration-wizard', {
    data: function () {
        return {
            step: 1,
            accounts: []
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
        }
    },
    template: `
  <div class="container-fluid">
    <h3>report creation wizard</h3>
    {{step}}
    <div class="row">
        <div class="col-md-12">
            <configuration-account v-if="step == 1" v-on:account-selected="addAccount" />
            <configuration-expression v-if="step == 2" />
        </div>
    </div>
    <div class="row">
        <div class="col-sm-9"></div>
        <div class="col-sm-3">
            <button class="btn btn-primary" v-on:click="back">back</button>
            <button class="btn btn-primary" v-on:click="next">next</button>
        </div>
    </div>
    <div class="row">
        <h4>summary</h4>
        <div class="col-md-6">
            <table class="table table-hover table-bordered">
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
  </div>`
});