$(document).ready(function () {
    $('.btn-detail').on('click', function () {
        var id = $(this).data('id');
        var name = $(this).data('name');
        var email = $(this).data('email');
        var subject = $(this).data('subject');
        var message = $(this).data('message');
        var date = $(this).data('date');

        $('#modalContactId').val(id);
        $('#modalName').text(name);
        $('#modalNameInput').val(name);
        $('#modalEmail').text(email);
        $('#modalEmailInput').val(email);
        $('#modalSubject').text(subject);
        $('#modalMessage').text(message);
        $('#modalDate').text(date);

        $('#replySubject').val(subject);
        $('#replyMessage').val('');
    });


    $('#btnGenerateAi').on('click', function () {
        var name = $('#modalName').text().trim();
        var subject = $('#modalSubject').text().trim();
        var message = $('#modalMessage').text().trim();
        var $textarea = $('#replyMessage');
        var $btn = $(this);

        if (!message) {
            alert("Yanıt oluşturulacak mesaj bulunamadı.");
            return;
        }

        $btn.prop('disabled', true).html('<i class="mdi mdi-loading mdi-spin mr-1"></i> Yanıt Üretiliyor...');
        $textarea.val('Yapay zeka yanıt oluşturuyor, lütfen bekleyin...');

        $.ajax({
            url: '/Admin/Contact/GenerateAIMessage',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify({
                name: name,
                subject: subject,
                message: message
            }),
            success: function (response) {
                if (response.success) {
                    $textarea.val(response.reply);
                    $textarea.prop('readonly', true);
                } else {
                    alert(response.message || 'Yanıt üretilirken bir hata oluştu.');
                    $textarea.val('');
                }
            },
            error: function () {
                alert('Sunucu ile iletişim kurulurken bir hata oluştu.');
                $textarea.val('');
            },
            complete: function () {
                $btn.prop('disabled', false).html('<i class="mdi mdi-robot mr-1"></i> AI İle Yanıt Oluştur');
            }
        });
    });
});