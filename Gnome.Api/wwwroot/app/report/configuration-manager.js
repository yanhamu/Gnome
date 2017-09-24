const ConfigurationManager = Vue.component('configuration-manager', {
    data: function () {
        return {
            selectedExpression:null
        };
    },
    created: function () {
    },
    methods: {
        expressionSelected: function (e) {
            this.selectedExpression = e;
        }
    },
    template: `
  <div class="container-fluid">
    <h3>configuration</h3>
    <div class="row">
        <div class="col-md-3">
            <expression-list v-on:select-expression="expressionSelected"></expression-list>
        </div>
        <div class="col-md-9">
            <expression-detail v-if="selectedExpression" v-bind:expression="selectedExpression"></expression-detail>
        </div>
    </div>
  </div>`
});