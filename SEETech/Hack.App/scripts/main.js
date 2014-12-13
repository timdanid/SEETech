require.config({
    baseUrl: 'Scripts',
    urlArgs: "bust=" + (new Date()).getTime(),
    paths: {
        jquery: 'vendor/jquery',
        knockout: 'vendor/knockout',
        knockoutMapping: 'vendor/knockout.mapping'
    }
});


var viewmodel;
require(['jquery', 'knockout', 'knockoutMapping', 'source/glyph', 'source/button', 'source/glyphText', 'source/timeAgo', 'source/alert', 'source/progress'], function($, ko, mapping) {
    ko.mapping = mapping;
    var data = {
                progress: 25,
                dateCreated: new Date(1993, 11, 1, 0, 0, 0),
                glyph1: 'star',
                glyph2: 'heart',
                button1: { type: 'default', size: 'lg' },
                text1: 'abc',
                alerts: [
                    {'message': 'Here is an Error', 'priority': 'danger' },
                    {'message': 'Here is a Warning', 'priority': 'warning'},
                    {'message': 'Here is a Success', 'priority': 'success' },
                    {'message': 'Here is some Info', 'priority': 'info' }
                ]
            };
    viewmodel = ko.mapping.fromJS(data);
    ko.applyBindings(viewmodel);
    data.text1 = "Star";

    viewmodel = ko.mapping.fromJS(data, viewmodel);
});