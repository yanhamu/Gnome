const nr = Vue.component('navbar-registered', {
    template: `<nav class="navbar navbar-default">
    <div class="container-fluid">
        <div class="navbar-header">
            <router-link class="navbar-brand" to="/home">gnome</router-link>
        </div>
        <div id="navbar" class="navbar-collapse collapse">
            <ul class="nav navbar-nav">
                <li>
                    <router-link to="/accounts">accounts</router-link>
                </li>
                <li>
                    <router-link to="/reports">reports</router-link>
                </li>
            </ul>
            <ul class="nav navbar-nav navbar-right">
                <li>
                    <a href="/Authentication/LogOut">log out</a>
                </li>
            </ul>
        </div>
    </div>
</nav>`
})