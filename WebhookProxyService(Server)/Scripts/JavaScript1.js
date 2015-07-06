(function (global, undefined) {

    $.connection.hub.url = '/signalr/hubs';
    $.connection.hub.start().done(function () {
        console.log('connected');
    });
    var myHub = $.connection.WebHook;
    $('.input-lg').on('change', function () {
        myHub.server.hello(this.value);
    });
})(this);