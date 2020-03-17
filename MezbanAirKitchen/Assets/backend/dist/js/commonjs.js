$(function () {
    function onSuccess(messsage, status) {
        if (status === 1) {
            $("#loadingBar").hide();
            toastr.success(data.message, {
                timeOut: 2000,
            });
            setTimeout(() => window.location.reload(), 500);
        } else {
            $("#loadingBar").hide();
            toastr.error(data.message, {
                timeOut: 2000,
            });
        };
    }

    function onFailure(response) {
        console.log(response);
        toastr.error(response, {
            timeOut: 2000,
        });
    }
})