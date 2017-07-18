store = {
    state: {
        isAuthetnicated: false,
        token: null
    },
    setToken: function (token) {
        if (token != null) {
            this.isAuthetnicated = true;
            this.token = token
        } else {
            this.isAuthetnicated = false;
            this.token = null
        }
    },
    getToken: function () {
        return this.token
    }
}