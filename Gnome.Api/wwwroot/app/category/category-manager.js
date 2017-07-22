const CategoryManager = Vue.component('category-manager', {
    data: function () {
        return {
            root: {}
        };
    },
    created: function () {
        this.$http.get('categories')
            .then(res => {
                this.root = res.body;
            }, res => {
                console.log(res);
            });
    },
    methods: {

    },
    template: `
  <div class="container-fluid">
    <div class="row">
        <div class="col-md-6">
            <div class="panel panel-default">
                <div class="panel-body">
                    <ul>
                        <category-node v-bind:node="node" v-for="node in root.children" :key="node.id" ></category-node>
                    </ul>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            
        </div>
    </div>
  </div>`
});