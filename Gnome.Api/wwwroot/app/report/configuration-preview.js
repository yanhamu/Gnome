const ConfigurationPreview = Vue.component('configuration-preview', {
    data: function () {
        return {
            transactions: []
        };
    },
    props: ['excludedExpressions', 'includedExpressions', 'accounts'],
    created: function () {
        var data = {

        };
        //this.$http.
    },
    methods: {
    },
    template: `
  <div class="container-fluid">
    <h3>preview</h3>
    <div class="row">
        <div class="col-sm-12">
        </div>
    </div>
  </div>`
});