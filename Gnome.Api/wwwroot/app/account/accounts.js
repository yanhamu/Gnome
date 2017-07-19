const Accounts = Vue.component('accounts', {
    template: `<p>account</p>`,
    created: function () {
        var token = 'bearer ' + store.getToken();
        var options = { headers: { Authorization: token } };
        this.$http.get('http://localhost:9020/api/accounts', options)
            .then(res => {
                console.log(res.body.result);

            }, res => {
                console.log('error');
            });
    },
    data: function () {
        return { accounts: [] }
    }
});