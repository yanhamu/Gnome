const ReportList = Vue.component('report-list', {
    data: function () {
        return {
        };
    },
    props: ['reports', 'allowRemove'],
    created: function () {
    },
    methods: {
        select: function (r) {
            this.$emit('select-report', r);
        },
        remove: function (r) {
            this.$emit('remove-report', r);
        }
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
                        <td>
                            <button class='btn btn-primary' v-on:click="select(r)"">
                                <span class="glyphicon glyphicon-pencil" />
                            </button>
                        </td>
                        <td v-if="allowRemove">
                            <button class='btn btn-danger' v-on:click="remove(r)"">
                                <span class="glyphicon glyphicon-remove" />
                            </button>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
  </div>`
})