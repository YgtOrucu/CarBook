    var commentToDeleteId = null;

    function showCmToast(message, type) {
        var toast = document.getElementById('cmToast');
        var toastText = document.getElementById('cmToastText');
        var icon = toast.querySelector('i');

        toastText.textContent = message;
        toast.className = 'cm-toast show ' + (type || 'success');
        icon.className = type === 'error' ? 'fas fa-circle-exclamation' : 'fas fa-check-circle';

        setTimeout(function () {
            toast.classList.remove('show');
        }, 3500);
    }

    function updateCharCount() {
        var textarea = document.getElementById('cmUpdateMessage');
        document.getElementById('cmCharCount').textContent = textarea.value.length;
    }

    /* ===== Güncelleme Modalı ===== */
    function openUpdateModal(btn) {
        var card = btn.closest('.cm-card');

        document.getElementById('cmUpdateId').value = card.dataset.id;
        document.getElementById('cmUpdateBlogTitle').textContent = card.dataset.blogtitle;
        document.getElementById('cmUpdateMessage').value = card.dataset.message;
        updateCharCount();

        document.getElementById('cmUpdateModalOverlay').classList.add('active');
    }

    function closeUpdateModal() {
        document.getElementById('cmUpdateModalOverlay').classList.remove('active');
    }

    document.getElementById('cmUpdateForm').addEventListener('submit', function (e) {
        e.preventDefault();

        var payload = {
            Id: parseInt(document.getElementById('cmUpdateId').value, 10),
            MessageBody: document.getElementById('cmUpdateMessage').value
        };

        fetch('/Users/Account/UpdateComment', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(payload)
        })
            .then(function (res) { return res.json().then(function (data) { return { ok: res.ok, data: data }; }); })
            .then(function (result) {
                closeUpdateModal();
                if (result.ok) {
                    showCmToast('Yorumunuz başarıyla güncellendi.', 'success');
                    setTimeout(function () { location.reload(); }, 900);
                } else {
                    var msg = (result.data && result.data.message) ? result.data.message : 'Güncelleme sırasında bir hata oluştu.';
                    showCmToast(msg, 'error');
                }
            })
            .catch(function () {
                closeUpdateModal();
                showCmToast('Sunucuya ulaşılamadı, lütfen tekrar deneyin.', 'error');
            });
    });

    /* ===== Silme Modalı ===== */
    function openDeleteModal(id) {
        commentToDeleteId = id;
        document.getElementById('cmDeleteModalOverlay').classList.add('active');
    }

    function closeDeleteModal() {
        commentToDeleteId = null;
        document.getElementById('cmDeleteModalOverlay').classList.remove('active');
    }

    document.getElementById('cmConfirmDeleteBtn').addEventListener('click', function () {
        if (!commentToDeleteId) return;

        fetch('/Users/Account/DeleteComment/' + commentToDeleteId, {
            method: 'POST'
        })
            .then(function (res) { return res.json().then(function (data) { return { ok: res.ok, data: data }; }); })
            .then(function (result) {
                closeDeleteModal();
                if (result.ok) {
                    showCmToast('Yorum silindi.', 'success');
                    var card = document.querySelector('.cm-card[data-id="' + commentToDeleteId + '"]');
                    if (card) { card.remove(); }
                    setTimeout(function () { location.reload(); }, 900);
                } else {
                    var msg = (result.data && result.data.message) ? result.data.message : 'Silme sırasında bir hata oluştu.';
                    showCmToast(msg, 'error');
                }
            })
            .catch(function () {
                closeDeleteModal();
                showCmToast('Sunucuya ulaşılamadı, lütfen tekrar deneyin.', 'error');
            });
    });

    /* Overlay dışına tıklayınca kapatma */
    document.querySelectorAll('.cm-modal-overlay').forEach(function (overlay) {
        overlay.addEventListener('click', function (e) {
            if (e.target === overlay) {
                overlay.classList.remove('active');
            }
        });
    });