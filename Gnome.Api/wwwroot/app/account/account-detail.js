const AccountDetail = Vue.component('account-detail', {
    props: ['id'],
    created: function () {
        this.load();
    },
    methods: {
        load: function () {
            var options = { headers: { Authorization: store.getToken() } };
            this.$http.get('http://localhost:9020/api/accounts/' + this.id, options)
                .then(res => {
                    this.account = res.body;
                }, res => {
                    console.log(res);
                });
        },
        remove: function () {
            this.$http.delete('http://localhost:9020/api/accounts/' + this.id)
                .then(res => {
                    router.push('/accounts');
                }, res => {
                    console.log(res);
                });
        },
        update: function () {
            var data = this.account;
            this.$http.put('http://localhost:9020/api/accounts/' + this.id, data)
                .then(res => {

                },
                res => {
                    console.log(res);
                }
                );
        }
    },
    data: function () {
        return { account: { id: null, name: null, token: null } }
    },
    template: `
<div class="container-fluid">
    <h3>account settings</h3>
    <div class="form-group row">
        <label for="name" class="col-sm-2 col-form-label">Name</label>
        <div class="col-sm-10">
            <input type="text" v-model="account.name" class="form-control" />
        </div>
    </div>
    <div class="form-group row">
        <label for="token" class="col-sm-2 col-form-label">Token</label>
        <div class="col-sm-10">
            <input type="text" v-model="account.token" class="form-control" />
        </div>
    </div>
    <div class="row">
        <div class="col-sm-offset-10 col-sm-2">
            <input value="save" class="btn btn-primary btn-block" v-on:click="update" />
        </div>
    </div>
    <div class="row">
        <div class="col-sm-2"></div>
    </div>
    <div class="row">
        <div class="col-sm-offset-10 col-sm-2">
            <input value="delete" class="btn btn-danger btn-block" v-on:click="remove" />
        </div>
    </div>
</div>
`
})