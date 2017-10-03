const ConfigurationExpression = Vue.component('configuration-expression', {
    data: function () {
        return {
            selected: null
        };
    },
    props: ['query', 'expressions'],
    methods: {
        expressionSelected: function (e) {
            this.selected = e;
        },
        includeExpression: function (e) {
            if (this.query.includeExpressions.indexOf(e) < 0) {
                this.query.includeExpressions.push(e);
            }
        },
        excludeExpression: function (e) {
            if (this.query.excludeExpressions.indexOf(e) < 0) {
                this.query.excludeExpressions.push(e);
            }
        }
    },
    template: `
  <div class="container-fluid">
    <h3>expressions</h3>
    <expression-list v-on:select-expression="expressionSelected" v-bind:expressions="expressions"></expression-list>
    <div class="row">
        <div class="col-sm-12">
            <expression-detail v-bind:expression="selected" v-if="selected"/>
        </div>
    </div>
    <div class="row" v-if="selected">
        <div class="col-sm-12">
            <button class="btn btn-primary" v-on:click="includeExpression(selected)">include</button>
            <button class="btn btn-primary" v-on:click="excludeExpression(selected)">exclude</button>
        </div>
    </div>
  </div>`
});