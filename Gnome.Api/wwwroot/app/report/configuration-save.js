const ConfigurationQuerySave = Vue.component('configuration-save', {
    data: function () {
        return {
            name: ""
        };
    },
    props: ['excludedExpressions', 'includedExpressions', 'accounts'],
    created: function () {
    },
    methods: {
        save: function () {
            var data = {
                name: this.name,
                accounts: [],
                includeExpressions: [],
                excludeExpressions: []
            };
            this.excludedExpressions.forEach(e => data.excludeExpressions.push(e.id));
            this.includedExpressions.forEach(e => data.includeExpressions.push(e.id));
            this.accounts.forEach(a => data.accounts.push(a.id));
            this.$http.post('queries/', data)
                .then();
        }
    },
    template: `
  <div class="container-fluid">
    <h3>summary</h3>
    <div class="form-group row">
        <label for="name" class="col-sm-2 col-form-label">Name</label>
        <div class="col-sm-10">
            <input type="text" v-model="name" class="form-control" />
        </div>
    </div>
    <div class="form-group row">
        <label for="token" class="col-sm-2 col-form-label">Token</label>
        <div class="col-sm-10">
            <input value="save" class="btn btn-primary btn-block" v-on:click="save" />
        </div>
    </div>
  </div>`
});