const ConfigurationQuerySave = Vue.component('configuration-save', {
    data: function () {
        return {
        };
    },
    props: ['query'],
    created: function () {
        console.log(this.query);
    },
    methods: {
        save: function () {
            var data = {
                id: this.query.id,
                name: this.query.name,
                accounts: [],
                includeExpressions: [],
                excludeExpressions: []
            };
            this.query.excludeExpressions.forEach(e => data.excludeExpressions.push(e.id));
            this.query.includeExpressions.forEach(e => data.includeExpressions.push(e.id));
            this.query.accounts.forEach(a => data.accounts.push(a.id));
            this.$http.put('queries/' + this.query.id, data)
                .then();
        }
    },
    template: `
  <div class="container-fluid">
    <h3>summary</h3>
    <div class="form-group row">
        <label for="name" class="col-sm-2 col-form-label">Name</label>
        <div class="col-sm-10">
            <input type="text" v-model="query.name" class="form-control" />
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