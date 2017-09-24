const ExpressionDetail = Vue.component('expression-detail', {
    props: ['expression'],
    methods: {
        save: function () {
            this.$http.put('expressions/' + this.expression.id, this.expression)
                .then(res => {
                });
        }
    },
    template: `
    <div class="container-fluid">
        <h3>expression detail</h3>
        <div class="form-group row">
            <label for="name" class="col-sm-2 col-form-label">Name</label>
            <div class="col-sm-10">
                <input type="text" v-model="expression.name" class="form-control" />
            </div>
        </div>
        <div class="form-group row">
            <label for="name" class="col-sm-2 col-form-label">Expression</label>
            <div class="col-sm-10">
                <input type="text" v-model="expression.expressionString" class="form-control" />
            </div>
        </div>
        <div class="row">
            <div class="col-sm-offset-10 col-sm-2">
                <input value="save" class="btn btn-primary btn-block" v-on:click="save" />
            </div>
        </div>
    </div>`
});