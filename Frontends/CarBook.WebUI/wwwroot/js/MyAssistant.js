 var aiHistory = [];
    var aiIsSending = false;

    var aiInput = document.getElementById('aiInput');
    var aiMessages = document.getElementById('aiMessages');
    var aiSendBtn = document.getElementById('aiSendBtn');

    aiInput.addEventListener('input', function () {
        aiInput.style.height = 'auto';
        aiInput.style.height = Math.min(aiInput.scrollHeight, 110) + 'px';
    });

    aiInput.addEventListener('keydown', function (e) {
        if (e.key === 'Enter' && !e.shiftKey) {
            e.preventDefault();
            sendMessage();
        }
    });

    function fillSuggestion(btn) {
        aiInput.value = btn.textContent;
        aiInput.focus();
        aiInput.dispatchEvent(new Event('input'));
    }

    function scrollToBottom() {
        aiMessages.scrollTop = aiMessages.scrollHeight;
    }

    function nowLabel() {
        var d = new Date();
        return d.getHours().toString().padStart(2, '0') + ':' + d.getMinutes().toString().padStart(2, '0');
    }

    function appendMessage(role, text) {
        var row = document.createElement('div');
        row.className = 'ai-msg-row ' + role;

        var avatarIcon = role === 'user' ? 'fa-user' : 'fa-robot';

        row.innerHTML =
            '<div class="ai-msg-avatar"><i class="fas ' + avatarIcon + '"></i></div>' +
            '<div>' +
                '<div class="ai-msg-bubble"></div>' +
                '<div class="ai-msg-time">' + nowLabel() + '</div>' +
            '</div>';

        row.querySelector('.ai-msg-bubble').textContent = text;
        aiMessages.appendChild(row);
        scrollToBottom();
    }

    function showTyping() {
        var row = document.createElement('div');
        row.className = 'ai-msg-row assistant';
        row.id = 'aiTypingRow';
        row.innerHTML =
            '<div class="ai-msg-avatar"><i class="fas fa-robot"></i></div>' +
            '<div class="ai-typing"><span></span><span></span><span></span></div>';
        aiMessages.appendChild(row);
        scrollToBottom();
    }

    function hideTyping() {
        var row = document.getElementById('aiTypingRow');
        if (row) { row.remove(); }
    }

    function sendMessage() {
        var text = aiInput.value.trim();
        if (!text || aiIsSending) return;

        appendMessage('user', text);
        aiHistory.push({ Role: 'user', Content: text });

        aiInput.value = '';
        aiInput.style.height = 'auto';
        aiIsSending = true;
        aiSendBtn.disabled = true;
        showTyping();

        fetch('/Users/Account/AskAssistant', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ Message: text, History: aiHistory })
        })
            .then(function (res) { return res.json().then(function (data) { return { ok: res.ok, data: data }; }); })
            .then(function (result) {
                hideTyping();
                aiIsSending = false;
                aiSendBtn.disabled = false;

                if (result.ok && result.data && result.data.message) {
                    appendMessage('assistant', result.data.message);
                    aiHistory.push({ Role: 'assistant', Content: result.data.message });
                } else {
                    appendMessage('assistant', 'Üzgünüm, şu anda yanıt veremiyorum. Lütfen daha sonra tekrar deneyin.');
                }
            })
            .catch(function () {
                hideTyping();
                aiIsSending = false;
                aiSendBtn.disabled = false;
                appendMessage('assistant', 'Sunucuya ulaşılamadı, lütfen internet bağlantınızı kontrol edip tekrar deneyin.');
            });
    }