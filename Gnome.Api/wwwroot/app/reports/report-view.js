const ReportView = Vue.component('report-view', {
    data: function () {
        return {
            data: null
        };
    },
    props: ['id'],
    created: function () {
    },
    methods: {
        get: function () {
            this.$http
                .get('reports/' + this.id + '?from=2017-01-01&to=2017-12-12')
                .then(res => this.data = res.body);
        }
    },
    template: `
  <div class="container-fluid">
    <h3>report view</h3>
filter

<div class="row">
    <div class="col-sm-12">
        <button class="btn btn-primary" v-on:click="get">get</button>
    </div>
</div>
<div class="row">
    <div class="col-sm-12">
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