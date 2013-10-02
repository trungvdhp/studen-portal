/*
Author: b4by.b0o
Email: kida7kahp@gmail.com
Description: Some utilities for forms
*/

(function ($) {

    // Send a checkRow status => change checkAll checkBox
    var changeCheckAll = function (checked, _this, checkRow, _changeElement, toggleClass) {
        var checkAll = false;
        var selectedIDs = _this.data('value');
        if (checked) {
            var checkAll = true;
            $(checkRow).each(function (e) {
                if (!selectedIDs[$(this).val()]) checkAll = false;
            });

        }
        _this.attr('checked', checkAll);
        if (_changeElement != null) {
            var changeElement = eval(_changeElement);
            if (checkAll)
                changeElement.addClass(toggleClass);
            else
                changeElement.removeClass(toggleClass);
        }
    };

    $.fn.extend({

        isSelectedIDsEmpty:function()
        {
            return $(this).each(function(){
                var selectedIDs = $(this).data('value');
                for (var i in selectedIDs)
                    if (selectedIDs[i])
                        return false;
                return true;
            });
        },

        selectedIDsToString: function()
        {
            function object2array(object) {
                var IDs = [];
                var i = 0;
                for (var id in object)
                    if (object[id]) IDs[i++] = id;
                return IDs;
            }
            return $(this).each(function(){
                var selectedIDs = $(this).data('value');
                return object2array(selectedIDs).join();
            });
        },

        updateCheckRow: function(options)
        {
            var defaults = {
                checkRow: '.checkRow',
                changeElement: null,
                toggleClass: 'checked'
            };
            options = $.extend({}, defaults, options);

            return $(this).each(function () {
                var _this = $(this);
                var selectedIDs = _this.data('value');
                $(options.checkRow).each(function (e) {

                    if (selectedIDs[$(this).val()]) {
                        $(this).attr('checked', true);
                    }
                });
                changeCheckAll(true, _this, options.checkRow, options.changeElement, options.toggleClass);

            });
        },
        initCheckAll: function (options) {
            var defaults = {
                checkRow: '.checkRow',
                changeElement: null,
                toggleClass: 'checked'
            };
            options = $.extend({}, defaults, options);
            return $(this).each(function () {
                $(this).data('value',{});

                var _this = $(this);

                $(this).change(function () {
                    var checked = $(this).attr('checked') == 'checked';
                    var selectedIDs = $(this).data('value');
                    $(options.checkRow).attr('checked', checked);
                    $(options.checkRow).each(function () {
                        selectedIDs[$(this).val()] = checked;
                    });
                    $(this).data('value',selectedIDs);
                });

                $(options.checkRow).live('click',function () {
                    var checked = $(this).attr('checked') == 'checked';
                    var selectedIDs = _this.data('value');
                    selectedIDs[$(this).val()] = checked;
                   _this.data('value', selectedIDs);
                    changeCheckAll(checked,_this,options.checkRow,options.changeElement,options.toggleClass);
                });

            });
        }
    });
}(jQuery));