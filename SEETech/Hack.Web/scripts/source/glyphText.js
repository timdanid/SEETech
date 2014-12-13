
    ko.bindingHandlers.glyphText = {
        update: function (element, valueAccessor) {
            var glyph = ko.unwrap(valueAccessor().glyph);
            var text = ko.unwrap(valueAccessor().text);
            var glyphFirst = ko.unwrap(valueAccessor().glyphFirst);
            $(element).empty();
            $(element).append("<i class='fa fa-lg fa-" + glyph + "' aria-hidden='true' ></i>  " + text);
        }
    };