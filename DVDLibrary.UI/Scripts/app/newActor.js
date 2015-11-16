$('#AddActor').click(function() {
    var index = 0;
    var clone = '<p>@Html.ListBoxFor(m => m.Movie.Actors[#].ActorID, Model.ActorsList, new {style = "width:100%"})</p>';
    // Update the index of the clone
    clone.html($(clone).html().replace(/\[#\]/g, '[' + index++ + ']'));
    //clone.html($(clone).html().replace(/"%"/g, '"' + index + '"'));
    $('#actor').append(clone.html());
});