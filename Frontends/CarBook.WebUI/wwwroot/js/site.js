window.addEventListener('scroll', function () {
    const userInfo = document.getElementById('userInfo');

    if (userInfo) {
        const nameDiv = userInfo.querySelector('.name');
        const roleDiv = userInfo.querySelector('.role');

        if (window.scrollY > 50) {
            nameDiv.classList.remove('text-white');
            nameDiv.style.color = '#000000';
            roleDiv.classList.remove('text-white');
            roleDiv.style.color = '#000000';
        } else {
            nameDiv.classList.add('text-white');
            nameDiv.style.color = '';
            roleDiv.classList.add('text-white');
            roleDiv.style.color = '';
        }
    }
});


document.addEventListener("DOMContentLoaded", function () {
    $('.open-comment-modal').on('click', function () {
        var name = $(this).data('name');
        var initials = $(this).data('initials');
        var blog = $(this).data('blog');
        var message = $(this).data('message');
        var date = $(this).data('date');

        $('#modalUserName').text(name);
        $('#modalUserInitials').text(initials);
        $('#modalBlogTitle').text(blog);
        $('#modalMessage').text(message);
        $('#modalDate').text(date);
    });
});