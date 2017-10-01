const ExpressionBuilderWizard = Vue.component('expression-builder-wizard', {
    data: function () {
        return {
            account: [],
            expression: null
        };
    },
    created: function () {
    },
    methods: {
        expressionSelected: function (expression) {
            this.expression = expression;
        }
    },
    template: `
  <div class="container-fluid">
    <h3>expression builder</h3>
    <div class="row">
        <div class="col-sm-6">
            <expression-list v-on:select-expression="expressionSelected"></expression-list>
        </div>
        <div class="col-sm-6">
            <expression-detail v-if="expression" v-bind:expression="expression"></expression-detail>
        </div>
    </div>
  </div>`
});