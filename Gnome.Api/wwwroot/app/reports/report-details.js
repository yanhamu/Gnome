const ReportDetails = Vue.component('report-details', {
    data: function () {
        return {
        };
    },
    props: ['queries'],
    created: function () {
    },
    methods: {
    },
    template: `
  <div class="container-fluid">
    <h3>details</h3>
    <div class="row">
        <div class="col-md-6">
            type, query, name, time
        </div>
    </div>
  </div>`
})