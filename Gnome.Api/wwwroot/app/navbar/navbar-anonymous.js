const na = Vue.component('navbar-anonymous', {
  template: `<nav class="navbar navbar-default">
    <div class="container-fluid">
        <div class="navbar-header">
            <router-link class="navbar-brand" to="/home">gnome</router-link>
        </div>
        <div id="navbar" class="navbar-collapse collapse">
            <ul class="nav navbar-nav navbar-right">
                <li>
                    <a href="/Home/Index">log in</a>
                </li>
            </ul>
        </div>
    </div>
</nav>`
})