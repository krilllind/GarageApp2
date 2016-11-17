function errorpopup() {
    swal({
        title: 'Error!',
        text: 'There is no Vehicle that matches your search in the garage.',
        type: 'error',
        confirmButtonText: 'Continue'
    });
}

$(document).on("click", ".RemoveBtn", function (e) {
    var el = $(this);
    e.preventDefault();

    swal({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, remove it!'
    }).then(function () {
        swal(
          'Deleted!',
          'Your vehicle has been removed.',
          'success'
        ).then(function () {
            window.location.href = $(el).attr("href");
        });
    });
});