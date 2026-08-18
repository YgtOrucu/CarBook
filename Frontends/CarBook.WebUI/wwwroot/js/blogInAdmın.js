document.getElementById('btnGenerateAI').addEventListener('click', async function () {
    const categorySelect = document.getElementById('ddlCategory');
    const titleInput = document.getElementById('txtTitle');
    const descInput = document.getElementById('txtDescription');
    const btn = this;

    const categoryId = categorySelect.value;
    const categoryText = categorySelect.options[categorySelect.selectedIndex]?.text.trim();

    if (!categoryId) {
        alert('Lütfen AI üretimi için öncelikle bir Kategori seçiniz.');
        categorySelect.focus();
        return;
    }

    const originalText = btn.innerHTML;
    btn.disabled = true;
    btn.innerHTML = '<i class="mdi mdi-spin mdi-loading mr-1"></i> Yapay Zeka Düşünüyor...';

    try {
        const response = await fetch('/Admin/Blog/GenerateBlogWithAI', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                categoryName: categoryText
            })
        });

        const data = await response.json();

        if (data.success) {
            titleInput.value = data.title;
            descInput.value = data.description;
        } else {
            alert(data.message || 'AI içeriği üretilirken bir hata oluştu.');
        }
    } catch (err) {
        alert('Yapay zeka servisi ile bağlantı kurulurken sunucu hatası oluştu.');
    } finally {
        btn.disabled = false;
        btn.innerHTML = originalText;
    }
});