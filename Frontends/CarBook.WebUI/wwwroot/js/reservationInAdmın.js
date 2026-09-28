$(document).ready(function () {
    $(document).on("click", ".open-reservation-modal", function () {
        let reservationId = $(this).data("id");
        let fullName = $(this).data("fullname");
        let email = $(this).data("email");
        let phone = $(this).data("phone");
        let car = $(this).data("car");
        var isActionActive = $(this).data('is-action-active');
        let pickUpLoc = $(this).data("pickup-location");
        let dropOffLoc = $(this).data("dropoff-location");
        let pickUpDate = $(this).data("pickup-date");
        let pickUpTime = $(this).data("pickup-time");
        let dropOffDate = $(this).data("dropoff-date");
        let dropOffTime = $(this).data("dropoff-time");
        let price = $(this).data("price");
        let status = $(this).data("modalStatus");

        $("#modalFullName").text(fullName);
        $("#reservationId").text(reservationId);
        $("#modalEmail").text(email);
        $("#modalPhone").text(phone);
        $("#modalCarName").text(car);
        $("#price").text(price);
        $("#modalStatus").text(status);
        $("#modalPickUpLocation").text(pickUpLoc);
        $("#modalPickUpDateTime").text(pickUpDate + " - " + pickUpTime);
        $("#modalDropOffLocation").text(dropOffLoc);
        $("#modalDropOffDateTime").text(dropOffDate + " - " + dropOffTime);

        var $deleteBtn = $('#modalDeleteBtn');
        var $sendMailBtn = $('#sendEmailBtn');

        if (isActionActive === true || isActionActive === "true") {
            $deleteBtn.removeClass('disabled pointer-events-none').attr('href', '/Admin/Reservation/DeleteReservation/' + reservationId).show();
            $sendMailBtn.prop('disabled', false).removeClass('pointer-events-none');
        } else {
            $deleteBtn.addClass('disabled pointer-events-none').attr('href', '#');
            $sendMailBtn.prop('disabled', true).addClass('pointer-events-none');
        }
        $('#aiMessageContent').val('');
    });

    $('#generateAiMessageBtn').on('click', function () {
        let fullName = $('#modalFullName').text().trim();
        let reservationId = $('#reservationId').text().trim();
        let price = $('#price').text().trim();
        let email = $('#modalEmail').text().trim();
        let phone = $('#modalPhone').text().trim();
        let carName = $('#modalCarName').text().trim();
        let pickUpLoc = $('#modalPickUpLocation').text().trim();
        let dropOffLoc = $('#modalDropOffLocation').text().trim();
        let pickUpDateTime = $('#modalPickUpDateTime').text().trim();
        let dropOffDateTime = $('#modalDropOffDateTime').text().trim();

        var $textarea = $('#aiMessageContent');
        var $btn = $(this);

        if (!fullName || !carName) {
            alert("İşlem yapılacak rezervasyon bilgisi bulunamadı.");
            return;
        }

        $btn.prop('disabled', true).html('<i class="mdi mdi-loading mdi-spin mr-1"></i> Yanıt Üretiliyor...');
        $textarea.val('Yapay zeka rezervasyon bilgilendirme mesajı hazırlıyor, lütfen bekleyin...');

        $.ajax({
            url: '/Admin/Reservation/GenerateAIMessage',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify({
                fullName: fullName,
                email: email,
                phone: phone,
                carName: carName,
                pickUpLocation: pickUpLoc,
                dropOffLocation: dropOffLoc,
                pickUpDateTime: pickUpDateTime,
                dropOffDateTime: dropOffDateTime,
                price : price
            }),
            success: function (response) {
                if (response.success) {
                    $textarea.val(response.reply);
                } else {
                    alert(response.message || 'Yapay zeka yanıt üretirken bir hata oluştu.');
                    $textarea.val('');
                }
            },
            error: function () {
                alert('Sunucu ile iletişim kurulurken bir hata oluştu.');
                $textarea.val('');
            },
            complete: function () {
                $btn.prop('disabled', false).html('<i class="mdi mdi-robot mr-1"></i> AI ile Mesaj Oluştur');
            }
        });
    });

    $('#sendEmailBtn').on('click', function () {
        let email = $('#modalEmail').text().trim();
        let message = $('#aiMessageContent').val().trim();
        let reservationId = $('#reservationId').text().trim();
        let status = $('#modalStatus').text().trim();

        if (!message) {
            alert("Lütfen gönderilecek bir mesaj içeriği oluşturun veya yazın.");
            return;
        }

        let $btn = $(this);
        $btn.prop('disabled', true).html('<i class="mdi mdi-loading mdi-spin mr-1"></i> Gönderiliyor...');

        $.ajax({
            url: '/Admin/Reservation/SendReservationEmail',
            type: 'POST',
            data: {
                email: email,
                message: message,
                Id: reservationId,
                Status : status
            },
            success: function (response) {
                if (response.success) {
                    alert(response.message);
                    $('#reservationDetailModal').modal('hide');
                } else {
                    alert("Hata: " + response.message);
                }
            },
            error: function () {
                alert("Sunucu ile iletişim kurulamadı, lütfen tekrar deneyin.");
            },
            complete: function () {
                $btn.prop('disabled', false).html('<i class="mdi mdi-email-send mr-1"></i> Mail Gönder');
            }
        });
    });
});