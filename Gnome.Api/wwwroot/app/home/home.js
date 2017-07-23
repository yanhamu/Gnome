const Home = Vue.component('home', {
    data: function () {
        return {
            loginEmail: '',
            loginPassword: '',
            registerEmail: '',
            registerPassword: ''
        }
    },
    methods: {
        login: function () {
            var data = { username: this.loginEmail, password: this.loginPassword };
            this.$http.post('gettoken', data, { emulateJSON: true })
                .then(res => {
                    store.setToken(res.body.access_token);
                }, res => {
                    store.setToken(null);
                });
        },
        register: function () {
            var data = { email: this.registerEmail, password: this.registerPassword };
            this.$http.post('users', data)
                .then(res => {
                    this.loginEmail = this.registerEmail;
                    this.loginPassword = this.registerPassword;
                    this.login();
                });
        }
    },
    template: `
  <div class="container-fluid">
    <div class="row">
      <div class="col-sm-6">
        <h1>Log in</h1>
            <div class="form-group">
                <label for="log-in-email">Email address</label>
                <input id="log-in-email" type="email" placeholder="your@email.com" class="form-control" v-model="loginEmail" />
            </div>
            <div class="form-group">
                <label for="log-in-password">Password</label>
                <input id="log-in-password" type="password" class="form-control" v-model="loginPassword" />
            </div>
            <button class="btn btn-primary" v-on:click="login">Log in</button>
      </div>
      <div class="col-sm-6">
        <h1>Sign up</h1>
            <div class="form-group">
                <label for="register-email">Email address</label>
                <input type="email" id="register-email" placeholder="your@email.com" class="form-control" v-model="registerEmail" />
            </div>
            <div class="form-group">
                <label for="register-password">Password</label>
                <input id="register-password" type="password" class="form-control" v-model="registerPassword" />
            </div>
            <button class="btn btn-primary" v-on:click="register" >Register</button>
      </div>
    </div>
  </div>`
})