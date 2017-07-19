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
        return this.state.token
    }
}

var t = localStorage.getItem('t')
if (t != null) {
    store.setToken(t);
}