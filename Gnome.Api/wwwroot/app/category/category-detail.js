const CategoryDetail = Vue.component('category-detail', {
    props: ['category', 'allCategories'],
    methods: {
        update: function () {
            this.$http.put('categories/' + this.category.id, this.category)
                .then();
        }
    },
    template: `
<div class="panel panel-default">
    <div class="panel-body">
        <div class="form-group row">
            <label for="name" class="col-sm-2 col-form-label">Name</label>
            <div class="col-sm-10">
                <input type="text" v-model="category.name" class="form-control" />
            </div>
        </div>
        <div class="form-group row">
            <label for="name" class="col-sm-2 col-form-label">Parent</label>
            <div class="col-sm-10">
                <select class="form-control" v-model="category.parentId">
                    <option v-for="n in allCategories" v-bind:value="n.id">{{n.name}}</option>
                </select>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-offset-9 col-sm-3">
                <input value="update" class="btn btn-primary btn-block" v-on:click="update" />
            </div>
        </div>
    </div>
</div>`
});