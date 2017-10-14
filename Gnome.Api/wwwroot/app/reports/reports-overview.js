const ReportsOverview = Vue.component('report-overview', {
    data: function () {
        return {
            reports: [],
            report: null
        };
    },
    created: function () {
        this.$http
            .get('reports')
            .then(res => this.reports = res.body);
    },
    methods: {
        selectReport: function () {

        }
    },
    template: `
  <div class="container-fluid">
    <h3>reports</h3>
    <div class="row">
        <div class="col-md-12">
            <report-list 
                v-bind:reports="reports" 
                v-on:select-report="selectReport" v-bind:allowRemove="false" />
        </div>
    </div>
  </div>`
});