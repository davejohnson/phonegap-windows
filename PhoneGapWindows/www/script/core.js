PhoneGap = {
    addConstructor: function(f) {
        window.onload = f;
    },
    exec: function(m, args) {
        //Location.startLocation
        var querystring = "?";
        for (var item in args) {
            querystring += item + "=" + args[item] + "&";
        }
        document.title = "gap://"+m+querystring;
    }
};

function createElement(m) {
    var d = document.createElement('div');
    d.innerHTML = m;
    document.body.appendChild(d);
}