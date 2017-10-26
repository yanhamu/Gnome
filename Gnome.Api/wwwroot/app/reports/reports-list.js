const ReportList = Vue.component('report-list', {
    data: function () {
        return {
        };
    },
    props: ['reports', 'allowRemove', 'allowEdit', 'allowReport'],
    created: function () {
    },
    methods: {
        edit: function (r) {
            this.$emit('edit-report', r);
        },
        remove: function (r) {
            this.$emit('remove-report', r);
        },
        select: function (r) {
            this.$emit('select-report', r);
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
                        <td >
                            <button class='btn btn-primary' v-on:click="edit(r)" v-if="allowEdit">
                                <span class="glyphicon glyphicon-pencil" />
                            </button>
                            <button class='btn btn-danger' v-on:click="remove(r)" v-if="allowRemove">
                                <span class="glyphicon glyphicon-remove" />
                            </button>
                            <button class='btn btn-info' v-on:click="select(r)" v-if="allowReport">
                                <span class="glyphicon glyphicon-signal" />
                            </button>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
  </div>`
})