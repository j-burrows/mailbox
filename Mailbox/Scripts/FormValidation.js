$(function () {
    function addError(inputField, errorMessage) {
        inputField.addClass('invalid');
        inputField.next('.ValidationError').html(errorMessage);
    }

    function removeError(inputField) {
        inputField.removeClass('invalid');
        inputField.next('.ValidationError').html('');
    }

    $('.BlockedUserCreate, .FriendedUserCreate').submit(function (event) {
        var isValid = true;
        var AuthorInput = $(this).children('input[name=Author_Name]');

        if (AuthorInput.val() == '') {
            addError(AuthorInput, 'Author name cannot be empty.');
            isValid = false;
        }
        else if (AuthorInput.val().length > 32) {
            addError(AuthorInput, 'Author name cannot exceed 32 characters.');
            isValid = false;
        }
        else {
            removeError(AuthorInput);
        }

        if (isValid) {
            $.ajax({
                type: "POST",
                dataType: "html",
                url: $(this).attr("action"),
                data: $(this).serialize(),
                success: function (data) {
                    var ViewResult = $('<div>' + data + '</div>');
                    $('#mainContent').html(ViewResult.find('#mainContent').html());
                }
            });
        }
        event.preventDefault();
        return false;
    });

    $('.BlockedUserCreate > input[name=Author_Name], .FriendedUserCreate > input[name=Author_Name]').on('input', function () {
        //If an invalid field is changed, its validility is reexamined.
        if ($(this).hasClass('invalid')) {
            if ($(this).val() == '') {
                addError($(this), 'Author name cannot be empty.');
            }
            else if ($(this).val().length > 32) {
                addError($(this), 'Author name cannot exceed 32 characters.');
            }
            else {
                removeError($(this));
            }
        }
    });

    $('.BlockedUserUpdate, .FriendedUserUpdate').submit(function (event) {
        var isValid = true;
        var AuthorInput = $(this).children('input[name=Author_Name]');

        if (AuthorInput.val().length > 32) {
            addError(AuthorInput, 'Author name cannot exceed 32 characters.');
            isValid = false;
        }
        else {
            removeError(AuthorInput);
        }

        if (isValid) {
            $.ajax({
                type: "POST",
                dataType: "html",
                url: $(this).attr("action"),
                data: $(this).serialize(),
                success: function (data) {
                    var ViewResult = $('<div>' + data + '</div>');
                    $('#mainContent').html(ViewResult.find('#mainContent').html());
                }
            });
        }
        event.preventDefault();
        return false;
    });

    $('.BlockedUserUpdate > input[name=Author_Name], .FriendedUserUpdate > input[name=Author_Name]').on('input', function () {
        //If an invalid field is changed, its validility is reexamined.
        if ($(this).hasClass('invalid')) {
            if ($(this).val().length > 32) {
                addError($(this), 'Author name cannot exceed 32 characters.');
            }
            else {
                removeError($(this));
            }
        }
    });

    $('.EmailCreate').submit(function (event) {
        var isValid = true;
        var RecipientInput = $(this).children('input[name=Recipient]');
        var TitleInput = $(this).children('input[name=Title]');
        var BodyInput = $(this).children('input[name=Body]');

        if (RecipientInput.val() == '') {
            addError(RecipientInput, 'Recipient cannot be empty.');
            isValid = false;
        }
        else if (RecipientInput.val().length > 32) {
            addError(RecipientInput, 'Recipient cannot exceed 32 characters.');
            isValid = false;
        }
        else {
            removeError(RecipientInput);
        }
        if (TitleInput.val().length > 32) {
            addError(TitleInput, 'Title cannot exceed 32 characters.');
            isValid = false;
        }
        else {
            removeError(TitleInput);
        }
        if (BodyInput.val() == '') {
            addError(BodyInput, 'Body cannot be empty.');
            isValid = false;
        }
        else if (BodyInput.val().length > 1024) {
            addError(BodyInput, 'Body cannot exceed 1024 characters.');
            isValid = false;
        }
        else {
            removeError(BodyInput);
        }

        if (isValid) {
            $.ajax({
                type: "POST",
                dataType: "html",
                url: $(this).attr("action"),
                data: $(this).serialize(),
                success: function (data) {
                    var ViewResult = $('<div>' + data + '</div>');
                    $('#mainContent').html(ViewResult.find('#mainContent').html());
                }
            });
        }
        event.preventDefault();
        return false;
    });

    $('.EmailCreate > input[name=Recipient]').on('input', function () {
        //If an invalid field is changed, its validility is reexamined.
        if ($(this).hasClass('invalid')) {
            if ($(this).val() == '') {
                addError($(this), 'Recipient cannot be empty.');
            }
            else if ($(this).val().length > 32) {
                addError($(this), 'Recipient cannot exceed 32 characters.');
            }
            else {
                removeError($(this));
            }
        }
    });

    $('.EmailCreate > input[name=Title]').on('input', function () {
        //If an invalid field is changed, its validility is reexamined.
        if ($(this).hasClass('invalid')) {
            if ($(this).val().length > 32) {
                addError($(this), 'Title cannot exceed 32 characters.');
            }
            else {
                removeError($(this));
            }
        }
    });

    $('.EmailCreate > input[name=Body]').on('input', function () {
        //If an invalid field is changed, its validility is reexamined.
        if ($(this).hasClass('invalid')) {
            if ($(this).val() == '') {
                addError($(this), 'Body cannot be empty.');
                isValid = false;
            }
            else if ($(this).val().length > 1024) {
                addError($(this), 'Body cannot exceed 1024 characters.');
                isValid = false;
            }
            else {
                removeError($(this));
            }
        }
    });

    $('.EmailUpdate').submit(function (event) {
        var isValid = true;
        var RecipientInput = $(this).children('input[name=Recipient]');
        var TitleInput = $(this).children('input[name=Title]');
        var BodyInput = $(this).children('input[name=Body]');

        if (RecipientInput.val().length > 32) {
            addError(RecipientInput, 'Recipient cannot exceed 32 characters.');
            isValid = false;
        }
        else {
            removeError(RecipientInput);
        }
        if (TitleInput.val().length > 32) {
            addError(TitleInput, 'Title cannot exceed 32 characters.');
            isValid = false;
        }
        else {
            removeError(TitleInput);
        }
        if (BodyInput.val().length > 1024) {
            addError(BodyInput, 'Body cannot exceed 1024 characters.');
            isValid = false;
        }
        else {
            removeError(BodyInput);
        }

        event.preventDefault();
        return false;
    });

    $('.EmailUpdate > input[name=Recipient]').on('input', function () {
        //If an invalid field is changed, its validility is reexamined.
        if ($(this).hasClass('invalid')) {
            if ($(this).val().length > 32) {
                addError($(this), 'Recipient cannot exceed 32 characters.');
            }
            else {
                removeError($(this));
            }
        }
    });

    $('.EmailUpdate > input[name=Title]').on('input', function () {
        //If an invalid field is changed, its validility is reexamined.
        if ($(this).hasClass('invalid')) {
            if ($(this).val().length > 32) {
                addError($(this), 'Title cannot exceed 32 characters.');
            }
            else {
                removeError($(this));
            }
        }
    });

    $('.EmailUpdate > input[name=Body]').on('input', function () {
        //If an invalid field is changed, its validility is reexamined.
        if ($(this).hasClass('invalid')) {
            if ($(this).val().length > 1024) {
                addError($(this), 'Body cannot exceed 1024 characters.');
                isValid = false;
            }
            else {
                removeError($(this));
            }
        }
    });

    $('.BlockedUserDelete, .FriendedUserDelete, .EmailDelete').submit(function (event) {
        $.ajax({
            type: "POST",
            dataType: "html",
            url: $(this).attr("action"),
            data: $(this).serialize(),
            success: function (data) {
                var ViewResult = $('<div>' + data + '</div>');
                $('#mainContent').html(ViewResult.find('#mainContent').html());
            }
        });
        event.preventDefault();
        return false;
    });
});