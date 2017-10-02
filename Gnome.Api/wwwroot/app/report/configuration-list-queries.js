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
    },
    template: `
  <div class="container-fluid">
    <h3>query list</h3>
    <div class="row">
        <div class="col-sm-12">
            <table>
                <tr v-for="q in queries">
                    <td>{{ q.name }}</td>
                </tr>
            </table>
        </div>
    </div>
  </div>`
});