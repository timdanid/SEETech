
    ko.bindingHandlers.alert = {
        update: function(element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
            var $element = $(element);
            var alertInfo = ko.unwrap(valueAccessor());
            $element.removeClass();
            $element.empty();

            var dismissBtn = $('<button/>', {
                'type': 'button',
                'class': 'close',
                'data-dismiss': 'alert'
            }).html('&times;');

            var alertMessage = $('<p/>').html(alertInfo.message());

            $element.addClass('alert alert-' + alertInfo.priority())
                .append(dismissBtn)
                .append(alertMessage);
        }
    }