$(document).ready(function () {
    $('#addMovieForm').validate({
        rules: {
            Title: {
                required: true
            },
            MpaaRating: {
                required: true,
            },
            Director: {
                required: true
            },
            ReleaseDate: {
                required: true,
                minlength: 4
            },
            Studio: {
                required: true
            },
            Actors: {
                required: true
            }
        },
        messages: {
            Title: "Please enter a title.",
            MpaaRating: "Please select a rating.",
            Director: "Please select a director.",
            ReleaseDate: {
                minlength: $.validator.format("Please enter in yyyy format!")
            },
            Studio: "Please select a studio.",
            Actors: "Please select actors."
        }
    });
});