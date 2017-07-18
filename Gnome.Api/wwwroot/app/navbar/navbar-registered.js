const nr = Vue.component('navbar-registered', {
    template: `<nav class="navbar navbar-default">
    <div class="container-fluid">
        <div class="navbar-header">
            <a class="navbar-brand" href="/Home/Index">gnome</a>
        </div>
        <div id="navbar" class="navbar-collapse collapse">
            <ul class="nav navbar-nav">
                <li>
                    <a href="/Account">accounts</a>
                </li>
                <li>
                    <a href="/Report/AggregateReport">reports</a>
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