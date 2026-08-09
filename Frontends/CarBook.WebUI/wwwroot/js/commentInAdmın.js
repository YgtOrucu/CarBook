$(document).ready(function () {
    $('.open-comment-modal').on('click', function () {
        var name = $(this).data('name');
        var image = $(this).data('image') || '/carbook-admin/assets/images/users/avatar-1.jpg';
        var blog = $(this).data('blog');
        var message = $(this).data('message');
        var date = $(this).data('date');

        $('#modalUserName').text(name);
        $('#modalUserImage').attr('src', image);
        $('#modalBlogTitle').text(blog);
        $('#modalMessage').text(message);
        $('#modalDate').text(date);
    });
});