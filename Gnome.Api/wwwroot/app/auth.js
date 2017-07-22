store = {
    state: {
        isAuthetnicated: false,
        token: null
    },
    setToken: function (token) {
        if (token != null) {
            this.state.isAuthetnicated = true;
            this.state.token = token
            localStorage.setItem('t', token);
        } else {
            this.state.isAuthetnicated = false;
            this.state.token = null
        }
    },
    getToken: function () {
        if (this.state.token == null)
            return null;
        return 'bearer ' + this.state.token;
    }
}

var t = localStorage.getItem('t')
if (t != null) {
    store.setToken(t);
}