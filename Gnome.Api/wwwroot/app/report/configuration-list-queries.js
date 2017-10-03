const ConfigurationQueryList = Vue.component('configuration-query-list', {
    data: function () {
        return {
            selected: null,
            queries: []
        };
    },
    created: function () {
        this.$http.get("queries")
            .then(function (res) {
                this.queries = res.data;
            });
    },
    methods: {
        select: function (query) {
            this.$emit("query-selected", query);
        }
    },
    template: `
  <div class="container-fluid">
    <h3>query list</h3>
    <div class="row">
        <div class="col-sm-12">
            <table class="table table-hover">
                <tbody>
                    <tr v-for="q in queries" v-on:click="select(q)">
                        <td>{{ q.name }}</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
  </div>`
});