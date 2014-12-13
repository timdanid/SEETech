
    ko.bindingHandlers.glyph = {
        update: function (element, valueAccessor) {
            var val = ko.unwrap(valueAccessor());
            $(element).removeClass();
            $(element).addClass("glyphicon glyphicon-" + val);
            $(element).attr("aria-hidden", "true");
        }
    };