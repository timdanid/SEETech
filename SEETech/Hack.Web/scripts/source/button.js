
    ko.bindingHandlers.button = {
        update: function (element, valueAccessor) {
            var size = ko.unwrap(valueAccessor().size);
            var type = ko.unwrap(valueAccessor().type);

            $(element).removeClass();
            $(element).addClass("btn");

            if (size !== undefined || size !== null)  {
                $(element).addClass("btn-" + size);
            }

            if (type !== undefined || type !== null) {
                $(element).addClass("btn-" + type);
            } else {
                $(element).addClass("btn-default");
            }
        }
    };