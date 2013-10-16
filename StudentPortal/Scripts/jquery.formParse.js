/*

*/

(function ($) {
    $.fn.extend({

        uploadInit: function (options) {
            var rand = function () {
                return Math.floor(Math.random() * 10000000 + 1);
            }
            var defaults = {
                url: '',
                filters: [{
                    title: "Image files",
                    extensions: "jpg,gif,png"
                }],
                multi_selection: false,
                imageContainer: $('#' + rand()),
                progessBar: $('#' + rand()),
                imageVar: 'image'
            }

            options = $.extend({}, defaults, options)

            return $(this).each(function () {
                var _this = $(this);
                var progessBar = options.progessBar;
                var imageContainer = options.imageContainer;

                var uploader = new plupload.Uploader({
                    runtimes: 'gears,html5,flash',
                    browse_button: _this.attr('id'),
                    multi_selection: options.multi_selection,
                    url: options.url,
                    filters: [
					{
					    title: "Image files",
					    extensions: "jpg,gif,png"
					}
                    ]
                })

                uploader.bind('FileUploaded', function (up, file, result) {
                    //					alert(result.response);
                    var o = jQuery.parseJSON(result.response);
                    if (o.state == 'error') {
                        alert(o.message);
                    } else {
                        if (options.multi_selection) {
                            imageContainer.append('<li><img style="max-height:100px" src="' + o.thumb +
								'" alt="placeholder" /><input type="hidden" name="' + options.imageVar +
								'" value="' + o.id +
								'" /><div>' +
								'<ul style="width:67px">' +
								'<li class="edit"><a href="' + o.image + '">View</a></li>' +
								'<li class="delete" data="' + o.id + '"><a href="#">Delete</a></li>' +
								'</ul>' +
								'</div></li>');
                        } else {
                            imageContainer.attr('src', o.thumb);
                            imageContainer.parent().find('[name="' + options.imageVar + '"]').val(o.id);
                        }

                    }
                    progessBar.css({
                        display: 'none'
                    });
                })
                uploader.bind('QueueChanged', function (up, files) {
                    progessBar.css({
                        display: 'block'
                    });
                    uploader.start();
                })
                uploader.bind('UploadProgess', function (up, file) {
                    alert(file.percent);
                    progessBar.children(':first').css({
                        width: file.percent + '%'
                    });
                })

                uploader.init();
            })
        },
        formParse: function (options) {
            var defaults = {
                data: {},
                errors: {},
                specialFields: [],
                exceptFields: ['images'],
                hook: function () { },
                ajax: false,
                parsingAlert: "Đang xử lý yêu cầu, xin vui lòng đợi!",

            }

            options = $.extend({}, defaults, options)

            return $(this).each(function () {
                var data = options.data;
                var errors = options.errors;
                var fields = options.specialFields;
                $(this).data('parsing', false);
                if (options.ajax) {

                    $(this).submit(function () {
                        //						for ( instance in CKEDITOR.instances )
                        //							CKEDITOR.instances[instance].updateElement();
                        if ($(this).data('parsing')) {
                            //alert(options.parsingAlert);
                            return;
                        }
                        $(this).data('parsing', true);
                        var form = $(this)
                        $.ajax({
                            url: form.attr('action'),
                            dataType: 'json',
                            type: 'post',
                            data: form.serialize(),
                            success: function (obj) {
                                $(this).data('parsing', false);
                                var errors = obj.Errors;
                                if (obj.Status == 1) {

                                    form.find('.alert.alert-error').remove();
                                    for (var i in errors) {
                                        form.find('[name="' + i + '"]').parent().find('.help-inline').remove();
                                    }
                                    alert(obj.Message);
                                    if (obj.Redirect) window.location = obj.Redirect;
                                } else {
                                    var commonError = '';
                                    for (var i in errors) {
                                        for (var j in fields) {
                                            if (errors[i] != '' && i == fields[j]) {
                                                commonError += '<li>' + errors[i] + '</li>';
                                                break;
                                            }
                                        }
                                        //									alert(form.find('[name="'+i+'"]').parent().find('.help-inline').html())
                                        if (form.find('[name="' + i + '"]').parent().find('.help-inline').html() == null)
                                            form.find('[name="' + i + '"]').after('<span class="help-inline">' + errors[i] + '</span>');
                                        else
                                            form.find('[name="' + i + '"]').parent().find('.help-inline').replaceWith('<span class="help-inline">' + errors[i] + '</span>');


                                        if (!form.find('[name="' + i + '"]').parent().parent().hasClass('error'))
                                            form.find('[name="' + i + '"]').parent().parent().addClass('error');
                                    }
                                    if (commonError != '') {
                                        if (form.find('.alert.alert-error').html() == null)
                                            form.children(':first').before('<div class="alert alert-error">' +
												// '<button data-dismiss="alert" class="close" type="button">×</button>'+
												'<ul>' + commonError + '</ul>' +
												'</div>');
                                        else
                                            form.children(':first').replaceWith('<div class="alert alert-error">' +
												'<ul>' + commonError + '</ul>' +
												'</div>');
                                    } else {
                                        form.find('.alert.alert-error').remove();
                                    }
                                    if (obj.Message.length > 0)
                                        alert(obj.Message);
                                }
                            }
                        });
                        return false;
                    })
                }
                //				alert(data.footer);
                for (var i in data) {
                    if ($.inArray(i, options.exceptFields) >= 0) {
                        continue;
                    }
                    var element;
                    if (typeof (data[i]) == 'object')
                        element = $(this).find('[name="' + i + '[]"]');
                    else
                        element = $(this).find('[name="' + i + '"]');
                    //										alert(i+'-'+data[i]+'-'+element.attr('type'));
                    switch (element.attr('type')) {
                        case 'file':
                            break;
                        case 'checkbox':
                            element.find('[value=""]').attr('checked', true);
                        default:
                            element.val(data[i]);
                    }
                }
                var commonError = '';
                for (var i in errors) {
                    for (var j in fields) {
                        if (errors[i] != '' && i == fields[j]) {
                            commonError += '<li>' + errors[i] + '</li>';
                            break;
                        }
                    }
                    $(this).find('[name="' + i + '"]').after('<span class="help-inline">' + errors[i] + '</span>');
                    $(this).find('[name="' + i + '"]').parent().parent().addClass('error');
                }
                if (commonError != '')
                    $(this).children(':first').before('<div class="alert alert-error">' +
						'<ul>' + commonError + '</ul>' +
						'</div>');
                options.hook();
            })
        }
    });
})(jQuery);