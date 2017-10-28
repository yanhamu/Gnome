const DateFilter = Vue.component('date-filter', {
    props: ['ranges', 'dates'],
    created: function () {
        //this.dates.fromDate = moment().subtract(1, 'months').format('YYYY-MM-DD');
        //this.dates.toDate = moment().format('YYYY-MM-DD');
    },
    mounted: function () {
        var self = this;
        $('#fromDateInput').daterangepicker({
            ranges: self.ranges
        });

        $('#fromDateInput').on('apply.daterangepicker', function (ev, picker) {
            self.dates.fromDate = picker.startDate.format('YYYY-MM-DD');
            self.dates.toDate = picker.endDate.format('YYYY-MM-DD');
        });
    },
    data: function () {
        return {
            fromDate: null,
            toDate: null,
        }
    },
    methods: {
    },
    template: `
<div class="container-fluid">
    <div class="form-group row">
        <label for="name" class="col-sm-2 col-form-label">From</label>
        <div class="col-sm-4">
            <input id="fromDateInput" class="form-control"/>
        </div>
    </div>
</div>`
});