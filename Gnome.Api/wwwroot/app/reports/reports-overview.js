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
        viewReport: function (r) {
            var data = {
                reportId: r.id,
                dateFilter: {
                    from: '2017-01-01',
                    to: '2017-12-12'
                }
            };

            this.$http
                .get('reports/' + r.id+'?from=2017-01-01&to=2017-12-12')
                .then(res => console.log(res));
        }
    },
    template: `
  <div class="container-fluid">
    <h3>reports</h3>
    <div class="row">
        <div class="col-md-12">
            <report-list 
                v-bind:reports="reports" 
                v-on:select-report="viewReport" 
                v-bind:allowRemove="false"
                v-bind:allowEdit="false"
                v-bind:allowReport="true"/>
        </div>
    </div>
  </div>`
});