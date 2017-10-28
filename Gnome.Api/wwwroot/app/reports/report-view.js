const ReportView = Vue.component('report-view', {
    data: function () {
        return {
            data: null,
            ranges: {
                'This Month': [moment().startOf('month'), moment()],
                'Last Month': [moment().startOf('month').subtract(1, 'month'), moment()],
                'Last 3 Months': [moment().startOf('month').subtract(3, 'month'), moment()],
                'Last 6 Months': [moment().startOf('month').subtract(6, 'month'), moment()],
                'Last Year': [moment().startOf('month').subtract(1, 'year'), moment()]
            },
            dates: {
                fromDate: moment().subtract(1, 'months').format('YYYY-MM-DD'),
                toDate: moment().format('YYYY-MM-DD')
            }
        };
    },
    props: ['id'],
    created: function () {

    },
    methods: {
        get: function () {

            this.$http
                .get('reports/' + this.id + '?from=' + this.dates.fromDate + '&to=' + this.dates.toDate)
                .then(res => this.data = res.body);
        }
    },
    template: `
<div class="container-fluid">
    <h3>report view</h3>
    <date-filter v-bind:ranges="ranges" v-bind:dates="dates" />

    <div class="row">
        <div class="col-sm-12">
            <button class="btn btn-primary" v-on:click="get">get</button>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-6">
            <table class="table table-hover table-bordered" v-if="data">
                <tbody>
                    <tr v-for="d in data.aggregates">
                        <td>{{d.interval.from|formatDate}} - {{d.interval.to|formatDate}}</td>
                        <td>{{d.expences}}</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</div>`
})