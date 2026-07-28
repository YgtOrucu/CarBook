function closeSuccessCard() {
    var cardModal = document.getElementById('successCardModal');
    if (cardModal) {
        cardModal.style.opacity = '0';
        cardModal.style.transition = 'opacity 0.2s ease';
        setTimeout(function () {
            cardModal.style.display = 'none';
        }, 200);
    }
}

function closeErrorCard() {
    var cardModal = document.getElementById('errorCardModal');
    if (cardModal) {
        cardModal.style.opacity = '0';
        cardModal.style.transition = 'opacity 0.2s ease';
        setTimeout(function () {
            cardModal.style.display = 'none';
        }, 200);
    }
}