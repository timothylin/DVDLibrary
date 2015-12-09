$(document).ready(function () {
    $('#addMovieForm').validate({
        rules: {
            "Movie.Title": {
                required: true
            },
            "Movie.MpaaRating.MpaaRatingID": {
                required: true
            },
            "Movie.Director.DirectorID": {
                required: true
            },
            "Movie.ReleaseDate": {
                required: true,
                min: 1,
                minlength: 4,
                maxlength: 4
            },
            "Movie.Studio.StudioID": {
                required: true
            },
            "Movie.ActorIDs": {
                required: true
            }
        },
        messages: {
            "Movie.Title": "Please enter a title.",
            "Movie.MpaaRating.MpaaRatingID": "Please select a rating.",
            "Movie.Director.DirectorID": "Please select a director.",
            "Movie.ReleaseDate": {
                required: "Please enter in yyyy format!",
                min: "Please enter in yyyy format!",
                minlength: $.validator.format("Too Short!!"),
                maxlength: $.validator.format("Too Long!!")
            },
            "Movie.Studio.StudioID": "Please select a studio.",
            "Movie.ActorIDs": "Please select actors."
        }
    });
});