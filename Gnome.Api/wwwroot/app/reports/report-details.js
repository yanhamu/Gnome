const ReportDetails = Vue.component('report-details', {
    data: function () {
        return {
        };
    },
    props: ['queries', 'report'],
    created: function () {
    },
    methods: {
        selectQuery: function (query) {
            this.report.queryName = query.name;
            this.report.queryId = query.queryId;
        },
        save: function () {
            this.$emit('save');
        }
    },
    template: `
  <div class="container-fluid">
    <h3>details</h3>
    <div class="form-group row">
        <label class="col-sm-2 col-form-label">report name</label>
        <div class="col-sm-10">
            <input type="text" v-model="report.name" class="form-control" />
        </div>
    </div>
    <div class="form-group row">
        <label class="col-sm-2 col-form-label">selected query</label>
        <div class="col-sm-10">
            <input type="text" v-model="report.queryName" class="form-control" disabled/>
        </div>
    </div>
    <div class="form-group row">
        <label for="query" class="col-sm-2 col-form-label">report type</label>
        <div class="col-sm-10">
            <select v-model="report.type">
                <option disabled value="">Please select one</option>
                <option>cumulative</option>
                <option>aggregate</option>
            </select>
        </div>
    </div>
    <div class="row">
        <div class="col-md-6">
        </div>
        <div class="col-md-6">
            <table class="table table-hover">
                <tbody>
                    <tr v-for="q in queries" v-on:click="selectQuery(q)">
                        <td>{{ q.name }}</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
    <div class="row">
        <div class="col-md-6">
            <button class="btn btn-primary" v-on:click="save">save</button>
        </div>
    </div>
  </div>`
})