

const routes = [
    { path: '/accounts', component: Accounts },
    { path: '/home', component: Home },
    { path: '*', redirect: '/home' }]

const router = new VueRouter({ routes })

const app = new Vue({
    router
}).$mount('#app');
