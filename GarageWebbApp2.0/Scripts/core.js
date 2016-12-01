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
        text: "After removing this vehicle from the garage you can't revert back!",
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Remove'
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