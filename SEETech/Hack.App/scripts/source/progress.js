define(['jquery', 'knockout'], function($, ko, guid) {
    ko.bindingHandlers.progress = {
        update: function(element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
            var $element = $(element);
            $element.removeClass();
            $element.empty();
            var value = ko.unwrap(valueAccessor());
            var bar = $('<div/>', {
                'class': 'progress-bar progress-bar-striped active'
            });
            bar.width(value + '%');

            $element
                .addClass('progress progress-info')
                .append(bar);

        }
    };
});