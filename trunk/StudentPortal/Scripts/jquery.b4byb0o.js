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
        // for CheckAll
        isSelectedIDsEmpty:function()
        {
            //return $(this).each(function(){
            var selectedIDs = $(this).data('value');
            var s = '';
            for (var i in selectedIDs) {
                s += i;
                if (selectedIDs[i]) {
                    return false;
                }
            }
            return true;
            //});
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
            var selectedIDs = $(this).data('value');
            return object2array(selectedIDs).join();
        },
        selectedIDs: function () {
            var result = [];
            var IDs = $(this).data('value');
            var k=0;
            for (var i in IDs)
                if (IDs[i])
                    result[k++] = i;
            return result;
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
                //alert(_this.attr('class'));
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
                selected: [],
                checkRow: '.checkRow',
                changeElement: null,
                toggleClass: 'checked'
            };
            options = $.extend({}, defaults, options);
            return $(this).each(function () {
                
                var obj = {};
                for (var i in options.selected) {
                    obj[options.selected[i]] = true;
                }
                var _this = $(this);
                $(this).data('value', obj);
                $(this).updateCheckRow();

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
        },


        // for AjaxQueue

        ajaxQueue: function (options) {
            var defaults = {
                urls: [],
                datas: [],
                type: 'post',
                processChanged: function () { },
                processCompleted: function () { }
            };

            options = $.extend({}, defaults, options);
            var n = options.datas.length;

            _this = $(this);

            _this.data('percent', 0);

            var sendRequest = function (i) {
                $.ajax({
                    url: options.urls[i],
                    data: options.datas[i],
                    type: options.type,
                    success: function (o) {
                        _this.data('percent', 100 * i / n);
                        options.processChanged(o);
                        if (i == n)
                        {
                            options.processCompleted(o);
                            return;
                        }
                        sendRequest(i + 1);
                    }
                })
            }

            sendRequest(0);
        },
        ajaxAction: function (options) {
            var defaults = {
                data: function () {
                    return {};
                },
                dataType: 'json',
                type: 'post',
                success: function (o) {
                },
            };
            options = $.extend({}, defaults, options);
            return $(this).each(function () {
                $(this).data('requesting', false);
                $(this).live('click', function () {
                    if (!$(this).data('requesting')) {
                        $.ajax({
                            url: $(this).attr('href'),
                            data: options.data(),
                            type: options.type,
                            dataType: options.dataType,
                            success: function (o) {
                                options.success(o);
                            }
                        });
                    } else {
                        alert("Bạn thao tác quá nhanh, vui lòng chờ giây lát!");
                    }
                    return false;
                });
                
            });
        }

    });
}(jQuery));
$(document).ready(function () {
    $('body').data('alert', false);
    function alert1(mes) {
        if (!$('body').data('alert')) {
            $('body').data('alert', true);
            alert(mes);
            $('body').data('alert', false);
        }
    }
    $('.fixedScroll').each(function () {
        $(this).before('<div></div>');
    });

    $(window).scroll(function () {
        $('.fixedScroll').each(function () {
            var yHeader = ($('#header').position()).top + $('#header').height();
            var fixedTopDetecter = $(this).prev()
            var fixedTop = $(this).attr('data-fixedtop');
            var yInfo = ($(this).position()).top;
            var yThumb = fixedTopDetecter.position().top;
            if (yHeader >= yInfo) {
                $(this).css({
                    position: 'fixed',
                    top: ($('#header').height()+ parseInt(fixedTop)) + 'px'
                })
            }
            if (yInfo < yThumb) {
                $(this).css({
                    position: 'relative',
                    top: '0px'
                })
            }
        })
    });
});