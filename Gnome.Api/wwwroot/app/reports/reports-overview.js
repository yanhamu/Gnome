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
        selectReport: function (r) {
            var data = {
                reportId: r.id,
                dateFilter: {
                    from: '2017-01-01',
                    to: '2017-12-12'
                }
            };

            this.$http
                .post('reports/' + r.type, data)
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
                v-on:select-report="selectReport" v-bind:allowRemove="false" />
        </div>
    </div>
  </div>`
});