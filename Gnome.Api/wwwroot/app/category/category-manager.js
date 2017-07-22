const CategoryManager = Vue.component('category-manager', {
    data: function () {
        return {
            root: {},
            selected: {},
            allCategories: []
        };
    },
    created: function () {

        function getList(node) {
            var list = [node];
            node.children.forEach(function (c) {
                list = list.concat(getList(c));
            });
            return list;
        }

        this.$http.get('categories')
            .then(res => {
                this.root = res.body;
                this.allCategories = (getList(this.root));

            }, res => {
                console.log(res);
            });
    },
    methods: {
        nodeSelected: function (node) {
            this.selected = node;
        },
        create: function (node) {
            var category = { parentId: this.root.id, name: "new category" };
            this.$http.post('categories', category).then(res => {
                var newCategory = res.body;
                this.root.children.push(newCategory)
                this.allCategories.push(newCategory);
                this.selected = newCategory;
            }, res => {
                console.error(res);
            });
        }
    },
    template: `
  <div class="container-fluid">
    <div class="row">
        <div class="col-md-6">
            <div class="panel panel-default">
                <div class="panel-body">
                    <ul>
                        <category-node v-bind:node="node" v-for="node in root.children" :key="node.id" v-on:node-selected="nodeSelected" ></category-node>
                    </ul>
                    <input value="create new" class="btn btn-primary btn-block" v-on:click="create" />
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <category-detail 
                v-bind:category="selected" 
                v-bind:allCategories="allCategories"></category-detail>
        </div>
    </div>
  </div>`
});