const TransactionFilter = Vue.component('transaction-filter', {
    created: function () {
        var toDate = new Date();
        var fromDate = new Date(new Date().setDate(new Date().getDate() - 30))
        this.fromDate = this.getDateString(fromDate);
        this.toDate = this.getDateString(toDate);
    },
    data: function () {
        return {
            fromDate: null,
            toDate: null,
        }
    },
    methods: {
        getDateString: function (d) {
            var day = d.getDate();
            var month = d.getMonth() + 1;
            var year = d.getFullYear();
            return year + "-" + month + "-" + day;
        },
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
            <div class="col-sm-10">
                <input type="date" class="form-control" v-model="fromDate" />
            </div>
        </div>
        <div class="form-group row">
            <label for="name" class="col-sm-2 col-form-label">To</label>
            <div class="col-sm-10">
                <input type="date" class="form-control" v-model="toDate" />
            </div>
        </div>
        <div class="row">
            <div class="col-sm-offset-9 col-sm-3">
                <input value="filter" class="btn btn-primary btn-block" v-on:click="send" />
            </div>
        </div>
    </div>`
});