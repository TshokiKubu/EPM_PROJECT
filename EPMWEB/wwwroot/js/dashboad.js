
function GetNoOfUsersPerLocationCount() {
    $control = $("#noOfUsersPerLocationCount");

    if ($control.length === 0) {

        return false;
    }

    $control.text('...');

    $.ajax({
        type: 'GET',
        url: getNoOfUsersPerLocationCountUrl,
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            if (data.success === true) {
                $control.text(data.result);
            }
            else {
                toastr.error(result.message);
            }
        },
        error: function (e) {
            toastr.error('An error occured while loading expiring today dasboard: ' + e.status);
        },
        complete: function () {

        }
    });
}

function GetNoOfUsersOverallCount() {

    var $control = $("#noOfUsersOverallCount");

    if ($control.length === 0) return false;

    $control.text('...');

    $.ajax({
        type: 'GET',
        url: getNoOfUsersOverallCountUrl,
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            if (data.success === true) {
                $control.text(data.result);
            }
            else {
                toastr.error(result.message);
            }
        },
        error: function (e) {
            toastr.error('An error occured while loading pending count dasboard: ' + e.status);
        },
        complete: function () {

        }
    });
}


function GetNoOfClientsPerDateCount() {

    var $control = $("#noOfClientsPerDateCount");

    if ($control.length === 0) return false;

    $control.text('...');

    $.ajax({
        type: 'GET',
        url: getNoOfClientsPerDateCountUrl,
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            if (data.success === true) {
                $control.text(data.result);
            }
            else {
                toastr.error(result.message);
            }
        },
        error: function (e) {
            toastr.error('An error occured while loading pending count dasboard: ' + e.status);
        },
        complete: function () {

        }
    });
}

