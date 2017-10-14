const ReportList = Vue.component('report-list', {
    data: function () {
        return {
        };
    },
    props: ['reports'],
    created: function () {
    },
    methods: {
    },
    template: `
  <div class="container-fluid">
    <h3>list</h3>
    <div class="row">
        <div class="col-md-6">
            <table class="table table-hover table-bordered">
                <tbody>
                    <tr v-for="r in reports">
                        <td>{{r.name}}</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
  </div>`
})