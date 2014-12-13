define(['jquery', 'knockout'], function ($, ko) {
    ko.bindingHandlers.glyphText = {
        update: function (element, valueAccessor) {
            var glyph = ko.unwrap(valueAccessor().glyph);
            var text = ko.unwrap(valueAccessor().text);
            var glyphFirst = ko.unwrap(valueAccessor().glyphFirst);
            $(element).empty();
            $(element).append("<span class='glyphicon glyphicon-" + glyph + "' aria-hidden='true' ></span>  " + text);
        }
    };
});