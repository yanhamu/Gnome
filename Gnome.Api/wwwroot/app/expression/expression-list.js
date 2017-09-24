const ExpressionList = Vue.component('expression-list', {
    data: function () {
        return {
            expressions: []
        };
    },
    created: function () {
        this.$http.get('expressions')
            .then(res => {
                this.expressions = res.body;
            });
    },
    methods: {
        create: function () {
            var data = {
                name: 'new-expression',
                expression: '1=1'
            };
            this.$http.post('expressions', data)
                .then(res => {
                    this.expressions.push(res.body);
                });
        },
        remove: function (e) {
            this.$http.delete('expressions/' + e.id)
                .then(res => {
                    this.expressions.splice(this.expressions.indexOf(e), 1);
                });
        },
        selectExpression: function (e) {
            this.$emit('select-expression', e);
        }
    },
    template: `
  <div class="container-fluid">
    <h3>expressions</h3>
    <div class="row">
        <div class="col-md-12">
            <input class='btn btn-primary' value='create new' v-on:click="create"/>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <table class="table table-hover">
                <thead>
                    <tr>
                        <td>Name</td>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="e in expressions" v-on:click="selectExpression(e)">
                        <td>{{ e.name }}</td>
                        <td>
                            <button class='btn btn-danger' v-on:click="remove(e)">
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