var Id = null;
function showToast(message, type) {
    var toast = document.getElementById('resToast');
    var toastText = document.getElementById('resToastText');
    var icon = toast.querySelector('i');

    toastText.textContent = message;
    toast.className = 'res-toast show ' + (type || 'success');
    icon.className = type === 'error' ? 'fas fa-circle-exclamation' : 'fas fa-check-circle';

    setTimeout(function() {
        toast.classList.remove('show');
    }, 3500);
}

function resOpenUpdateModal(btn) {
    var card = btn.closest('.res-card');

    document.getElementById('updateResId').value = card.dataset.id;
    document.getElementById('updateModalCarName').textContent = card.dataset.carname + ' için tarih/saat bilgilerini güncelleyin';
    document.getElementById('updatePickUpDate').value = card.dataset.pickupdate;
    document.getElementById('updatePickUpTime').value = card.dataset.pickuptime;
    document.getElementById('updateDropOffDate').value = card.dataset.dropoffdate;
    document.getElementById('updateDropOffTime').value = card.dataset.dropofftime;

    document.getElementById('updateModalOverlay').classList.add('active');
}

function resCloseUpdateModal() {
    document.getElementById('updateModalOverlay').classList.remove('active');
}

document.getElementById('updateReservationForm').addEventListener('submit', function(e) {
    e.preventDefault();

    var rawPickUpTime = document.getElementById('updatePickUpTime').value;
    var rawDropOffTime = document.getElementById('updateDropOffTime').value;

    var formattedPickUpTime = rawPickUpTime.length === 5 ? rawPickUpTime + ':00' : rawPickUpTime;
    var formattedDropOffTime = rawDropOffTime.length === 5 ? rawDropOffTime + ':00' : rawDropOffTime;

    var payload = {
        Id: parseInt(document.getElementById('updateResId').value, 10),
        PickUpDate: document.getElementById('updatePickUpDate').value,
        PickUpTime: formattedPickUpTime,
        DropOffDate: document.getElementById('updateDropOffDate').value,
        DropOffTime: formattedDropOffTime
    };

    fetch('/Users/Account/UpdateReservation', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(payload)
    })
        .then(function(res) { return res.json().then(function(data) { return { ok: res.ok, data: data }; }); })
        .then(function(result) {
            resCloseUpdateModal();
            if (result.ok) {
                showToast('Rezervasyon başarıyla güncellendi.', 'success');
                setTimeout(function() { location.reload(); }, 900);
            } else {
                var msg = (result.data && result.data.message) ? result.data.message : 'Güncelleme sırasında bir hata oluştu.';
                showToast(msg, 'error');
            }
        })
        .catch(function() {
            resCloseUpdateModal(); 
            showToast('Sunucuya ulaşılamadı, lütfen tekrar deneyin.', 'error');
        });
});

function openCancelModal(id) {
    Id = id;
    document.getElementById('cancelModalOverlay').classList.add('active');
}

function closeCancelModal() {
    Id = null;
    document.getElementById('cancelModalOverlay').classList.remove('active');
}

document.getElementById('confirmCancelBtn').addEventListener('click', function() {
    if (!Id) return;

    fetch('/Users/Account/CancelReservation/' + Id, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' }
    })
        .then(function(res) {
            return res.json().then(function(data) {
                return { ok: res.ok, data: data };
            });
        })
        .then(function(result) {
            closeCancelModal();
            if (result.ok && result.data.isSuccess) {
                showToast(result.data.message || 'Rezervasyon iptal edildi.', 'success');
                setTimeout(function() { location.reload(); }, 900);
            } else {
                var msg = (result.data && result.data.message) ? result.data.message : 'İptal sırasında bir hata oluştu.';
                showToast(msg, 'error');
            }
        })
        .catch(function(error) {
            console.error('Hata Detayı:', error);
            closeCancelModal();
            showToast('Sunucuya ulaşılamadı, lütfen tekrar deneyin.', 'error');
        });
});

document.querySelectorAll('.res-modal-overlay').forEach(function(overlay) {
    overlay.addEventListener('click', function(e) {
        if (e.target === overlay) {
            overlay.classList.remove('active');
        }
    });
});

document.querySelectorAll('.res-sidebar-item').forEach(function(btn) {
    btn.addEventListener('click', function() {
        document.querySelectorAll('.res-sidebar-item').forEach(function(b) {
            b.classList.remove('active');
        });
        btn.classList.add('active');

        var filter = btn.dataset.filter;
        var cards = document.querySelectorAll('.res-card');
        var visibleCount = 0;

        cards.forEach(function(card) {
            var show = filter === 'all' || card.dataset.category === filter;
            card.style.display = show ? '' : 'none';
            if (show) visibleCount++;
        });

        var emptyFiltered = document.getElementById('resEmptyFiltered');
        if (emptyFiltered) {
            emptyFiltered.style.display = visibleCount === 0 ? 'block' : 'none';
        }
    });
});