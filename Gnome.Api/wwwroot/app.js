

const routes = [
    { path: '/accounts/:id', component: AccountDetail, props: true },
    { path: '/accounts', component: Accounts },
    { path: '/home', component: Home },
    { path: '*', redirect: '/home' }]

const router = new VueRouter({ routes })

const app = new Vue({
    data: {
        state: store.state
    },
    router
}).$mount('#app');
