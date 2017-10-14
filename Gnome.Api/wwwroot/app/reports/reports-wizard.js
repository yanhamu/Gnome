const ReportWizard = Vue.component('report-wizard', {
    data: function () {
        return {
            reports: [],
            step: 1,
            queries: []
        };
    },
    created: function () {
        this.$http
            .get('reports')
            .then(res => this.reports = res.body);
        this.$http
            .get('queries')
            .then(res => this.queries = res.body);
    },
    methods: {
        create: function () {
            this.report = { name: 'new report name' };
            this.step += 1;
        },
        selectReport: function (r) {
            this.report = r;
        }
    },
    template: `
  <div class="container-fluid">
    <h3>reports</h3>
    <div class="row">
        <div class="col-md-12">
            <report-list v-if="step == 1" v-bind:reports="reports" v-on:select-report="selectReport" />
            <report-details v-if="step == 2" v-bind:queries="queries" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-6">
            <button class="btn btn-primary" v-on:click="create">create new</button>
        </div>
    </div>
  </div>`
});