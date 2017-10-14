const ReportWizard = Vue.component('report-wizard', {
    data: function () {
        return {
            reports: [],
            step: 1,
            queries: [],
            report: null
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
            this.report = { name: 'new report name', queryName: "" };
            this.step += 1;
        },
        selectReport: function (r) {
            this.report = r;
            var q = this.findQuery(r.queryId);
            this.report.queryName = q.name;
            this.step += 1
        },
        removeReport: function (r) {
            this.$http
                .delete('reports/' + r.id)
                .then(res => {
                    var query = this.findQuery(r.id);
                    var index = this.queries.indexOf(query);
                    this.queries.splice(index, 1);
                })
        },
        findQuery: function (id) {
            for (var i in this.queries) {
                if (this.queries[i].queryId == id)
                    return this.queries[i];
            }
            return null;
        },
        save: function () {
            if (this.report.id) {
                this.$http.put('reports/' + this.report.id, this.report).then(res => console.log('saved'))
            } else {
                this.$http.post('reports', this.report).then(res => console.log('saved'))
            }
        }
    },
    template: `
  <div class="container-fluid">
    <h3>reports</h3>
    <div class="row">
        <div class="col-md-12">
            <report-list 
                v-if="step == 1" 
                v-bind:reports="reports" 
                v-on:select-report="selectReport"
                v-on:remove-report="removeReport"/>
            <report-details 
                v-if="step == 2" 
                v-bind:report="report" 
                v-bind:queries="queries" 
                v-on:save="save"/>
        </div>
    </div>
    <div class="row">
        <div class="col-md-3">
            <button class="btn btn-primary" v-if="step == 1" v-on:click="create">create new</button>
        </div>
    </div>
  </div>`
});