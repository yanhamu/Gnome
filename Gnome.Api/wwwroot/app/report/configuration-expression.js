const ConfigurationExpression = Vue.component('configuration-expression', {
    data: function () {
        return {
            selected: null
        };
    },
    created: function () {
    },
    methods: {
        expressionSelected: function (e) {
            this.selected = e;
        },
        includeExpression: function (e) {
            this.$emit('includeExpression', e);
        },
        excludeExpression: function (e) {
            this.$emit('excludeExpression', e);
        }
    },
    template: `
  <div class="container-fluid">
    <h3>expressions</h3>
    <expression-list v-on:select-expression="expressionSelected"></expression-list>
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