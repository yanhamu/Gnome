const TransactionFilter = Vue.component('transaction-filter', {
    created: function () {
        this.fromDate = moment().subtract(1, 'months').format('YYYY-MM-DD');
        this.toDate = moment().format('YYYY-MM-DD');
    },
    mounted: function () {
        var self = this;
        $('#fromDateInput').daterangepicker({
            ranges: {
                'Today': [moment(), moment()],
                'Last 7 Days': [moment().subtract(6, 'days'), moment()],
                'Last Month': [moment().subtract(1, 'month'), moment()],
                'This Month': [moment().startOf('month'), moment().endOf('month')],
                'Last Year': [moment().subtract(1, 'year'), moment()]
            }
        });
        $('#fromDateInput').on('apply.daterangepicker', function (ev, picker) {
            self.fromDate = picker.startDate.format('YYYY-MM-DD');
            self.toDate = picker.endDate.format('YYYY-MM-DD');
        });
    },
    data: function () {
        return {
            fromDate: null,
            toDate: null,
            includeExpressions: [],
            excludeExpressions: [],
        }
    },
    methods: {
        send: function () {
            var data = {
                pageFilter: null,
                dateFilter: {
                    from: this.fromDate,
                    to: this.toDate
                }
            }
            this.$emit('filter-set', data);
        }
    },
    template: `
    <div class="container-fluid">
        <h4>filter</h4>
        <div class="form-group row">
            <label for="name" class="col-sm-2 col-form-label">From</label>
            <div class="col-sm-4">
                <input id="fromDateInput" class="form-control"/>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-offset-9 col-sm-3">
                <input value="filter" class="btn btn-primary btn-block" v-on:click="send" />
            </div>
        </div>
    </div>`
});