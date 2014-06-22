$('#form-restaurants').submit(function (e) {
    e.preventDefault();
    $('#loading').show();
    var form = $(this);
    var errorBlock = form.find(".field-validation-valid:first");
    errorBlock.removeClass('field-validation-error').addClass('field-validation-valid');
    if (form.valid()) {
        $.ajax({
            type: "GET",
            url: form.attr('action'),
            data: form.serialize(),
            success: function(response) {
                if (response.Error) {
                    errorBlock.removeClass('field-validation-valid').addClass('field-validation-error');
                    errorBlock.text(response.Error);
                } else {
                    $('#restaurants-table').html(response);
                }
                $('#loading').hide();
            }
        });
    } else {
        $('#loading').hide();
    }
});

$(document).on('click', '.show-products', function (e) {
    e.preventDefault();
    $('#loading').show();
    var link = $(this);
    if (!link.hasClass('disabled')) {
        link.addClass('disabled');
        var url = link.attr('data-url');
        $.get(url, function (html) {
            link.parents('tr').next().find('td').html(html);
            link.removeClass('disabled');
            $('#loading').hide();
        });
    }
});